using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs 
	{
	public class CityDTO
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public List<int> ShopId { get; set; }
	}
}
