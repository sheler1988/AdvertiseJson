using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// نماینده یک صفحه تعاملی است که می‌تواند شامل لیستی از آیتم‌ها باشد
/// کمک می‌کند تا صفحات مختلف را با ساختاری استاندارد و قابل مدیریت تعریف کنید و آیتم‌های مرتبط با آن‌ها را در قالب منوهای مختلف سازماندهی کنید
/// </summary>
public class InteractivePage
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
}
