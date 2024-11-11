using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// برای نمایش آیتم‌های مختلف منو و نکهداری صفحات کلیک در هر آیتم منو طراحی شده است
/// </summary>
public class MenuItem : BaseItem
{
	// دیکشنری از صفحات تعاملی متصل به آیتم منو
	public Dictionary<string, InteractivePage> ClickPages { get; set; } = new Dictionary<string, InteractivePage>();

	public string ItemType { get; set; }
	public bool IsActive { get; set; }
}