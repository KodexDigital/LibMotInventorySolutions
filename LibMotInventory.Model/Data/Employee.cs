using LibMotInventory.Model.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotInventory.Model.Data
{
	public class Employee : IDBModel
	{
		public Guid Id { get; set; }
		public Guid EmployeeId { get; set; }
		public string InventoryNumber { get; set; }
		public DateTime DateCreated { get; set; }

		public Employee()
		{
			DateCreated = DateTime.Now;
		}
	}
}
