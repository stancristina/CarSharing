using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalServicesWebApp.Contexts;
using CarRentalServicesWebApp.Models;

namespace CarRentalServicesWebApp.Repositories.ClientRepository
{
    interface IClientRepository
    {
        List<Client> GetAll();
        Client Get(string CNP);
        Client Create(Client Client);
        Client Update(Client Client);
        Client Delete(Client Client);
    }
}
