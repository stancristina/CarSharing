using System.Collections.Generic;
using System.Linq;
using CarRentalServicesWebApp.DTOs;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Repositories.ShopRepository;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalServicesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public IShopRepository IShopRepository { get; set; }
        public ShopController(IShopRepository shopRepository)
        {
            IShopRepository = shopRepository;
        }

        // GET: api/Shop
        [HttpGet]
        public ActionResult<IEnumerable<ShopDTO>> Get()
        {
            return IShopRepository.GetAll().Select(x => new ShopDTO()
            {
                Id = x.Id,
                Name = x.Name,
                CityId = x.CityId
            }).ToList();
        }

        // GET: api/Shop/5
        [HttpGet("{id}", Name = "GetShop")]
        public ShopDTO Get(int id)
        {
            Shop shop = IShopRepository.Get(id);
            ShopDTO shopDTO = new ShopDTO()
            {
                Id = shop.Id,
                Name = shop.Name,
                CityId = shop.CityId
            };

            return shopDTO;
        }


        // POST: api/Shop
        [HttpPost]
        public void Post(ShopDTO value)
        {
            Shop model = new Shop()
            {
                Name = value.Name,
                CityId = value.CityId
            };

            IShopRepository.Create(model);
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public void Put(int id, ShopDTO value)
        {
            Shop model = IShopRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            if (value.CityId != 0)
            {
                model.CityId = value.CityId;
            }

            IShopRepository.Update(model);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Shop Delete(int id)
        {
            Shop shop = IShopRepository.Get(id);
            return IShopRepository.Delete(shop);
        }
    }
}
