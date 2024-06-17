using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;

namespace ASP.NET_WebApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Client> CreateClient(Client newClient)
        {
            return await _repository.CreateClient(newClient);
        }

        public async Task<Client> DeleteClientById(Guid id)
        {
            return await _repository.DeleteClientById(id);
        }

        public async Task<IList<Client>> GetAllClients()
        {
            return await _repository.GetAllClients();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _repository.GetClientById(id);
        }

        public async Task<IList<Client>> GetClientByName(string name)
        {
            return await _repository.GetClientByName(name);
        }

        public Task<Client> UpdateClientById(Client updateClient)
        {
            return _repository.UpdateClientById(updateClient);
        }
    }
}
