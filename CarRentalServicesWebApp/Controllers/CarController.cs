using System.Collections.Generic;
using System.Linq;
using CarRentalServicesWebApp.DTOs;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Repositories.CarRepository;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalServicesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarRepository ICarRepository { get; set; }
        public CarController(ICarRepository carRepository)
        {
            ICarRepository = carRepository;
        }

        
        // GET: api/Car
        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> Get()
        {
            return ICarRepository.GetAll().Select(x => new CarDTO()
            {
                Id = x.Id,
                Model = x.Model,
                ShopId = x.ShopId
            }).ToList();
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "GetCar")]
        public CarDTO Get(int id)
        {
            Car car = ICarRepository.Get(id);
            if (car == null)
            {
                return new CarDTO();
            }
            CarDTO carDTO = new CarDTO()
            {
                Id = car.Id,
                Model = car.Model,
                ShopId = car.ShopId
            };

            return carDTO;
        }


        // POST: api/Car
        [HttpPost]
        public void Post(CarDTO value)
        {
            Car model = new Car()
            {
                Model = value.Model,
                ShopId = value.ShopId
            };

            ICarRepository.Create(model);
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, CarDTO value)
        {
            Car model = ICarRepository.Get(id);
            if (value.Model != null)
            {
                model.Model = value.Model;
            }

            if (value.ShopId != 0)
            {
                model.ShopId = value.ShopId;
            }
            

            ICarRepository.Update(model);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = ICarRepository.Get(id);
            return ICarRepository.Delete(car);
        }
        
    }
}
