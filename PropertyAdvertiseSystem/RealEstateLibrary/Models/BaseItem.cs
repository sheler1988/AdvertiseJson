using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس پایه برای تمام آیتم‌ها که ویژکی‌های مشترک دارند
/// </summary>
public class BaseItem
{
	public string Type { get; set; }
	public string TEXT { get; set; }
	public int? FontSize { get; set; }
	public string Description { get; set; }
	public string Right { get; set; }
	public string Left { get; set; }
    public bool Enable { get; set; }
	public bool Visible { get; set; }
    public List<BaseItem> collection { get; set; }
}

