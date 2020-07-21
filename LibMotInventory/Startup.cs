using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMotInventory.DataAccessLayer;
using LibMotInventory.Model.Data;
using LibMotInventory.Model.Data.Repository;
using LibMotInventory.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibMotInventory
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString")));
			services.AddAuthentication();
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
			})
			.AddEntityFrameworkStores<ApplicationDBContext>()
			.AddDefaultTokenProviders();
			services.AddScoped(typeof(IInventoryRepository<>), typeof(InventoryRepository<>));
			services.AddScoped(typeof(IWarehouseRepository<>), typeof(WarehouseRepository<>));
			services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>));
			services.AddScoped(typeof(IdentityUser));
			services.AddScoped(typeof(BussinessLogics));

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Employee/Index";
				options.LogoutPath = $"/Employee/Logout";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
