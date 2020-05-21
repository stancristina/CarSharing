using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Repositories.RentalRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRentalServicesWebApp.DTOs;
using CarRentalServicesWebApp.Models;
namespace CarRentalServicesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public IRentalRepository IRentalRepository { get; set; }

        public RentalController(IRentalRepository rentalRepository)
        {
            IRentalRepository = rentalRepository;
        }

        // GET: api/Rental
        [HttpGet]
        public ActionResult<IEnumerable<RentalDTO>> Get()
        {
            return IRentalRepository.GetAll().Select(x => new RentalDTO()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                Period = x.Period,
                ClientId = x.ClientId,
                ClientFirstName = x.Client?.FirstName,
                ClientLastName = x.Client?.LastName,
                CarId = x.CarId,
                CarModel = x.Car?.Model
            }).ToList();
        }

        // GET: api/Rental/5
        [HttpGet("{id}")]
        public ActionResult<RentalDTO> Get(int id)
        {
            Rental rental = IRentalRepository.Get(id);
            if (rental == null)
            {
                return new RentalDTO();
            }
            return new RentalDTO()
            {
                Id = rental.Id,
                StartDate = rental.StartDate,
                Period = rental.Period,
                ClientId = rental.ClientId,
                ClientFirstName = rental.Client?.FirstName,
                ClientLastName = rental.Client?.LastName,
                CarId = rental.CarId,
                CarModel = rental.Car?.Model
            };
        }

        // POST: api/Rental
        [HttpPost]
        public Rental Post(RentalDTO value)
        {
            Rental model = new Rental()
            {
                StartDate = value.dStartDate.ToString("dd-MM-yyyy"),
                Period=value.Period,
                ClientId=value.ClientId,
                CarId=value.CarId
            };
            return IRentalRepository.Create(model);
        }

        // PUT: api/Rental/5
        [HttpPut("{id}")]
        public Rental Put(int id, RentalDTO value)
        {
            Rental model = IRentalRepository.Get(id);
            if (value.dStartDate.ToString("dd-MM-yyyy") != null)
            {
                model.StartDate = value.dStartDate.ToString("dd-MM-yyyy");
            }
            if (value.Period != 0)
            {
                model.Period = value.Period;
            }
            if (value.ClientId != 0)
            {
                model.ClientId = value.ClientId;
            }
            if (value.CarId != 0)
            {
                model.CarId = value.CarId;
            }
            return IRentalRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Rental Delete(int id)
        {
            Rental model = IRentalRepository.Get(id);
            return IRentalRepository.Delete(model);
        }
    }
}
