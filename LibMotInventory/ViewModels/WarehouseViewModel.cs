using LibMotInventory.Model.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibMotInventory.ViewModels
{
	public class WarehouseViewModel
	{
		public WarehouseViewModel()
		{

		}

		public WarehouseViewModel(Warehouse warehouse)
		{
			warehouse.ItemName = ItemName;
			warehouse.TotalInSotck = TotalInSotck;
		}

		[Display(Name ="Item name")]
		public string ItemName { get; set; }

		[Display(Name = "Total in stock")]
		public int TotalInSotck { get; set; }
	}
}
