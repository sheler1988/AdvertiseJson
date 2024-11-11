using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس پایه برای تمامی آیتم‌ها است و ویژکی‌های مشترکی بین همه آیتم‌ها را شامل می‌شود
/// </summary>
public class BaseItem
{
	public string Type { get; set; }
	public string TEXT { get; set; }
	public string Description { get; set; }
	public string Right { get; set; }
	public string Left { get; set; }
    public bool Enable { get; set; }
	public bool Visible { get; set; }
	public int Order { get; set; } // ترتیب نمایش منو

	// کالکشن لیستی از بیس آیتم ها برای نکهداری آیتم‌های مرتبط یا زیرآیتم‌ها
	public List<BaseItem> collection { get; set; }
}

