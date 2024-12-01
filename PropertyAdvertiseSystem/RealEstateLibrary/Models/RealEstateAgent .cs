using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// ذخیره اطلاعات نمایندکان املاک
/// </summary>
public class RealEstateAgent : BaseItem
{
	public string Name { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
	public string Agency { get; set; }
}
