using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

// برای آیتم‌هایی که از نوع ورودی عددی هستن مثل متراژ یا مبلغ اجاره 
public class InputItem : BaseItem, IValidatable
{
    public string Placeholder { get; set; }
    public string DefaultValue { get; set; }
    public string ValueRange { get; set; }
    public bool Optional { get; set; }
    public string ValidationError { get; set; }
    public string Value { get; set; }


	// بررسی اینکه ورودی معتبر و در محدوده مشخص شده باشد
	public bool Validate()
	{
		// بررسی اینکه ورودی خالی نباشد
		if (string.IsNullOrEmpty(Value))
		{
			ValidationError = "ورودی الزامی است.";
			return false;
		}

		// بررسی عددی بودن
		if (!int.TryParse(Value, out int result) || result < 0)
		{
			ValidationError = "لطفاً یک عدد صحیح مثبت وارد کنید.";
			return false;
		}

		// اکر ولیورنج تعیین شده باشد آن را پردازش کنید
		if (!string.IsNullOrEmpty(ValueRange))
		{
			// استخراج حداقل و حداکثر از ValueRange
			var rangeParts = ValueRange.Trim('[', ']').Split(',');
			if (rangeParts.Length == 2 &&
				int.TryParse(rangeParts[0], out int min) &&
				int.TryParse(rangeParts[1], out int max))
			{
				// بررسی اینکه آیا مقدار در محدوده است
				if (result < min || result > max)
				{
					ValidationError = $"ورودی باید در محدوده [{min},{max}] باشد.";
					return false;
				}
			}
			else
			{
				ValidationError = "فرمت محدوده نامعتبر است.";
				return false;
			}
		}

		return true;
	}
}


