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
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Rental>> Get()
        {
            return IRentalRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Rental> Get(int id)
        {
            return IRentalRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Rental Post(RentalDTO value)
        {
            Rental model = new Rental()
            {
                StartDate = value.StartDate,
                Period=value.Period,
                ClientId=value.ClientId,
                CarId=value.CarId
            };
            return IRentalRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Rental Put(int id, RentalDTO value)
        {
            Rental model = IRentalRepository.Get(id);
            if (value.StartDate != null)
            {
                model.StartDate = value.StartDate;
            }
            if (value.Period != null)
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
