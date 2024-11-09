using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس پایه برای تمام آیتم‌ها که ویژکی‌های مشترک و متدهای اعتبارسنجی را فراهم می‌کند.
/// </summary>
public class BaseItem : IValidatable
{
	/// <summary>
	/// نوع آیتم (مثلاً InputItem، LabelItem و غیره).
	/// </summary>
	public String Type { get; set; }

	/// <summary>
	/// متن مربوط به آیتم.
	/// </summary>
	public String Text { get; set; }

	/// <summary>
	/// مشخص می‌کند که آیا آیتم قابل مشاهده است یا خیر.
	/// </summary>
	public bool IsVisible { get; set; } = true;

	/// <summary>
	/// پیام خطا در صورت عدم اعتبارسنجی.
	/// </summary>
	public string ValidationError { get; set; }

	/// <summary>
	/// بررسی اعتبار ویژکی‌های پایه که ممکن است برای تمام آیتم‌ها معتبر باشد.
	/// </summary>
	/// <returns>برمی‌کرداند که آیا اعتبارسنجی موفق بود یا خیر.</returns>
	public virtual bool Validate()
	{
		if (string.IsNullOrEmpty(Type))
		{
			ValidationError = "نوع آیتم الزامی است.";
			return false;
		}

		if (string.IsNullOrEmpty(Text))
		{
			ValidationError = "متن آیتم الزامی است.";
			return false;
		}

		return true;
	}

	/// <summary>
	/// نمایش اطلاعات آیتم به صورت یک رشته.
	/// </summary>
	/// <returns>رشته‌ای که شامل اطلاعات آیتم است.</returns>
	public override string ToString()
	{
		return $"{Type}: {Text} (Visible: {IsVisible})";
	}
}



