using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Contexts;

namespace CarRentalServicesWebApp.Repositories.CarRepository
{
    public class CarRepository:ICarRepository
    {
        public Context _context { get; set; }
        public CarRepository(Context context)
        {
            _context = context;
        }
        public Car Create(Car car)
        {
            var result = _context.Add<Car>(car);
            _context.SaveChanges();
            return result.Entity;
        }
        public Car Get(int Id)
        {
            return _context.Cars.SingleOrDefault(x => x.Id == Id);
        }
        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
        public Car Update(Car Car)
        {
            _context.Entry(Car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Car;
        }
        public Car Delete(Car Car)
        {
            var result = _context.Remove(Car);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

