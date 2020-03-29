using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs
{
	public class ShopDTO
	{
		public string Name { get; set; }
		public int CityId { get; set; }
		public List<int> CarId { get; set; }

	}
}
