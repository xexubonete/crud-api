using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clients;
        public ClientController(IClientRepository clients)
        {
            _clients = clients;
        }

        /// <summary>Creates the client.</summary>
        /// <param name="client">The client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateClient(Client client)
        {
            var result = await _clients.CreateClient(client);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        /// <summary>Gets all clients.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<Client>> GetAllClients() 
        {
            var clients = await _clients.GetAllClients();

            if (clients.Count() == 0)
            {
                return BadRequest();
            }

            return Ok(clients);
        }

        /// <summary>Gets the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetClientById(Guid id) 
        {
            var client = await _clients.GetClientById(id);

            if (client == null)
            {
                return BadRequest();
            }

            return Ok(client);
        }

        /// <summary>Gets the name of the client by.</summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        [Route("{Name}")]
        public async Task<IActionResult> GetClientByName(string name) 
        {
            var client = await _clients.GetClientByName(name);

            if (client.Count() == 0)
            {
                return BadRequest();
            }

            return Ok(client);
        }

        /// <summary>Updates the client.</summary>
        /// <param name="updateClient">The update client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateClient(Client updateClient) 
        {
            var client = await _clients.UpdateClientById(updateClient);

            if (client == null)
            {
                return BadRequest();
            }

            return Ok(client);
        }

        /// <summary>Deletes the client.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClient(Guid id) 
        {
            var client = await _clients.DeleteClientById(id);

            if (client == null)
            {
                return BadRequest();
            }

            return Ok(client);
        }
    }
}
