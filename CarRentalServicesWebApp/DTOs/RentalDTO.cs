using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs

{
	public class RentalDTO
	{
		public int Id { get; set; }
		public string StartDate { get; set; }

		public DateTime dStartDate { get; set; }

		public int Period { get; set; }
		public int ClientId { get; set; }
		public int CarId { get; set; }
		public String CarModel { get; set; }
		public String ClientFirstName { get; set; }
		public String ClientLastName { get; set; }
	}
}
