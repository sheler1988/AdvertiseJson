using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class LabelItem : BaseItem
{
    public int FontSize { get; set; }
	public IconFormat Icon { get; set; }

	private string iconDirectory;

	// سازنده برای تعیین مسیر دایرکتوری آیکون‌ها
	public LabelItem(string iconDirectory)
	{
		this.iconDirectory = iconDirectory;
	}

	public override bool Validate()
	{
		// اعتبارسنجی برای LabelItem
		if (!base.Validate())
			return false;

		// بررسی اینکه اندازه فونت معتبر باشد
		if (FontSize <= 0)
		{
			ValidationError = "اندازه فونت باید بزرکتر از صفر باشد.";
			return false;
		}

		// بررسی اینکه دایرکتوری آیکون وجود دارد
		if (!System.IO.Directory.Exists(iconDirectory))
		{
			ValidationError = "دایرکتوری آیکون نامعتبر است.";
			return false;
		}

		try
		{
			if (Icon == default(IconFormat)) // بررسی اینکه آیکون تعیین شده باشد
			{
				ValidationError = "آیکون الزامی است.";
				return false;
			}

			if (!ValidateIconFormat())
			{
				return false;
			}

			return CheckIconExists();
		}

		catch (Exception ex)
		{
			ValidationError = $"خطا در اعتبارسنجی آیکون: {ex.Message}";
			return false;
		}
	}
	private bool ValidateIconFormat()
	{
		string iconExtension = $".{Icon.ToString().ToLower()}";
		string[] validExtensions = { ".png", ".svg", ".jpg", ".jpeg" };

		if (!validExtensions.Contains(iconExtension))
		{
			ValidationError = "فرمت آیکون معتبر نیست. لطفاً از فرمت‌های PNG، SVG، JPG یا JPEG استفاده کنید.";
			return false;
		}

		return true;
	}

	private bool CheckIconExists()
	{
		// مسیر فایل آیکون با نام و فرمت صحیح
		string iconFileName = $"{Icon.ToString().ToLower()}";
		string iconPath = System.IO.Path.Combine(iconDirectory, iconFileName);

		if (!System.IO.File.Exists(iconPath))
		{
			ValidationError = "فایل آیکون پیدا نشد.";
			return false;
		}
		return true;
	}
}


