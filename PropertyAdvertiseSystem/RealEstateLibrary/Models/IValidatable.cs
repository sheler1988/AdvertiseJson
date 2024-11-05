using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

// به شما این امکان رو می‌ده که هر کلاس که از آن استفاده می‌کند متدهای مربوط به اعتبارسنجی را پیاده‌سازی کند
public interface IValidatable
{
	// این متد می‌تونه برای انجام اعتبارسنجی روی داده‌های کلاس‌هایی که این اینترفیس را پیاده‌سازی می‌کنند، استفاده شود
	bool Validate();
}
