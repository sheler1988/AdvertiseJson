using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// نماینده یک صفحه تعاملی با قابلیت نکهداری آیتم‌ها
/// کمک می‌کند تا صفحات مختلف را با ساختاری استاندارد و قابل مدیریت تعریف کنید و آیتم‌های مرتبط با آن‌ها را در قالب منوهای مختلف سازماندهی کنید
/// </summary>
public class InteractivePage : BaseItem
{
	public string PageTitle { get; set; } // عنوان صفحه

	public string PageDescription { get; set; } // توضیح صفحه
	public string Category { get; set; } // دسته‌بندی صفحه

	// ایتمس دیکشنری برای نکهداری آیتم‌های منو
	public Dictionary<string, MenuItem> Items { get; set; } = new Dictionary<string, MenuItem>();

	public InteractivePage()
	{
		Items = new Dictionary<string, MenuItem>();
	}

	// اورایدینک متد برای نمایش اطلاعات صفحه
	// کاربردش  تعریف صفحات مختلف با سازماندهی آیتم‌ها
	public override void DisplayInfo()
	{
		// نمایش ویژکی‌های مشترک از بیس آیتم
		base.DisplayInfo();

		// نمایش اطلاعات تمامی آیتم‌های موجود در صفحه
		Console.WriteLine($"PageTitle: {PageTitle}, PageDescription: {PageDescription}, Category: {Category}");

		// نمایش اطلاعات تمامی آیتم‌های موجود در صفحه
		foreach (var item in Items)
		{
			item.Value.DisplayInfo(); // نمایش اطلاعات منوها منوآیتم
		}
	}
}