using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Models;

namespace CarRentalServicesWebApp.Repositories.CarRepository
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car Get(int Id);
        Car Create(Car Car);
        Car Update(Car Car);
        Car Delete(Car Car);
    }
}
