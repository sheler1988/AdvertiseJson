using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class MenuItem : Item, IValidatable
{
	//این ویژکی یک لیسته که می‌تونه شامل هر نوع آیتم دیکه باشه مانند زیر منوها، لیبل‌ها و ورودی‌ها

	// این لیست به شما این امکان رو می‌ده که ساختار سلسله‌مراتبی منوها را پیاده‌سازی کنید
	public List<BaseItem> ClickPageItems { get; set; } = new List<BaseItem>();

	public List<MenuItem> SubMenuItems { get; set; } = new List<MenuItem>();


	// بررسی اینکه متن منو و تعداد زیر منوها وجود دارد
	public bool Validate()
	{
		// باید مطمئن شویم که متن وجود دارد و حداقل یک زیر منو یا آیتم در ClickPageItems وجود دارد
		return !string.IsNullOrEmpty(Text) && ClickPageItems.Count > 0 || SubMenuItems.Count > 0;
	}

	// برای نمایش اطلاعات منو
	public override string ToString()
	{
		return $"{base.ToString()}, ClickPageItems: {ClickPageItems.Count}, SubMenuItems: {SubMenuItems.Count}";
	}
}
