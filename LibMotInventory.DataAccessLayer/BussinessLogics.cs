using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotInventory.DataAccessLayer
{
	public class BussinessLogics
	{
		Random random = new Random();
		int numbers = 0123456789;
		public string  GenerateSerialNumber()
		{
			string serialNumber = random.Next(numbers).ToString();
			return serialNumber;
		}
	}
}
