using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Services;
using Moq;

namespace crudapi.Tests.Services
{
    public class ClientServiceTests
    {
        private ClientService? clientService;
        private readonly Mock<IClientRepository> clientRepositoryMock;
        Client client;
        IList<Client> clients;
        
        public ClientServiceTests()
        {
            clientRepositoryMock = new Mock<IClientRepository>();
            client = new Client()
            { 
                Id = Guid.NewGuid(),
                Name = "NameTest",
                SurName = "SurnameTest"
            };
            clients = new List<Client> { client };
        }

        [Fact]
        public async void ClientService_CreateClient_Should_Return_New_Client()
        {
            // Given
            clientRepositoryMock.Setup(x => x.CreateClient(It.IsAny<Client>()))
                                  .Returns((Client client) => Task.FromResult(client));
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            var result = await clientService.CreateClient(client);
            // Then
            clientRepositoryMock.Verify(x => x.CreateClient(It.IsAny<Client>()));
        }

        [Fact]
        public async void ClientService_GetAllClients_Should_Return_All_Clients()
        {
            // Given
            clientRepositoryMock.Setup(x => x.GetAllClients()).Returns(() => Task.FromResult(clients));
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            await clientService.GetAllClients();
            // Then
            clientRepositoryMock.Verify(x => x.GetAllClients());
        }

        [Fact]
        public async void ClientService_GetClientById_Should_Return_Client_By_Id()
        {
            // Given
            clientRepositoryMock.Setup(x => x.GetClientById(client.Id)).Returns((Guid id) => Task.FromResult(client));
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            var result = await clientService.GetClientById(client.Id);
            // Then
            clientRepositoryMock.Verify(x => x.GetClientById(It.IsAny<Guid>()));
        }

        [Fact]
        public async void ClientService_GetClientByName_Should_Return_Client_By_Name()
        {
            // Given
            clientRepositoryMock.Setup(x => x.GetClientByName(It.IsAny<string>())).Returns((string name) => Task.FromResult(clients));
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            var result = await clientService.GetClientByName(It.IsAny<string>());
            // Then
            clientRepositoryMock.Verify(x => x.GetClientByName(It.IsAny<string>()));
        }

        [Fact]
        public async void ClientService_UpdateClientById_Should_Return_Updated_Client()
        {
            // Given
            clientRepositoryMock.Setup(x => x.UpdateClientById(It.IsAny<Client>())).Returns(Task.FromResult<Client>);
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            await clientService.UpdateClientById(client);
            // Then
            clientRepositoryMock.Verify(x => x.UpdateClientById(It.IsAny<Client>()));
        }

        [Fact]
        public async void ClientService_DeleteClientById_Should_Return_Deleted_Client()
        {
            // Given
            clientRepositoryMock.Setup(x => x.DeleteClientById(client.Id)).Returns((Guid id) => Task.FromResult(client));
            clientService = new ClientService(clientRepositoryMock.Object);

            // When
            await clientService.DeleteClientById(client.Id);
            // Then
            clientRepositoryMock.Verify(x => x.DeleteClientById(It.IsAny<Guid>()));
        }
    }
}
