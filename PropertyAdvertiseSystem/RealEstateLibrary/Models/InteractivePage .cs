using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// نمایش یک صفحه کامل و اطلاعات آن
/// </summary>
public class InteractivePage : BaseItem
{
	public string? PageTitle { get; set; } // عنوان صفحه
	public string? PageDescription { get; set; } // توضیح صفحه
	public string? Category { get; set; } // دسته‌بندی صفحه
}