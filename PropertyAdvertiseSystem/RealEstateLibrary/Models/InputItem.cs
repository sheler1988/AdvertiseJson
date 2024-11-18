using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// برای ورودی‌های عددی طراحی شده مثل متراژ یا مبلغ اجاره
/// </summary>
public class InputItem : BaseItem
{
	public string? Placeholder { get; set; }
	public string? DefaultValue { get; set; }
	public string? ValueRange { get; set; }
	public bool Optional { get; set; }
	public string? ValidationError { get; set; }
}