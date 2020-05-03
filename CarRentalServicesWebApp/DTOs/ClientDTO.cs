using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarRentalServicesWebApp.DTOs

{
	public class ClientDTO
	{
		public int Id { get; set; }
		public string CNP { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }

		public string Address { get; set; }
		
	}
}
