using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.DTOs;
using CarRentalServicesWebApp.Models;
using CarRentalServicesWebApp.Repositories.ClientRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalServicesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public IClientRepository IClientRepository { get; set; }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return IClientRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(string CNP)
        {
            return IClientRepository.Get(CNP);
        }

        // POST: api/Provider
        [HttpPost]
        public Client Post(ClientDTO value)
        {
            Client model = new Client()
            {
                CNP = value.CNP,
                LastName = value.LastName,
                FirstName = value.FirstName,
              
            };
            return IClientRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Client Put(string CNP, ClientDTO value)
        {
            Client model = IClientRepository.Get(CNP);
            if (value.CNP != null)
            {
                model.CNP = value.CNP;
            }
            if (value.LastName != null)
            {
                model.LastName = value.LastName;
            }
            if (value.FirstName != null)
            {
                model.FirstName = value.FirstName;
            }
            
            return IClientRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Client Delete(String CNP)
        {
            Client model = IClientRepository.Get(CNP);
            return IClientRepository.Delete(model);
        }
    }
}
