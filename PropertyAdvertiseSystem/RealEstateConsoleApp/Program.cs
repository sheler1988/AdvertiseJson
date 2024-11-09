


using Newtonsoft.Json;
using RealEstateLibrary.Models;


//read dataa class(from json)

//MenuItem menu = new MenuItem();
//menu.Text = "Apple";
//menu.IsVisible = false;

//string json = JsonConvert.SerializeObject(menu);


// تعیین مسیر فایل JSON که می‌خواهید داده‌ها در آن ذخیره شوند
string filePath = "F:\\MyProjects\\AdvertiseJson\\PropertyAdvertiseSystem\\RealEstateConsoleApp\\resource\\template_AdvertiseGroup.json";

ReadData readData = new ReadData();
readData.ExportToJson(filePath);