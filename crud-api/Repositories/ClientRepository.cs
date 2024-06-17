using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace ASP.NET_WebApi.Repositories
{
    public class ClientRepository(IApiDbContext context) : IClientRepository
    {
        private readonly IApiDbContext _context = context;
        
        /// <summary>Creates the client.</summary>
        /// <param name="newClient">The new client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> CreateClient(Client newClient)
        {
            try
            {
                var client = new Client();

                client.Id = Guid.NewGuid();
                client.Name = newClient.Name;
                client.SurName = newClient.SurName;

                _context.Clients.Add(client);

                await _context.SaveChangesAsync();

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>Gets all clients.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IList<Client>> GetAllClients()
        {
            try
            {
                IList<Client> clients = await _context.Clients.ToListAsync();

                if (clients == null)
                {
                    throw new NotFoundException(nameof(clients));
                }

                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>Gets the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> GetClientById(Guid id)
        {
            try
            {
                Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

                if (client == null)
                {
                    throw new NotFoundException(nameof(client));
                }

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>Gets the name of the client by.</summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IList<Client>> GetClientByName(string name)
        {
            try
            {
                IList<Client> client = await _context.Clients.Where(x => x.Name == name).ToListAsync();

                if (client == null)
                {
                    throw new NotFoundException(nameof(client));
                }

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>Updates the client by identifier.</summary>
        /// <param name="updateClient">The update client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> UpdateClientById (Client updateClient)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>Deletes the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Client> DeleteClientById(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
