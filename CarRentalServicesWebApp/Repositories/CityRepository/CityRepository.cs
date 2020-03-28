using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Contexts;
using CarRentalServicesWebApp.Models;

namespace CarRentalServicesWebApp.Repositories.CityRepository
{
    public class CityRepository: ICityRepository
    {
        public Context _context { get; set; }
        public CityRepository(Context context)
        {
            _context = context;
        }
        public City Create(City city)
        {
            var result = _context.Add<City>(city);
            _context.SaveChanges();
            return result.Entity;
        }
        public City Get(int Id)
        {
            return _context.Cities.SingleOrDefault(x => x.Id == Id);
        }
        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }
        public City Update(City City)
        {
            _context.Entry(City).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return City;
        }
        public City Delete(City City)
        {
            var result = _context.Remove(City);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
