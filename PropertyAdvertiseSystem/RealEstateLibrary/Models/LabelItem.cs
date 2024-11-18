using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;
/// <summary>
/// برای نمایش آیتم‌های برچسبی
/// </summary>
public class LabelItem : BaseItem
{
	public string? Color { get; set; }
	public string? FontStyle { get; set; }
	public int? FontSize { get; set; }
	public string? AdditionalDescription { get; set; } // توضیحات اضافی
}