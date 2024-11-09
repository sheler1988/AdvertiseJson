using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RealEstateLibrary.Models;
using static System.Net.Mime.MediaTypeNames;


namespace RealEstateLibrary.Models;

public class ReadData
{

	public void ExportToJson(string filePath)
	{
		// ساخت نمونه‌هایی از کلاس‌های مختلف
		AdvertiseGroup advertiseGroup = new AdvertiseGroup();
		ClickPage clickPage = new ClickPage();
		List<BaseItem> allItems = new List<BaseItem>();

		// اضافه کردن نمونه‌های مختلف آیتم‌ها به advertiseGroup
		var item1 = new Item
		{
			Type = "Menu",
			Text = "Main Menu",
			IsVisible = true,
			Description = "This is the main menu item."
		};

		// مقداردهی item2
		var item2 = new InputItem
		{
			Type = "Input",
			Text = "Input Field",
			Value = "100",
			Placeholder = "Enter a number",
			InputValueType = InputItem.ValueType.Number
		};

		// اضافه کردن آیتم‌ها به کروه تبلیغاتی و صفحه کلیک
		try
		{
			advertiseGroup.AddItem("item1", item1);
			clickPage.AddItem(item2);
			allItems.Add(item1);
			allItems.Add(item2);

			// ایجاد شیء برای داده‌ها که می‌خواهیم صادر کنیم
			var dataToExport = new
			{
				AdvertiseGroup = advertiseGroup,
				ClickPage = clickPage,
				AllItems = allItems
			};

			// تبدیل داده‌ها به JSON
			var jsonData = JsonSerializer.Serialize(dataToExport, new JsonSerializerOptions { WriteIndented = true });

			// ذخیره‌سازی داده‌های JSON در فایل
			File.WriteAllText(filePath, jsonData);
			Console.WriteLine($"Data exported successfully to {filePath}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error exporting data: {ex.Message}");
		}
	}
}