using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class AdvertiseGroup
{
	// دیکشنری برای ذخیره آیتم‌ها با کلیدهای مربوطه
	public Dictionary<string, Item> Items { get; set; } = new Dictionary<string, Item>();

	/// <summary>
	/// اضافه کردن یک آیتم به دیکشنری. اکر کلید تکراری باشد، یک استثنا پرتاب می‌شود.
	/// </summary>
	/// <param name="key">کلید برای آیتم جدید.</param>
	/// <param name="item">آیتمی که باید اضافه شود.</param>
	public void AddItem(string key, Item item)
	{
		if (!Items.ContainsKey(key))
		{
			Items[key] = item;
		}
		else
		{
			throw new ArgumentException($"An item with the key {key} already exists.");
		}
	}

	/// <summary>
	/// حذف یک آیتم از دیکشنری بر اساس کلید.
	/// </summary>
	/// <param name="key">کلید آیتمی که باید حذف شود.</param>
	/// <returns>برمی‌کرداند که آیا حذف موفقیت‌آمیز بود یا خیر.</returns>
	public bool RemoveItem(string key)
	{
		return Items.Remove(key);
	}

	/// <summary>
	/// بازیابی یک آیتم از دیکشنری بر اساس کلید.
	/// </summary>
	/// <param name="key">کلید آیتمی که باید بازیابی شود.</param>
	/// <returns>آیتم مربوطه یا null اکر وجود نداشته باشد.</returns>
	public Item GetItem(string key)
	{
		Items.TryGetValue(key, out Item item);
		return item;
	}

	/// <summary>
	/// نمایش اطلاعات کروه آکهی‌ها.
	/// </summary>
	/// <returns>رشته‌ای که شامل اطلاعات آیتم‌ها می‌باشد.</returns>
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("Advertise Group Items:");
		foreach (var item in Items)
		{
			sb.AppendLine($"{item.Key}: {item.Value}");
		}
		return sb.ToString();
	}
}
