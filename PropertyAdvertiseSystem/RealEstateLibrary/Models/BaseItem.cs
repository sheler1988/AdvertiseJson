using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class BaseItem : IValidatable
{
    public String Type { get; set; }
    public String Text { get; set; }
    public bool IsVisible { get; set; } = true;
    public string ValidationError { get; set; }


    // بررسی ویژکی‌های پایه که ممکن است برای تمام آیتم‌ها معتبر باشد
    public virtual bool Validate()
    {
        return !string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(Text);
    }
}
