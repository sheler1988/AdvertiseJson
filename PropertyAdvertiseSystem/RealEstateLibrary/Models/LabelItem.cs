using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class LabelItem : BaseItem
{
	// اندازه فونت برای LabelItem
	public int FontSize { get; set; }

	// فرمت آیکون مربوط به LabelItem
	public IconFormat Icon { get; set; }

	// دایرکتوری آیکون‌ها
	private string iconDirectory;

	// سازنده برای تعیین مسیر دایرکتوری آیکون‌ها
	public LabelItem(string iconDirectory)
	{
		this.iconDirectory = iconDirectory;
	}

	// متد اعتبارسنجی برای LabelItem
	public override bool Validate()
	{
		// اعتبارسنجی برای ویژگی‌های پایه
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
			// بررسی اینکه آیکون تعیین شده باشد
			if (Icon == default(IconFormat))
			{
				ValidationError = "آیکون الزامی است.";
				return false;
			}

			// اعتبارسنجی فرمت آیکون
			if (!ValidateIconFormat())
			{
				return false;
			}

			// بررسی اینکه فایل آیکون وجود دارد
			return CheckIconExists();
		}
		catch (Exception ex)
		{
			ValidationError = $"خطا در اعتبارسنجی آیکون: {ex.Message}";
			return false;
		}
	}

	// متد برای اعتبارسنجی فرمت آیکون
	private bool ValidateIconFormat()
	{
		string iconExtension = $".{Icon.ToString().ToLower()}"; // تبدیل فرمت آیکون به رشته
		string[] validExtensions = { ".png", ".svg", ".jpg", ".jpeg" }; // فرمت‌های معتبر

		// بررسی اینکه فرمت آیکون در لیست فرمت‌های معتبر وجود دارد
		if (!validExtensions.Contains(iconExtension))
		{
			ValidationError = "فرمت آیکون معتبر نیست. لطفاً از فرمت‌های PNG، SVG، JPG یا JPEG استفاده کنید.";
			return false;
		}

		return true;
	}

	// متد برای بررسی وجود فایل آیکون
	private bool CheckIconExists()
	{
		// مسیر فایل آیکون با نام و فرمت صحیح
		string iconFileName = $"{Icon.ToString().ToLower()}";
		string iconPath = System.IO.Path.Combine(iconDirectory, iconFileName);

		// بررسی اینکه فایل آیکون وجود دارد
		if (!System.IO.File.Exists(iconPath))
		{
			ValidationError = "فایل آیکون پیدا نشد.";
			return false;
		}
		return true;
	}
}


