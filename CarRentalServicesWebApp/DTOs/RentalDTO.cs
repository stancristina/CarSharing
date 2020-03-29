using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs

{
	public class RentalDTO
	{
		public string StartDate { get; set; }
		public string Period { get; set; }
		public int ClientId { get; set; }
		public int CarId { get; set; }
	}
}
