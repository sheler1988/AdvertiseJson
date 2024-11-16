using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// برای ورودی‌های عددی طراحی شده مثل متراژ یا مبلغ اجاره
/// </summary>
public class InputItem : BaseItem
{
	public string Placeholder { get; set; } // متن راهنمای ورودی
	public string DefaultValue { get; set; } //مقدار پیش‌فرض ورودی
	public string ValueRange { get; set; } //بازه معتبر مقادیر ورودی
	public bool Optional { get; set; } //آیا ورودی الزامی است یا خیر
	public string ValidationError { get; set; } //پیام خطا در صورت نامعتبر بودن ورودی

	// اورایدینک متد برای نمایش اطلاعات خاص ورودی
	//کاربردش برای مقادیر ورودی مانند تعداد اتاق یا مبلغ اجاره
	public override void DisplayInfo()
	{
		base.DisplayInfo();

		Console.WriteLine($"Placeholder: {Placeholder}, DefaultValue: {DefaultValue}, ValueRange: {ValueRange}, Optional: {Optional}, ValidationError: {ValidationError}");
	}
}