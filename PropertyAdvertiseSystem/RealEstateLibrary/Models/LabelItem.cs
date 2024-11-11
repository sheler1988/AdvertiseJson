﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;
/// <summary>
/// یک نوع آیتم نمایشی است
/// </summary>
public class LabelItem : BaseItem
{
	public string Color { get; set; }
	public string FontStyle { get; set; }
	public int? FontSize { get; set; }
	public string AdditionalDescription { get; set; } // توضیحات اضافی
}
