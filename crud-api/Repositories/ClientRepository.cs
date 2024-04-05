using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenQA.Selenium;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_WebApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IApiDbContext _context;
        public ClientRepository(IApiDbContext context) 
        {
            _context = context;
        }

        /// <summary>Creates the client.</summary>
        /// <param name="newClient">The new client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> CreateClient(Client newClient)
        {
            var client = new Client();

            client.Id = Guid.NewGuid();
            client.Name = newClient.Name;
            client.SurName = newClient.SurName;

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        /// <summary>Gets all clients.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IList<Client>> GetAllClients()
        {
            IList<Client> clients = await _context.Clients.ToListAsync();

            if (clients == null)
            {
                throw new NotFoundException(nameof(clients));
            }

            return clients;
        }

        /// <summary>Gets the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> GetClientById(Guid id)
        {
            Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null) 
            { 
                throw new NotFoundException(nameof(client)); 
            }

            return client;
        }

        /// <summary>Gets the name of the client by.</summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IList<Client>> GetClientByName(string name)
        {
            IList<Client> client = await _context.Clients.Where(x => x.Name == name).ToListAsync();

            if (client == null)
            {
                throw new NotFoundException(nameof(client));
            }

            return client;
        }

        /// <summary>Updates the client by identifier.</summary>
        /// <param name="updateClient">The update client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> UpdateClientById (Client updateClient)
        {
            Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == updateClient.Id);

            if (client == null)
            {
                throw new NotFoundException(nameof(client));
            }

            client.Name = updateClient.Name;
            client.SurName = updateClient.SurName;

            _context.Clients.Update(client);

            await _context.SaveChangesAsync();

            return client;
        }

        /// <summary>Deletes the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> DeleteClientById(Guid id)
        {
            Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null)
            {
                throw new NotFoundException(nameof(client));
            }

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();

            return client;
        }
    }
}
