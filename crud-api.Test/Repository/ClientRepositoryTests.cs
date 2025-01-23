using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Repositories;
using MockQueryable.Moq;
using Moq;

namespace crudapi.Tests.Repository
{
    public class ClientRepositoryTests
    {
        Mock<IApiDbContext> contextMock;
        ClientRepository clientRepository;
        Client client;
        List<Client> clients;

        public ClientRepositoryTests()
        {
            contextMock = new Mock<IApiDbContext>();
            client = new Client
            {
                Id = Guid.Empty,
                Name = String.Empty,
                SurName = String.Empty
            };
            clients = new List<Client> { client };

            var mockDbSet = clients.AsQueryable().BuildMockDbSet();
            contextMock.Setup(x => x.Clients).Returns(mockDbSet.Object);
            clientRepository = new ClientRepository(contextMock.Object);
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
        public async Task ClientRepository_GetAllClients_Should_Return_All_Clients()
        {
            // When
            var result = await clientRepository.GetAllClients();

            // Then
            Assert.NotNull(result);
            Assert.Single(result);
        }
        [Fact]
        public async Task ClientRepository_GetAllClients_Should_Throws_A_SystemException()
        {
            // Given
            contextMock.Setup(x => x.Clients).Throws(new Exception("Database error"));

            // When & Then
            await Assert.ThrowsAsync<Exception>(() => clientRepository.GetAllClients());
        }
        [Fact]
        public async Task ClientRepository_GetAllClients_Should_Return_Empty_List()
        {
            // Given
            var emptyList = new List<Client>();
            var mockEmptyDbSet = emptyList.AsQueryable().BuildMockDbSet();
            contextMock.Setup(x => x.Clients).Returns(mockEmptyDbSet.Object);

            // When
            var result = await clientRepository.GetAllClients();

            // Then
            Assert.Empty(result);
        }
    }
}