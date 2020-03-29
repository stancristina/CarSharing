using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Models;

namespace CarRentalServicesWebApp.Repositories.ShopRepository
{
    public interface IShopRepository
    {
        List<Shop> GetAll();
        Shop Get(int Id);
        Shop Create(Shop Shop);
        Shop Update(Shop Shop);
        Shop Delete(Shop Shop);
    }
}
