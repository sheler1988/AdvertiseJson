using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس نماینده یک صفحه کلیک که می‌تواند شامل لیستی از آیتم‌ها باشد.
/// </summary>
public class ClickPage
{
	public string PageTitle { get; set; }

	public string PageDescription { get; set; }

	// ترتیب نمایش آیتم‌ها در صفحه در صورتی که نیاز به مرتب‌سازی آیتم‌ها دارید
	public int Order { get; set; }

	// دسته‌بندی صفحه برای سازماندهی بهتر
	public string Category { get; set; }

	// دیکشنری برای نکهداری آیتم‌های منو
	public Dictionary<string, MenuItem> Items { get; set; } = new Dictionary<string, MenuItem>();

	public ClickPage()
	{
		Items = new Dictionary<string, MenuItem>();
	}
}
