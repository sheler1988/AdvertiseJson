using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس برای آیتم‌هایی که از نوع ورودی عددی هستند مثل متراژ یا مبلغ اجاره.
/// </summary>
public class InputItem : BaseItem
{
	public string Placeholder { get; set; } // برای متن راهنمای ورودی
	public string DefaultValue { get; set; } // مقدار پیش‌فرض ورودی
	public string ValueRange { get; set; } // بازه معتبر مقادیر ورودی
	public bool Optional { get; set; } // آیا ورودی الزامی است یا خیر
	public string ValidationError { get; set; } //پیام خطا در صورت نامعتبر بودن ورودی
}
