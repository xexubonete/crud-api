using ASP.NET_WebApi.Controllers;
using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Persistence;
using ASP.NET_WebApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ASP.NET_WebApi.Tests.UnitTests;
public class GetAllClientsTest
{
    private ApiDbContext _context;

    private IClientService _clients;

    Client client = new Client()
    {
        Id = Guid.Parse("5a105781-ebb5-4dfd-a6c3-2727c20717a8"),
        Name = "Test",
        SurName = "One"
    };

    Client? nullClient;

    [SetUp]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        _context = new ApiDbContext(options);
        _clients = new ClientService();
    }

    [Test]
    public void Should_Get_All_Clients()
    {
        var clientController = new ClientController(_clients);

        var result = clientController.GetAllClients();

        Assert.IsNotNull(result);
    }

    [Test]
    public void Should_Get_All_Clients_Return_Bad_Request()
    {
        var clientController = new ClientController(_clients);

        var result = clientController.GetAllClients();

        AssertionRequestOptions.Equals(result, typeof(BadRequest));
    }
}