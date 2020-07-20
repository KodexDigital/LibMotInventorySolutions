using LibMotInventory.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibMotInventory.ViewModels
{
	public class EmployeeViewModel
	{
		public EmployeeViewModel()
		{

		}

		public EmployeeViewModel(Employee employee)
		{
			employee.EmployeeId = EmployeeId;
			employee.InventoryNumber = InventoryNumber;
		}

		public Guid EmployeeId { get; set; }

		[Display(Name = "Inventoru number")]
		public string InventoryNumber { get; set; }
	}
}
