using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// نمایش ویژکی‌های خاص هر ملک
/// </summary>
public class Property : BaseItem
{
	public string Address { get; set; }
	public decimal Price { get; set; }
	public int Bedrooms { get; set; }
	public int Bathrooms { get; set; }
	public double Area { get; set; }
}
