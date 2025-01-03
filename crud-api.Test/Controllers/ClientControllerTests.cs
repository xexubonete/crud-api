using ASP.NET_WebApi.Controllers;
using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace crudapi.Tests.Controllers
{
    public class ClientControllerTests
    {
        Mock<IClientService> clientServiceMock;
        ClientController clientController;
        Client clientTest;
        Client? clientTestEmpty;
        IList<Client> clientsTest;
        IList<Client>? clientsTestEmpty;

        public ClientControllerTests()
        {
            clientServiceMock = new Mock<IClientService>();
            clientController = new ClientController(clientServiceMock.Object);

            clientTest = new Client 
            {
                Id = Guid.NewGuid(),
                Name = "NameTest",
                SurName = "SurnameTest"
            };
            clientsTest = new List<Client> { clientTest };
            clientsTestEmpty = new List<Client> { };

        }
        [Fact]
        public async void ClientController_CreateClient_Should_Return_Ok()
        {
            // Given
            clientServiceMock.Setup(x => x.CreateClient(It.IsAny<Client>())).Returns((Client client) => Task.FromResult(client));
            // When
            var result = await clientController.CreateClient(clientTest);
            // Then
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ClientController_CreateClient_Should_Return_BadRequest()
        {
            // Given
            clientServiceMock.Setup(x => x.CreateClient(It.IsAny<Client>())).Returns((Client client) => Task.FromResult(client));
            // When
            var result = await clientController.CreateClient(clientTestEmpty);
            // Then
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async void ClientController_GetAllClients_Should_Return_All_Clients()
        {
            // Given
            clientServiceMock.Setup(x => x.GetAllClients()).Returns(() => Task.FromResult(clientsTest));
            // When
            var result = await clientController.GetAllClients();
            // Then
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public async void ClientController_GetAllClients_Should_Return_NotFound()
        {
            // Given
            clientServiceMock.Setup(x => x.GetAllClients()).Returns(() => Task.FromResult<IList<Client>>(clientsTestEmpty));
            // When
            var result = await clientController.GetAllClients();
            // Then
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public async void ClientController_GetClientById_Should_Return_Client_By_Id()
        {
            // Given
            clientServiceMock.Setup(x => x.GetClientById(It.IsAny<Guid>())).Returns(() => Task.FromResult(clientTest));
            // When
            var result = await clientController.GetClientById(clientTest.Id);
            // Then
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ClientController_GetClientById_Should_Return_NotFound()
        {
            // Given
            clientServiceMock.Setup(x => x.GetClientById(It.IsAny<Guid>())).Returns(() => Task.FromResult(clientTestEmpty));
            // When
            var result = await clientController.GetClientById(clientTest.Id);
            // Then
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async void ClientController_GetClientByName_Should_Return_Client_By_Name()
        {
            // Given
            clientServiceMock.Setup(x => x.GetClientByName(It.IsAny<string>())).Returns(() => Task.FromResult(clientsTest));
            // When
            var result = await clientController.GetClientByName(It.IsAny<string>());
            // Then
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ClientController_GetClientByName_Should_Return_NotFound()
        {
            // Given
            clientServiceMock.Setup(x => x.GetClientByName(It.IsAny<string>())).Returns(() => Task.FromResult(clientsTestEmpty));
            // When
            var result = await clientController.GetClientByName(It.IsAny<string>());
            // Then
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async void ClientController_UpdateClient_Should_Return_Updated_Client()
        {
            // Given
            clientServiceMock.Setup(x => x.UpdateClientById(It.IsAny<Client>())).Returns(() => Task.FromResult(clientTest));
            // When
            var result = await clientController.UpdateClient(It.IsAny<Client>());
            // Then
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ClientController_UpdateClient_Should_Return_NotFound()
        {
            // Given
            clientServiceMock.Setup(x => x.UpdateClientById(It.IsAny<Client>())).Returns(() => Task.FromResult(clientTestEmpty));
            // When
            var result = await clientController.UpdateClient(It.IsAny<Client>());
            // Then
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async void ClientController_DeleteClientById_Should_Return_Deleted_Client()
        {
            // Given
            clientServiceMock.Setup(x => x.DeleteClientById(It.IsAny<Guid>())).Returns(() => Task.FromResult(clientTest));
            // When
            var result = await clientController.DeleteClientById(It.IsAny<Guid>());
            // Then
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ClientController_DeleteClient_Should_Return_NotFound()
        {
            // Given
            clientServiceMock.Setup(x => x.DeleteClientById(It.IsAny<Guid>())).Returns(() => Task.FromResult(clientTestEmpty));
            // When
            var result = await clientController.DeleteClientById(It.IsAny<Guid>());
            // Then
            Assert.IsType<NotFoundResult>(result);
        }
    }
}