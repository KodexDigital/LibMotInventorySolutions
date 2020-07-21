using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMotInventory.Model.Data;
using LibMotInventory.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibMotInventory.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IdentityUser user;
        private readonly UserManager<IdentityUser> userManager;

        public EmployeeController(ApplicationDBContext context, SignInManager<IdentityUser> signInManager, 
            IdentityUser user, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.user = user;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmployeeViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.EmployeeUserName, model.EmployeePassword, isPersistent: false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Inventory");

                }
              
                ViewBag.Error = "Invalid login attempt";
                ModelState.AddModelError(string.Empty, ViewBag.Error);

            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                user.Email = model.EmployeeUserName;
                user.UserName = model.EmployeeUserName;
                var result = await userManager.CreateAsync(user, model.EmployeePassword);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    TempData["UserId"] = user.Id;
                    return RedirectToAction("Index","Inventory");
                }
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errors.Description);
                    ViewBag.Error = "Error creating account";
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Inventory");
        }
    }
}