using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// برای دسته‌بندی کردن املاک به دسته‌های مختلف مانند آپارتمان، خانه ویلایی، تجاری و غیره
/// </summary>
public class Category
{
	public string Name { get; set; }
	public string Description { get; set; }
}
