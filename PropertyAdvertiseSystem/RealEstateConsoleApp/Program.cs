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
				Text = "منوی اصلی املاک",
				Type = "RootMenu",
				ClickPage = new List<MenuItem>(),
			};


			// ساخت زیرمنوها
			MenuItem iteme1 = new MenuItem
			{
				Text = "اجاره مسکونی",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem iteme2 = new MenuItem
			{
				Text = "فروش مسکونی",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem iteme3 = new MenuItem
			{
				Text = "فروش اداری و تجاری",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem iteme4 = new MenuItem
			{
				Text = "اجاره اداری و تجاری",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem iteme5 = new MenuItem
			{
				Text = "اجاره کوتاه مدت",
				Type = "SubMenu",
				ClickPage = new List<MenuItem>(),
			};

			MenuItem iteme6 = new MenuItem
			{
				Text = "پروژه های ساخت و ساز",
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
				Text = "اجاره خانه و ویلا",
				Type = "InteractivePage",
			};

			MenuItem subItem3 = new MenuItem
			{
				Text = "فروش آپارتمان",
				Type = "InteractivePage"
			};

			MenuItem subItem4 = new MenuItem
			{
				Text = "فروش خانه و ویلا",
				Type = "InteractivePage"
			};

			MenuItem subItem5 = new MenuItem
			{
				Text = "فروش زمین کلنکی",
				Type = "InteractivePage"
			};

			MenuItem subItem6 = new MenuItem
			{
				Text = "فروش دفترکار؛ اتاق اداری و مطب",
				Type = "InteractivePage"
			};

			MenuItem subItem7 = new MenuItem
			{
				Text = "فروش مغازه و غرفه",
				Type = "InteractivePage"
			};

			MenuItem subItem8 = new MenuItem
			{
				Text = "فروش صنعتی؛ اتاق کشاورزی و تجاری",
				Type = "InteractivePage"
			};

			MenuItem subItem9 = new MenuItem
			{
				Text = "اجاره دفترکار؛ اتاق اداری و مطب",
				Type = "InteractivePage"
			};

			MenuItem subItem10 = new MenuItem
			{
				Text = "اجاره مغازه و غرفه",
				Type = "InteractivePage"
			};

			MenuItem subItem11 = new MenuItem
			{
				Text = "اجاره صنعتی؛ اتاق کشاورزی و تجاری",
				Type = "InteractivePage"
			};

			MenuItem subItem12 = new MenuItem
			{
				Text = "اجاره کوتاه مدت آپارتمان و سوئیت",
				Type = "InteractivePage"
			};

			MenuItem subItem13 = new MenuItem
			{
				Text = "اجاره کوتاه مدت ویلا و باغ ",
				Type = "InteractivePage"
			};

			MenuItem subItem14 = new MenuItem
			{
				Text = "اجاره کوتاه مدت دفترکار و فضای آموزشی",
				Type = "InteractivePage"
			};

			MenuItem subItem15 = new MenuItem
			{
				Text = "پروژه مشارکت در ساخت",
				Type = "InteractivePage"
			};

			MenuItem subItem16 = new MenuItem
			{
				Text = "پروژه پیش فروش",
				Type = "InteractivePage"
			};

			// اتصال آیتم‌ها به زیرمنوها
			iteme1.ClickPage?.Add(subItem1);
			iteme1?.ClickPage?.Add(subItem2);

			iteme2.ClickPage?.Add(subItem3);
			iteme2?.ClickPage?.Add(subItem4);
			iteme2?.ClickPage?.Add(subItem5);
			
			iteme3?.ClickPage?.Add(subItem6);
			iteme3?.ClickPage?.Add(subItem7);
			iteme3?.ClickPage?.Add(subItem8);

			iteme4?.ClickPage?.Add(subItem9);
			iteme4?.ClickPage?.Add(subItem10);
			iteme4?.ClickPage?.Add(subItem11);

			iteme5?.ClickPage?.Add(subItem12);
			iteme5?.ClickPage?.Add(subItem13);
			iteme5?.ClickPage?.Add(subItem14);

			iteme6?.ClickPage?.Add(subItem15);
			iteme6?.ClickPage?.Add(subItem16);


			// اتصال زیرمنوها به ریشه درخت
			root.ClickPage?.Add(iteme1);
			root.ClickPage?.Add(iteme2);
			root.ClickPage?.Add(iteme3);
			root.ClickPage?.Add(iteme4);
			root.ClickPage?.Add(iteme5);
			root.ClickPage?.Add(iteme6);

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

