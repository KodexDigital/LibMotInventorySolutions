using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMotInventory.Model.Data;
using LibMotInventory.Model.Data.Repository;
using LibMotInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;

namespace LibMotInventory.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly IInventoryRepository<Inventory> inventory;

        public InventoryController(ApplicationDBContext _context, IInventoryRepository<Inventory> inventory)
        {
            context = _context;
            this.inventory = inventory;
        }
        public async Task<IActionResult> Index()
        {
            return View(context.Inventories.OrderByDescending(p => p.Id).ToList());
        }

        public IActionResult CreateInventroy()
        {
            List<Warehouse> warehouseList = new List<Warehouse>();
            warehouseList = (from c in context.Warehouses select c).OrderBy(x => x.ItemName)
                            .ToList();
            warehouseList.Insert(0, new Warehouse 
            {
                Id = Guid.NewGuid(), 
                ItemName = "Select item" 
            });
            ViewBag.ItemName = warehouseList;

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateInventroy(CreateInventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newInventory = new Inventory
                {
                    ItemName = model.ItemName,
                    ItemDescription = model.ItemDescription,
                    InventoryNumber = model.InventoryNumber,
                    VendorLesser = model.VendorLesser,
                    Cost = model.Cost,
                    SerialNumber = model.SerialNumber,
                    EstimatedValue = model.EstimatedValue,
                    NumberOfItem = model.NumberOfItem
                };

                inventory.Add(newInventory);
                await inventory.SaveAsync(newInventory);
                ViewBag.Success = "New inventory created successfully";
                ModelState.Clear();
                return View(model);
            }

            return View();
        }
    }
}