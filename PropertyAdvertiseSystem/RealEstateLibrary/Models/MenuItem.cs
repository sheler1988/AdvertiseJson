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
	public List<MenuItem>? ClickPage { get; set; }
}