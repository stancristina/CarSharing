﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalServicesWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int ShopId { get; set; }
    }
}
