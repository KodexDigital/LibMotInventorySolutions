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
    public class WarehouseController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly IWarehouseRepository<Warehouse> warehouse;

        public WarehouseController(ApplicationDBContext context, IWarehouseRepository<Warehouse> warehouse)
        {
            this.context = context;
            this.warehouse = warehouse;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewStock()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> NewStock(WarehouseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stock = new Warehouse
                {
                    ItemName = model.ItemName,
                    TotalInSotck = model.TotalInSotck
                };

                warehouse.Add(stock);
                await warehouse.SaveAsync(stock);
                ViewBag.Addded = "New stock added successfully";
                ModelState.Clear();
          
                return View(model);
            }
            return View();
        }
    }
}