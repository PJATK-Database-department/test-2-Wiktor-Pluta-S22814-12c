using APBD_2Test_2.Context;
using APBD_2Test_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly SchoolDBContext context;
        private readonly IClientService clientService;

        public ClientController(SchoolDBContext _context, IClientService _clientService)
        {
            context = _context;
            clientService = _clientService;
        }

        [HttpGet("clientId")]
        public IActionResult GetClients(int clientId)
        {
            var client = context.Clients.Where(c => c.IdClient == clientId);

            var clients = context.Clients.Join(
                context.ClientOrders,
                clientOrder => clientOrder.IdClient,
                client => client.Client.IdClient,
                (client, order) => new
                {
                    IdClient = client.IdClient,
                    FirstName = client.FirstName,
                    Order = order.IdClientOrder
                });

            return Ok(clients);
        }


    }
}
