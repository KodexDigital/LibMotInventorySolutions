using LibMotInventory.Model.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotInventory.Model.Data
{
	public class Warehouse : IDBModel
	{
		public Guid Id { get; set; }
		public string ItemName { get; set; }
		public int TotalInSotck { get; set; }
	}
}
