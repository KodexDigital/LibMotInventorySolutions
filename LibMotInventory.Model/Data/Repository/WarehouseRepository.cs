using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibMotInventory.Model.Data.Repository
{
	public class WarehouseRepository<T> : IWarehouseRepository<T> where T : class
	{
		private readonly ApplicationDBContext context;

		public WarehouseRepository(ApplicationDBContext context)
		{
			this.context = context;
		}

		public void Add(T entity)
		{
			context.Set<T>().Add(entity);
		}

		public async Task<T> SaveAsync(T entity)
		{
			await context.SaveChangesAsync();
			return entity;
		}
	}
}
