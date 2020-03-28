using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Contexts;

namespace CarRentalServicesWebApp.Repositories.ShopRepository
{
    public class ShopRepository:IShopRepository
    {
        public Context _context { get; set; }
        public ShopRepository(Context context)
        {
            _context = context;
        }
        public Shop Create(Shop shop)
        {
            var result = _context.Add<Shop>(shop);
            _context.SaveChanges();
            return result.Entity;
        }
        public Shop Get(int Id)
        {
            return _context.Shops.SingleOrDefault(x => x.Id == Id);
        }
        public List<Shop> GetAll()
        {
            return _context.Shops.ToList();
        }
        public Shop Update(Shop Shop)
        {
            _context.Entry(Shop).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Shop;
        }
        public Shop Delete(Shop Shop)
        {
            var result = _context.Remove(Shop);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
