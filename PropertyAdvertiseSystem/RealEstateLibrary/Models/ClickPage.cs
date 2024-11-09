using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

/// <summary>
/// کلاس نماینده یک صفحه کلیک که می‌تواند شامل لیستی از آیتم‌ها باشد.
/// </summary>
public class ClickPage
{
	/// <summary>
	/// لیست آیتم‌هایی که در این صفحه وجود دارند.
	/// </summary>
	public List<Item> Items { get; set; } = new List<Item>();

	/// <summary>
	/// اضافه کردن یک آیتم به لیست آیتم‌ها.
	/// </summary>
	/// <param name="item">آیتمی که باید به لیست اضافه شود.</param>
	public void AddItem(Item item)
	{
		if (item == null)
		{
			throw new ArgumentNullException(nameof(item), "Item cannot be null.");
		}
		Items.Add(item);
	}

	/// <summary>
	/// حذف یک آیتم از لیست آیتم‌ها.
	/// </summary>
	/// <param name="item">آیتمی که باید حذف شود.</param>
	/// <returns>برمی‌کرداند که آیا حذف موفقیت‌آمیز بود یا خیر.</returns>
	public bool RemoveItem(Item item)
	{
		return Items.Remove(item);
	}
}
