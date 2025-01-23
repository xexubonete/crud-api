# CRUD API with ASP.NET Core

A simple REST API that implements CRUD (Create, Read, Update, Delete) operations using ASP.NET Core and Entity Framework Core.

## 🚀 Features

- Complete CRUD operations for Client entity
- Layered architecture (Controllers, Services, Repositories)
- Entity Framework Core with SQL Server
- Unit testing with xUnit and Moq
- API documentation with Swagger
- Dependency Injection

## 🛠️ Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- xUnit
- Moq
- MockQueryable
- Swagger/OpenAPI

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or SQL Server Express)
- Visual Studio 2022 or VS Code

## 🔧 Installation

1. Clone the repository
```
git clone https://github.com/xexubonete/crud-api.git
```
2. Open the solution in Visual Studio 2022 or VS Code
3. Restore NuGet packages
4. Run the application
```
dotnet run --project crud-api
```
## 🔍 Project Structure

```
├── LICENSE
├── README.md
├── crud-api
│   ├── ASP.NET WebApi.http
│   ├── Controllers
│   │   └── ClientController.cs
│   ├── Entities
│   │   └── Client.cs
│   ├── Interfaces
│   │   ├── IApiDbContext.cs
│   │   ├── IClientRepository.cs
│   │   └── IClientService.cs
│   ├── Persistence
│   │   ├── ApiDbContext.cs
│   │   └── DependencyInjection.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── Repositories
│   │   └── ClientRepository.cs
│   ├── Services
│   │   └── ClientService.cs
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   └── crud-api.csproj
├── crud-api.Test
│   ├── Controllers
│   │   └── ClientControllerTests.cs
│   ├── Repository
│   │   └── ClientRepositoryTests.cs
│   ├── Services
│   │   └── ClientServiceTests.cs
│   └── crud-api.Test.csproj
└── crud-api.sln
```

## 📝 API Endpoints

- `POST /Client/CreateClient` - Create new client
- `GET /Client` - Get all clients
- `GET /Client/{id}` - Get client by ID
- `GET /Client/{name}` - Get client by name
- `PUT /Client` - Update client
- `DELETE /Client/{id}` - Delete client

## 🧪 Testing

To run the tests:
```bash
dotnet test
```

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ✒️ Author

* **xexubonete** - *Initial Work* - [xexubonete](https://github.com/xexubonete)