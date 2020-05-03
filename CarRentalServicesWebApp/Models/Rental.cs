using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalServicesWebApp.Models
{
    public class Rental
    {
        public int Id { get; set; }       //poate inca un id unic aici? 
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public string StartDate { get; set; }
        public int Period { get; set; }

        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
    }
}
