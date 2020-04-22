using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalServicesWebApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string CNP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }

    }
}
