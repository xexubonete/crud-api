using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Repositories;
using ASP.NET_WebApi.Services;
using Moq;

namespace crudapi.Tests.Services
{
    internal class ClientServiceTests
    {
        private readonly ClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepository;
        Client client;

        public ClientServiceTests()
        {
            _clientRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepository.Object);
            client = new Client()
            { 
                Id = Guid.NewGuid(),
                Name = "",
                SurName = ""
            };
        }

        [Test]
        public async Task CreateClient_ShouldReturnClient()
        {
            // Given
            _clientRepository.Setup(x => x.CreateClient(It.IsAny<Client>())).Returns(Task.FromResult<Client>);
            // When
            var result = await _clientService.CreateClient(new Client());
            // Then
            Assert.That(result, Is.Not.False);
        }
        [Test]
        public async Task GetAllClients_ShouldReturnClients()
        {
            // Given
            // When
            var result = await _clientService.GetAllClients();
            // Then
            Assert.That(result, Is.Not.False);
        } 
        [Test]
        public async Task GetClientById_ShouldReturnClient()
        {
            // Given
            _clientRepository.Setup(x => x.GetClientById(client.Id)).Returns(Task.FromResult<Client>);
            // When
            var result = await _clientService.GetClientById(It.IsAny<Guid>());
            // Then
            Assert.That(result, Is.Not.False);
        }
        [Test]
        public async Task GetClientByName_ShouldReturnClients()
        {
            // Given
            _clientRepository.Setup(x => x.GetClientByName(It.IsAny<string>())).Returns(Task.FromResult<IList<Client>>);
            // When
            var result = await _clientService.GetClientByName(It.IsAny<string>());
            // Then
            Assert.That(result, Is.Not.False);
        }
        [Test]
        public async Task UpdateClientById_ShouldReturnClient()
        {
            // Given
            _clientRepository.Setup(x => x.UpdateClientById(It.IsAny<Client>())).Returns(Task.FromResult<Client>);
            // When
            var result = await _clientService.UpdateClientById(new Client());
            // Then
            Assert.That(result, Is.Not.False);
        }
        [Test]
        public async Task DeleteClientById_ShouldReturnClient()
        {
            // Given
            _clientRepository.Setup(x => x.DeleteClientById(client.Id)).Returns(Task.FromResult<Client>);
            // When
            var result = await _clientService.DeleteClientById(It.IsAny<Guid>());
            // Then
            Assert.That(result, Is.Not.False);
        }
    }
}
