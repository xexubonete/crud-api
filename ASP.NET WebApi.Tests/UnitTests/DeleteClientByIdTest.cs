using ASP.NET_WebApi.Controllers;
using ASP.NET_WebApi.Entities;
using ASP.NET_WebApi.Interfaces;
using ASP.NET_WebApi.Persistence;
using ASP.NET_WebApi.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ASP.NET_WebApi.Tests.UnitTests;
public class DeleteClientByIdTest
{
    private ApiDbContext _context;

    private IClientRepository _clients;

    Client client = new Client()
    {
        Id = Guid.Parse("5a105781-ebb5-4dfd-a6c3-2727c20717a8"),
        Name = "Test",
        SurName = "One"
    };

    Client? nullClient = new Client()
    {
        Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
        Name = null,
        SurName = null
    };

    [SetUp]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        _context = new ApiDbContext(options);
        _clients = new ClientRepository(_context);
    }

    [Test]
    public void Should_Delete_Client_ById()
    {
        var clientController = new ClientController(_clients);

        var result = clientController.DeleteClient(client.Id);

        Assert.IsNotNull(result);
    }

    [Test]
    public void Should_Delete_Client_ById_Return_Bad_Request()
    {
        var clientController = new ClientController(_clients);

        var result = clientController.DeleteClient(nullClient.Id);

        AssertionRequestOptions.Equals(result, typeof(BadRequest));
    }
}