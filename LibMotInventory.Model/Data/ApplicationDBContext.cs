using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotInventory.Model.Data
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }

	}
}
