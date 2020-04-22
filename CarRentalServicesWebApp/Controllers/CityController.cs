using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.DTOs;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Repositories.CityRepository;
using CarRentalServicesWebApp.Repositories.ShopRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalServicesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public ICityRepository ICityRepository { get; set; }
        public CityController(ICityRepository cityRepository)
        {
            ICityRepository = cityRepository;
        }

        // GET: api/City
        [HttpGet]
        public ActionResult<IEnumerable<CityDTO>> Get()
        {
            return ICityRepository.GetAll().Select(x => new CityDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            }).ToList();
        }

        // GET: api/City/5
        [HttpGet("{id}", Name = "GetCity")]
        public CityDTO Get(int id)
        {
            City City = ICityRepository.Get(id);
            CityDTO cityDTO = new CityDTO()
            {
                Id = City.Id,
                Name = City.Name,
                Country = City.Country
            };

            return cityDTO;
        }


        // POST: api/City
        [HttpPost]
        public void Post(CityDTO value)
        {
            City model = new City()
            {
                Name = value.Name,
                Country = value.Country
            };

            ICityRepository.Create(model);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(int id, CityDTO value)
        {
            City model = ICityRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            if (value.Country != null)
            {
                model.Country = value.Country;
            }

            ICityRepository.Update(model);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public City Delete(int id)
        {
            City city = ICityRepository.Get(id);
            return ICityRepository.Delete(city);
        }
    }
}
