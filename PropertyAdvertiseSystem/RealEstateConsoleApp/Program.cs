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
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// ساخت ریشه درخت
			MenuItem root = new MenuItem
			{
				Text = "منوی اصلی",
				Type = "RootMenu",
				ClickPage = new List<MenuItem>(),
			};


			// ساخت زیرمنوها
			MenuItem iteme1 = new MenuItem
			{
				Text = "اجاره",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem item2 = new MenuItem
			{
				Text = "فروش",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			// اضافه کردن آیتم‌های داخل زیرمنوها
			MenuItem subItem1 = new MenuItem
			{
				Text = "اجاره آپارتمان",
				Type = "InteractivePage",
			};

			MenuItem subItem2 = new MenuItem
			{
				Text = "فروش ویلا",
				Type = "InterzctivePage"
			};

			// اتصال آیتم‌ها به زیرمنوها
			iteme1.ClickPage?.Add(subItem1);
			item2.ClickPage?.Add(subItem2);

			// اتصال زیرمنوها به ریشه درخت
			root.ClickPage?.Add(iteme1);
			root.ClickPage?.Add(item2);

			// LabaleIteme اضافه کردن
			LabelItem label = new LabelItem
			{
				Text = "ویژه",
				Color = "Red",
				FontStyle = "Bold",
			};

			//
			MenuItem labelAsMenuItem = new MenuItem
			{
				Text = label.Text,
				Type = "LabelItem",
				ClickPage = new List<MenuItem>(),
			};
			
			// 
			root.ClickPage?.Add(labelAsMenuItem);

			DisplayTree(root, 0);
		}

		/// <summary>
		/// متد بازکشتی برای نمایش ساختار درختی
		/// </summary>
		public static void DisplayTree(MenuItem item, int level)
		{
			string indent = new string(' ', level * 4);
			Console.WriteLine($"{indent}- {item.Text} ({item.Type})");

			if (item.ClickPage != null)
			{
				foreach (var child in item.ClickPage)
				{
					DisplayTree(child, level + 1);
				}
			}
		}
	}

}


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

