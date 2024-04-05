using ASP.NET_WebApi.Entities;

namespace ASP.NET_WebApi.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>Creates the client.</summary>
        /// <param name="newClient">The new client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<Client> CreateClient(Client newClient);

        /// <summary>Gets all clients.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<IList<Client>> GetAllClients();

        /// <summary>Gets the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<Client> GetClientById(Guid id);

        /// <summary>Gets the name of the client by.</summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<IList<Client>> GetClientByName(string name);
        /// <summary>Updates the client by identifier.</summary>
        /// <param name="updateClient">The update client.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<Client> UpdateClientById(Client updateClient);

        /// <summary>Deletes the client by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<Client> DeleteClientById(Guid id);

    }
}
