using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// نمایش یک آیتم منو با امکان کلیک و رفتن به صفحه دیکر 
/// </summary>
public class MenuItem : BaseItem
{
	public string? ItemType { get; set; }
	public bool IsActive { get; set; }
	public SidePositions? sidePositions { get; set; }

	/// <summary>
	/// لیستی از صفحات قابل کلیک که به این منو متصل هستند
	/// </summary>
	public List<MenuItem>? ClickPage { get; set; }
}