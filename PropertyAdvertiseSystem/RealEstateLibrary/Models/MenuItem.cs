using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// برای نمایش موارد مختلف آیتم‌ها در هر صفحه استفاده می‌شود. شامل اطلاعاتی مثل نوع آیتم، متن، فونت سایز، ستون‌ها
/// </summary>
public class MenuItem : BaseItem
{
	// دیکشنری برای نکهداری زیرمنوها یا صفحه‌های کلیک
	public Dictionary<string, ClickPage> ClickPages { get; set; } = new Dictionary<string, ClickPage>();

	public string ItemType { get; set; }
	public int Order { get; set; } // ترتیب نمایش منو
	public bool IsActive { get; set; }
}