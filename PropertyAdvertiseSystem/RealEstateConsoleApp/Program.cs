


using Newtonsoft.Json;
using RealEstateLibrary.Models;


//read dataa class(from json)

MenuItem menu = new MenuItem();
menu.Text = "Apple";
menu.IsVisible = false;

string json = JsonConvert.SerializeObject(menu);


// تنظیم کدکذاری کنسول به UTF-8
Console.OutputEncoding = System.Text.Encoding.UTF8;


// آزمایش کلاس MenuItem
MenuItem mainMenu = new MenuItem
{
	Type = "Menu",
	Text = "املاک و مستغلات",
	ClickPageItems = new List<BaseItem>
	{
		new MenuItem {Type = "Menu", Text = "اجاره مسکونی"},
		new MenuItem { Type = "Menu", Text = "فروش مسکونی" }
	}
};

// اعتبارسنجی منو
if (mainMenu.Validate())
{
	Console.WriteLine($"منو معتبر است: " + mainMenu.Text);
}
else
{
	Console.WriteLine($"منو نامعتبر است.");
}


// آزمایش کلاس InputItem
InputItem inputItem = new InputItem
{
	Type = "InputNumber",
	Value = "100" // عدد معتبر
};

// اعتبارسنجی ورودی
if (inputItem.Validate())
{
	Console.WriteLine($"ورودی معتبر است: " + inputItem.Value);
}
else
{
	Console.WriteLine($"ورودی نامعتبر است.");
}

// آزمایش ورودی نامعتبر
inputItem.Value = ""; // ورودی نامعتبر

if (inputItem.Validate())
{
	Console.WriteLine($"ورودی معتبر است: " + inputItem.Value);
}
else
{
	Console.WriteLine($"ورودی نامعتبر است.");
}




Console.ReadLine();