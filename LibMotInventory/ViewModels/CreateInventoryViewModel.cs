using LibMotInventory.Model.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibMotInventory.ViewModels
{
	public class CreateInventoryViewModel
	{
		public CreateInventoryViewModel()
		{

		}

		public CreateInventoryViewModel(Inventory inventory)
		{
			inventory.Id = Id;
			inventory.ItemName = ItemName;
			inventory.NumberOfItem = NumberOfItem;
			inventory.Cost = Cost;
			inventory.InventoryNumber = InventoryNumber;
			inventory.ItemDescription = ItemDescription;
			inventory.SerialNumber = SerialNumber;
			inventory.EstimatedValue = EstimatedValue;
			inventory.VendorLesser = VendorLesser;
		}

		public Guid Id { get; set; }
		[Required]
		[Display(Name ="Item name")]
		public string ItemName { get; set; }

		[Required]
		[Display(Name = "Number of items")]
		public int NumberOfItem { get; set; }

		[Required]
		[Display(Name = "Item cost")]
		public double Cost { get; set; }

		[Required]
		[Display(Name = "Inventory number")]
		public string InventoryNumber { get; set; }

		[Required]
		[Display(Name = "Item description")]
		public string ItemDescription { get; set; }

		[Required]
		[Display(Name = "Serial number")]
		public string SerialNumber { get; set; }

		[Required]
		[Display(Name = "Estimated value")]
		public double EstimatedValue { get; set; }

		[Required]
		[Display(Name = "Vendor or Lesser")]
		public string VendorLesser { get; set; }

	}
}
