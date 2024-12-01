using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class Box : BaseItem
{
	public string Name { get; set; } //نام باکس مثلاً نمای جلو
	public string Location { get; set; } //موقعیت باکس در صفحه
}
