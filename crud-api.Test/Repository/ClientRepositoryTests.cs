using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace crudapi.Tests.Repository
{
    public class ClientRepositoryTests
    {
        Mock<IApiDbContext> contextMock;
        ClientRepository clientRepository;
        Mock<DbSet<Client>> dbClients;
        Client client;
        List<Client> clients;
        public ClientRepositoryTests()
        {
            contextMock = new Mock<IApiDbContext>();
            dbClients = new Mock<DbSet<Client>>();
            contextMock.Setup(x => x.Clients).Returns(dbClients.Object);
            clientRepository = new ClientRepository(contextMock.Object);
            client = new Client
            {
                Id = Guid.Empty,
                Name = String.Empty,
                SurName = String.Empty
            };
            clients = new List<Client> { client };
        }
        [Fact]
        public async void ClientRepository_CreateClient_Should_Return_New_Client()
        {
            // Given
            contextMock.Setup(x => x.Clients.Add(It.IsAny<Client>()));
            // When
            var result = await clientRepository.CreateClient(client);
            // Then
            Assert.IsType<Client>(result);
        }
        [Fact]
        public async void ClientRepository_CreateClient_Should_Throw_New_Exception()
        {
            // Given
            contextMock.Setup(x => x.Clients.Add(It.IsAny<Client>())).Throws(It.IsAny<Exception>);
            // When
            var exception = await Assert.ThrowsAsync<Exception>(async () => await clientRepository.CreateClient(client));
            // Then
            Assert.Equal("", exception.Message);
        }
        [Fact]
        public async void ClientRepository_GetAllClients_Should_Return_All_Clients()
        {
            // Given
            contextMock.Setup(x => x.Clients).Returns(dbClients.Object);
            // When
            var result = await clientRepository.GetAllClients();
            // Then
            Assert.NotNull(result);
        }
    }
}