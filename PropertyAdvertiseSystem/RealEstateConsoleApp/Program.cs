using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using RealEstateLibrary.Models;

namespace RealEstateLibrary
{
	class Program
	{
		static void Main(string[] args)
		{
			// نکته در اتصال به دیتابیس مطمئن شوید کانکشن استرینک شما صحیح است و به دیتابیس موردنظر دسترسی دارد
			string connectionString = "your_connection_string_here";

			// برای هر کلاس یک کوئری اجرا می‌شود تا داده‌ها را از دیتابیس دریافت کنیم
			var baseItems = ReadData<BaseItem>(connectionString, "SELECT * FROM BaseItems");
			var inputItems = ReadData<InputItem>(connectionString, "SELECT * FROM InputItems");
			var interactivePages = ReadData<InteractivePage>(connectionString, "SELECT * FROM InteractivePages");
			var labelItems = ReadData<LabelItem>(connectionString, "SELECT * FROM LabelItems");
			var menuItems = ReadData<MenuItem>(connectionString, "SELECT * FROM MenuItems");

			// تبدیل داده‌ها به JSON
			SaveDataToJson("BaseItems.json", baseItems);
			SaveDataToJson("InputItems.json", inputItems);
			SaveDataToJson("InteractivePages.json", interactivePages);
			SaveDataToJson("LabelItems.json", labelItems);
			SaveDataToJson("MenuItems.json", menuItems);

			Console.WriteLine("Data successfully exported to JSON!");
		}

		// تابع برای خواندن داده‌ها از دیتابیس و تبدیل به شیء مورد نظر
		static List<T> ReadData<T>(string connectionString, string query) where T : new()
		{
			var data = new List<T>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var item = new T();
						foreach (var property in typeof(T).GetProperties())
						{
							if (reader[property.Name] != DBNull.Value)
							{
								property.SetValue(item, reader[property.Name]);
							}
						}
						data.Add(item);
					}
				}
			}

			return data;
		}

		// تابع برای ذخیره داده‌ها به‌عنوان فایل JSON
		static void SaveDataToJson<T>(string fileName, List<T> data)
		{
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(fileName, json);
		}
	}
}






//namespace RealEstateLibrary
//{
//	class Program
//	{
//		static void Main(string[] args)
//		{
//			List<object> result = new List<object>();

//			DataTable data = new DataTable();

//			//create 4 columns
//			data.Columns.Add("col1", typeof(string));
//			data.Columns.Add("col2", typeof(string));
//			data.Columns.Add("col3", typeof(string));
//			data.Columns.Add("col4", typeof(string));

//			//create 7 rows
//			DataRow dr1 = data.NewRow();
//			dr1["col1"] = "Menu";
//			dr1["col2"] = "";
//			dr1["col3"] = "";
//			dr1["col4"] = "";
//			data.Rows.Add(dr1);

//			DataRow dr2 = data.NewRow();
//			dr2["col1"] = "Menu";
//			dr2["col2"] = "Menu";
//			dr2["col3"] = "";
//			dr2["col4"] = "";
//			data.Rows.Add(dr2);

//			DataRow dr3 = data.NewRow();
//			dr3["col1"] = "Menu";
//			dr3["col2"] = "Menu";
//			dr3["col3"] = "Menu";
//			dr3["col4"] = "";
//			data.Rows.Add(dr3);

//			DataRow dr4 = data.NewRow();
//			dr4["col1"] = "Menu";
//			dr4["col2"] = "Menu";
//			dr4["col3"] = "Menu";
//			dr4["col4"] = "Label";
//			data.Rows.Add(dr4);

//			DataRow dr5 = data.NewRow();
//			dr5["col1"] = "Menu";
//			dr5["col2"] = "Menu";
//			dr5["col3"] = "Menu";
//			dr5["col4"] = "Label";
//			data.Rows.Add(dr5);

//			DataRow dr6 = data.NewRow();
//			dr6["col1"] = "Menu";
//			dr6["col2"] = "Menu";
//			dr6["col3"] = "Menu";
//			dr6["col4"] = "Label";
//			data.Rows.Add(dr6);

//			DataRow dr7 = data.NewRow();
//			dr7["col1"] = "Menu";
//			dr7["col2"] = "Menu";
//			dr7["col3"] = "Menu";
//			dr7["col4"] = "Input";
//			data.Rows.Add(dr7);


//			foreach (DataRow row in data.Rows)
//			{
//				foreach (object col in data.Columns)
//				{


//					if (row["col1"] == "Menu")
//					{
//						MenuItem menuItem1 = new MenuItem();
//						menuItem1.ItemType = "MenuItem";
//						menuItem1.Visible = true;
//						menuItem1.Enable = true;
//						menuItem1.collection = new List<BaseItem>();

//						result.Add(menuItem1);


//						MenuItem menuItem2 = new MenuItem();
//						menuItem2.ItemType = "Menu";
//						menuItem2.Visible = true;
//						menuItem2.Enable = true;

//						InteractivePage clickPage = new InteractivePage();
//						clickPage.Items.Add("", menuItem2);

//						menuItem1.ClickPages.Add("", clickPage);
//					}
//					if (row["col4"] == "label")
//					{
//						LabelItem labelItem = new LabelItem();
//						labelItem.Type = "label";
//						//labelItem.Visible = true;
//						//labelItem.Enable = true;

//						result.Add(labelItem);
//					}
//				}
//			}

//			string output = JsonConvert.SerializeObject(result);
//			File.WriteAllText("output.txt", output);
//		}
//	}
//}





//read dataa class(from json)

//MenuItem menu = new MenuItem();
//menu.Text = "Apple";
//menu.IsVisible = false;

//string json = JsonConvert.SerializeObject(menu);


