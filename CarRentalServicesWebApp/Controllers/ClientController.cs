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

        public ClientController(IClientRepository clientRepository)
        {
            IClientRepository = clientRepository;
        }
        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<ClientDTO>> Get()
        {
            return IClientRepository.GetAll().Select(x => new ClientDTO()
            {
                Id = x.Id,
                CNP = x.CNP,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Address=x.Address
            }).ToList();

           
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int Id)
        {
            return IClientRepository.Get(Id);
        }

        // POST: api/Client
        [HttpPost]
        public Client Post(ClientDTO value)
        {
            Client model = new Client()
            {
                CNP = value.CNP,
                LastName = value.LastName,
                FirstName = value.FirstName,
                Address = value.Address
              
            };
            return IClientRepository.Create(model);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public Client Put(int Id, ClientDTO value)
        {
            Client model = IClientRepository.Get(Id);
            if (value.Id != 0)
            {
                model.Id = value.Id;
            }

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

            if (value.Address != null)
            {
                model.Address = value.Address;
            }

            return IClientRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Client Delete(int Id)
        {
            Client model = IClientRepository.Get(Id);
            return IClientRepository.Delete(model);
        }
    }
}
