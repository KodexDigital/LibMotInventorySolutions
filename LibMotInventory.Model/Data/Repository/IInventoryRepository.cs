using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibMotInventory.Model.Data.Repository
{
	public interface IInventoryRepository<T> where T: class
	{
		void Add(T entity);
		Task<T> SaveAsync(T entity);
	}
}
