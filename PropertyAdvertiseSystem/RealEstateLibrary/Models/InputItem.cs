using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس برای آیتم‌هایی که از نوع ورودی عددی هستند مثل متراژ یا مبلغ اجاره.
/// </summary>
public class InputItem : Item, IValidatable
{
	/// <summary>
	/// متنی که در ورودی نمایش داده می‌شود زمانی که کاربر چیزی وارد نکرده است.
	/// </summary>
	public string Placeholder { get; set; }

	/// <summary>
	/// مقدار پیش‌فرض ورودی.
	/// </summary>
	public string DefaultValue { get; set; }

	/// <summary>
	/// محدوده مجاز ورودی به صورت رشته، مانند "[0,100]".
	/// </summary>
	public string ValueRange { get; set; }

	/// <summary>
	/// مشخص می‌کند که آیا ورودی اجباری است یا اختیاری.
	/// </summary>
	public bool Optional { get; set; }

	/// <summary>
	/// خطای اعتبارسنجی در صورت بروز مشکل.
	/// </summary>
	public string ValidationError { get; set; }

	/// <summary>
	/// مقدار ورودی که کاربر وارد می‌کند.
	/// </summary>
	public string Value { get; set; }

	/// <summary>
	/// نوع ورودی، که می‌تواند عددی یا متنی باشد.
	/// </summary>
	public enum ValueType
	{
		Number,
		Text
	}

	/// <summary>
	/// نوع مقدار ورودی.
	/// </summary>
	public ValueType InputValueType { get; set; }

	/// <summary>
	/// بررسی اینکه ورودی معتبر و در محدوده مشخص شده باشد.
	/// </summary>
	/// <returns>برمی‌کرداند که آیا ورودی معتبر است یا خیر.</returns>
	public override bool Validate()
	{
		// بررسی اینکه ورودی خالی نباشد
		if (string.IsNullOrEmpty(Value))
		{
			ValidationError = "ورودی الزامی است.";
			return !Optional; // اگر اختیاری باشد، خطا را برگردانید
		}

		// فقط در صورتی که نوع ورودی Number باشد، بررسی کنیم
		if (InputValueType == ValueType.Number)
		{
			if (!int.TryParse(Value, out int result) || result < 0)
			{
				ValidationError = "لطفاً یک عدد صحیح مثبت وارد کنید.";
				return false;
			}

			// اگر ValueRange تعیین شده باشد، آن را پردازش کنید
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
		}

		return true;
	}
}
