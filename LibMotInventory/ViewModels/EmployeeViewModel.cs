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

		[Display(Name = "Inventory number")]
		public string InventoryNumber { get; set; }
		
		[Required]
		[EmailAddress]
		[Display(Name = "Username")]
		public string EmployeeUserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string EmployeePassword { get; set; }
	}
}
