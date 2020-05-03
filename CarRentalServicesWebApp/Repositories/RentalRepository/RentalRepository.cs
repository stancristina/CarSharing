using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Contexts;
using CarRentalServicesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalServicesWebApp.Repositories.RentalRepository
{
    public class RentalRepository:IRentalRepository
    {
        public Context _context { get; set; }
        public RentalRepository(Context context)
        {
            _context = context;
        }
        public Rental Create(Rental rental)
        {
            var result = _context.Add<Rental>(rental);
            _context.SaveChanges();
            return result.Entity;
        }
        public Rental Get(int Id)
        {
            return _context.Rentals.Include(p => p.Car).Include(p => p.Client).SingleOrDefault(x => x.Id == Id);
        }
        public List<Rental> GetAll()
        {
            return _context.Rentals.Include(p => p.Car).Include(p => p.Client).ToList();
        }
        public Rental Update(Rental Rental)
        {
            _context.Entry(Rental).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Rental;
        }
        public Rental Delete(Rental Rental)
        {
            var result = _context.Remove(Rental);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}