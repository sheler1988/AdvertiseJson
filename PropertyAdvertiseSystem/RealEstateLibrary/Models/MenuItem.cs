using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class MenuItem : BaseItem, IValidatable
{
	//این ویژکی یک لیسته که می‌تونه شامل هر نوع آیتم دیکه باشه مانند زیر منوها، لیبل‌ها و ورودی‌ها

	// این لیست به شما این امکان رو می‌ده که ساختار سلسله‌مراتبی منوها را پیاده‌سازی کنید
	public List<BaseItem> ClickPageItems { get; set; } = new List<BaseItem>();


	// بررسی اینکه متن منو و تعداد زیر منوها وجود دارد
	public bool Validate()
	{
		return !string.IsNullOrEmpty(Text) && ClickPageItems.Count > 0;
	}
}
