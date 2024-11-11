using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using RealEstateLibrary.Models;

namespace RealEstateLibrary
{
	class Program
	{
		static async Task Main(string[] args)
		{
			string apiUrl = " آدرس API";

			var allItems = await GetDataFromApi(apiUrl); // دریافت داده‌ها از API

			var result = ProcessData(allItems); // پردازش داده‌ها

			GenerateJson(result); // تبدیل داده‌ها به جیسون و ذخیره آن

			Console.WriteLine("JSON file generated successfully.");
		}

		// تابع برای دریافت داده‌ها از API
		static async Task<List<Dictionary<string, object>>> GetDataFromApi(string apiUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseData = await response.Content.ReadAsStringAsync();

				// فرض می‌کنیم داده‌ها به صورت یک لیست از دیکشنری‌ها باز می‌گردند
				var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseData);

				return data;
			}
		}



		// تابع برای پردازش داده‌ها
		static List<BaseItem> ProcessData(List<Dictionary<string, object>> data)
		{
			List<BaseItem> result = new List<BaseItem>();

			// پردازش هر ردیف
			foreach (var row in data)
			{
				if (row.ContainsKey("col1") && row["col1"].ToString() == "Menu")
				{
					MenuItem menuItem1 = new MenuItem();
					menuItem1.ItemType = "MenuItem";
					menuItem1.Visible = true;
					menuItem1.Enable = true;
					menuItem1.collection = new List<BaseItem>();

					result.Add(menuItem1);

					if (row.ContainsKey("col2") && row["col2"].ToString() == "Menu")
					{

						MenuItem menuItem2 = new MenuItem();
						menuItem2.ItemType = "Menu";
						menuItem2.Visible = true;
						menuItem2.Enable = true;

						InteractivePage clickPage = new InteractivePage();
						clickPage.Items.Add("", menuItem2);
						menuItem1.ClickPages.Add("", clickPage);
					}
				}

					if (row.ContainsKey("col4") && row["col4"].ToString() == "Label")
				{
					LabelItem labelItem = new LabelItem();
					labelItem.Type = "Label";
					labelItem.Visible = true;
					labelItem.Enable = true;

					result.Add(labelItem);
				}
				if (row.ContainsKey("col4") && row["col4"].ToString() == "Input")
				{
					InputItem inputItem = new InputItem();
					inputItem.Type = "Input";
					inputItem.Placeholder = "Enter value";
					inputItem.DefaultValue = "0";
					inputItem.ValueRange = "0-1000";
					inputItem.Optional = false;
					inputItem.ValidationError = "Please enter a valid number";

					result.Add(inputItem);
				}
			}
			return result;
		}

		// تابع برای تبدیل داده‌ها به فایل جیسون و ذخیره آن
		static void GenerateJson(List<BaseItem> allItems)
		{
			string output = JsonConvert.SerializeObject(allItems, Formatting.Indented);
			File.WriteAllText("output.json", output);
		}
	}
}



//		static void Main(string[] args)
//		{
//			// نکته در اتصال به دیتابیس مطمئن شوید کانکشن استرینک شما صحیح است و به دیتابیس موردنظر دسترسی دارد
//			string connectionString = "your_connection_string_here";

//			// کوئری برای دریافت داده‌ها از دیتابیس
//			string query = "SELECT * FROM Table1 INNER JOIN Table2 INNER JOIN Table3"; // باید اینجا کوئری مناسب رو وارد کنید

//			// خواندن داده‌ها از دیتابیس
//			var allItems = ReadData<BaseItem>(connectionString, query);

//			// تبدیل داده‌ها به فایل جیسون
//			GenerateJson(allItems);
//		}

//		// تابع برای خواندن داده‌ها از دیتابیس و تبدیل به شیء مورد نظر
//		static List<T> ReadData<T>(string connectionString, string query) where T : new()
//		{
//			var data = new List<T>();

//			using (SqlConnection connection = new SqlConnection(connectionString))
//			{
//				SqlCommand command = new SqlCommand(query, connection);
//				connection.Open();

//				using (SqlDataReader reader = command.ExecuteReader())
//				{
//					while (reader.Read())
//					{
//						var item = new T();
//						foreach (var property in typeof(T).GetProperties())
//						{
//							if (reader[property.Name] != DBNull.Value)
//							{
//								property.SetValue(item, reader[property.Name]);
//							}
//						}
//						data.Add(item);
//					}
//				}
//			}
//			return data;
//		}

//		static void GenerateJson(List<BaseItem> allItems)
//		{
//			// در اینجا شما می‌توانید داده‌های دریافتی را به JSON تبدیل کنید
//			string output = JsonConvert.SerializeObject(allItems, Formatting.Indented);
//			File.WriteAllText("output.json", output);
//			Console.WriteLine("Data successfully written to output.json");
//		}
//	}
//}




//public void generateJson(string[] args)
//{
//	List<object> result = new List<object>();

//	DataTable data = new DataTable();

//	//create 4 columns
//	data.Columns.Add("col1", typeof(string));
//	data.Columns.Add("col2", typeof(string));
//	data.Columns.Add("col3", typeof(string));
//	data.Columns.Add("col4", typeof(string));

//	//create 7 rows
//	DataRow dr1 = data.NewRow();
//	dr1["col1"] = "Menu";
//	dr1["col2"] = "";
//	dr1["col3"] = "";
//	dr1["col4"] = "";
//	data.Rows.Add(dr1);

//	DataRow dr2 = data.NewRow();
//	dr2["col1"] = "Menu";
//	dr2["col2"] = "Menu";
//	dr2["col3"] = "";
//	dr2["col4"] = "";
//	data.Rows.Add(dr2);

//	DataRow dr3 = data.NewRow();
//	dr3["col1"] = "Menu";
//	dr3["col2"] = "Menu";
//	dr3["col3"] = "Menu";
//	dr3["col4"] = "";
//	data.Rows.Add(dr3);

//	DataRow dr4 = data.NewRow();
//	dr4["col1"] = "Menu";
//	dr4["col2"] = "Menu";
//	dr4["col3"] = "Menu";
//	dr4["col4"] = "Label";
//	data.Rows.Add(dr4);

//	DataRow dr5 = data.NewRow();
//	dr5["col1"] = "Menu";
//	dr5["col2"] = "Menu";
//	dr5["col3"] = "Menu";
//	dr5["col4"] = "Label";
//	data.Rows.Add(dr5);

//	DataRow dr6 = data.NewRow();
//	dr6["col1"] = "Menu";
//	dr6["col2"] = "Menu";
//	dr6["col3"] = "Menu";
//	dr6["col4"] = "Label";
//	data.Rows.Add(dr6);

//	DataRow dr7 = data.NewRow();
//	dr7["col1"] = "Menu";
//	dr7["col2"] = "Menu";
//	dr7["col3"] = "Menu";
//	dr7["col4"] = "Input";
//	data.Rows.Add(dr7);


//	foreach (DataRow row in data.Rows)
//	{
//		foreach (object col in data.Columns)
//		{


//			if (row["col1"] == "Menu")
//			{
//				MenuItem menuItem1 = new MenuItem();
//				menuItem1.ItemType = "MenuItem";
//				menuItem1.Visible = true;
//				menuItem1.Enable = true;
//				menuItem1.collection = new List<BaseItem>();

//				result.Add(menuItem1);


//				MenuItem menuItem2 = new MenuItem();
//				menuItem2.ItemType = "Menu";
//				menuItem2.Visible = true;
//				menuItem2.Enable = true;

//				InteractivePage clickPage = new InteractivePage();
//				clickPage.Items.Add("", menuItem2);

//				menuItem1.ClickPages.Add("", clickPage);
//			}
//			if (row["col4"] == "label")
//			{
//				LabelItem labelItem = new LabelItem();
//				labelItem.Type = "label";
//				//labelItem.Visible = true;
//				//labelItem.Enable = true;

//				result.Add(labelItem);
//			}
//		}
//	}

//		string output = JsonConvert.SerializeObject(result);
//		File.WriteAllText("output.txt", output);
//	}

//}









//read dataa class(from json)

//MenuItem menu = new MenuItem();
//menu.Text = "Apple";
//menu.IsVisible = false;

//string json = JsonConvert.SerializeObject(menu);


