using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Repositories;

namespace ASP.NET_WebApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Task<Client> CreateClient(Client newClient)
        {
            return _repository.CreateClient(newClient);
        }

        public Task<Client> DeleteClientById(Guid id)
        {
            return _repository.DeleteClientById(id);
        }

        public Task<IList<Client>> GetAllClients()
        {
            return _repository.GetAllClients();
        }

        public Task<Client> GetClientById(Guid id)
        {
            return _repository.GetClientById(id);
        }

        public Task<IList<Client>> GetClientByName(string name)
        {
            return _repository.GetClientByName(name);
        }

        public Task<Client> UpdateClientById(Client updateClient)
        {
            return _repository.UpdateClientById(updateClient);
        }
    }
}
