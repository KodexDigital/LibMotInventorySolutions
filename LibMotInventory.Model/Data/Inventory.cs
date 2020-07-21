using LibMotInventory.Model.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotInventory.Model.Data
{
	public class Inventory : IDBModel
	{
		public Guid Id { get; set; }
		public string ItemName { get; set; }
		public int NumberOfItem { get; set; }
		public double Cost { get; set; }
		public string InventoryNumber { get; set; }
		public string ItemDescription { get; set; }
		public string SerialNumber { get; set; }
		public double EstimatedValue { get; set; }
		public string VendorLesser { get; set; }
		public DateTime DateAquired { get; set; }

		public Inventory()
		{
			DateAquired = DateTime.Now;
		}

	}
}
