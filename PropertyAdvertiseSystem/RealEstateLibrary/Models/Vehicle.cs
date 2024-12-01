using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// اطلاعات پایه‌ وسایل نقلیه
/// </summary>
public class Vehicle : BaseItem
{
	public string Model { get; set; }
	public string Make { get; set; }
	public int Year { get; set; }
	public string Color { get; set; }
	public decimal Price { get; set; }
}
