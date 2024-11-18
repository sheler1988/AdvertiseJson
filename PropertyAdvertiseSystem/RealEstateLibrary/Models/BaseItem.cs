using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس پایه برای تمامی آیتم‌ها و ویژکی‌های مشترک
/// </summary>
public class BaseItem
{
	public string? Type { get; set; }
	public string? Text { get; set; }
	public string? Description { get; set; }
    public bool Enable { get; set; }
	public bool Visible { get; set; }
}