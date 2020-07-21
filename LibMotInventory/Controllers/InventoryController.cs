using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMotInventory.Model.Data;
using LibMotInventory.Model.Data.Repository;
using LibMotInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibMotInventory.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly InventoryRepository<Inventory> inventory;

        public InventoryController(ApplicationDBContext _context, InventoryRepository<Inventory> inventory)
        {
            context = _context;
            this.inventory = inventory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateInventroy()
        {
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