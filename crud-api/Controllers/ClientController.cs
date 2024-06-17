using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController(IClientService clients) : Controller
    {
        private readonly IClientService _clientService = clients;

        /// <summary>Creates the client.</summary>
        /// <param name="client">The client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateClient([FromBody]Client client)
        {
            var result = await _clientService.CreateClient(client);

            if (result == null)
            {
                return BadRequest("Cannot create a client");
            }

            return Ok(result);
        }

        /// <summary>Gets all clients.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IList<Client>>> GetAllClients() 
        {
            var clients = await _clientService.GetAllClients();

            if (!clients.Any())
            {
                return NotFound();
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
            var client = await _clientService.GetClientById(id);

            if (client == null)
            {
                return NotFound();
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
            var client = await _clientService.GetClientByName(name);

            if (!client.Any())
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>Updates the client.</summary>
        /// <param name="updateClient">The update client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody]Client updateClient) 
        {
            var client = await _clientService.UpdateClientById(updateClient);

            if (client == null)
            {
                return NotFound();
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
        public async Task<IActionResult> DeleteClientById(Guid id) 
        {
            var client = await _clientService.DeleteClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}
