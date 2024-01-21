# Project: ASP.NET Web API

## Project Overview

This project is a basic ASP.NET Web API developed over a couple of days. It's built on .NET 8.0 and serves as a simple CRUD (Create, Read, Update, Delete) application. The main components include a `ClientController.cs` responsible for handling client-related requests and a corresponding `ClientRepository.cs` for data access operations.

## Technologies Used

- .NET 8.0
- ASP.NET Web API

## Project Structure

├── ASP.NET WebApi

│ ├── Controllers

    └── ClientController.cs

│ ├── Entities

    └── Client.cs

│ ├── Interfaces

    └── IApiDbContext.cs

    └── IClientRepository.cs

│ ├── Persistence

    └── ApiDbContext.cs

    └── DependencyInjection.cs

│ ├── Repositories

    └── ClientController.cs
## How to Run

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build and run the project.

## API Endpoints

- **POST /api/clients/CreateClient:** Create a new client.
- **GET /api/clients:** Retrieve a list of all clients.
- **GET /api/clients/{id}:** Retrieve details of a specific client by identifier.
- **GET /api/clients/{name}:** Retrieve details of a specific client by name.
- **PUT /api/clients/{id}:** Update details of an existing client.
- **DELETE /api/clients/{id}:** Delete a client.

# Project: Test Project

## Project Overview

This project serves as a testing suite for the ASP.NET Web API CRUD operations. It includes both positive (OK) and negative (KO) test cases to ensure the functionality and robustness of the API.

## Technologies Used

- NUnit (or your preferred testing framework)

## Project Structure

├── ASP.NET WebApiTests

│ ├── UnitTests

│ │ └── CreateClientTest.cs

│ │ └── DeleteClientByIdTest.cs

│ │ └── GetAllClientsTest.cs

│ │ └── GetClientByIdTest.cs

│ │ └── GetClientByNameTest.cs

│ │ └── UpdateClientByIdTest.cs

## How to Run Tests

1. Make sure your ASP.NET Web API project is running.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build and run the test project.

## Test Cases

### Positive Tests

- Verify successful client creation.
- Verify successful clients retrieval.
- Verify successful clients retrieval by identifier.
- Verify successful clients retrieval by name.
- Verify successful client update.
- Verify successful client deletion.

### Negative Tests

- Ensure appropriate handling of invalid input during client creation.
- Ensure appropriate handling of non-existent clients during retrieval.
- Ensure appropriate handling of non-existent clients during retrieval by identifier.
- Ensure appropriate handling of non-existent clients during retrieval by name.
- Ensure appropriate handling of invalid input during client update.
- Ensure appropriate handling of non-existent clients during deletion.
