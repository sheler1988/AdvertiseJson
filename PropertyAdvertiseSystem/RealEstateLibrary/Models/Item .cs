using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class Item : BaseItem
{
	// ویژکی‌هایی که به تمامی آیتم‌ها مشترک است
	public string Description { get; set; } // توضیحات مربوط به آیتم

	// لینک به صفحه مربوطه
	public ClickPage ClickPage { get; set; } // صفحه‌ای که به این آیتم مربوط می‌شود

	// بازنویسی متد ToString برای نمایش اطلاعات آیتم
	public override string ToString()
	{
		// نمایش اطلاعات پایه و توضیحات آیتم
		return $"{base.ToString()}, Description: {Description}";
	}
}
