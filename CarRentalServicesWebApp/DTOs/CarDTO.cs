using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs
{
	public class CarDTO
	{
		public string Model { get; set; }
		public int ShopId { get; set; }
		public List<int> RentalId { get; set; }

	}
}
