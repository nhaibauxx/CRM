# CRM System

A Customer Relationship Management (CRM) system built with .NET 6 following Clean Architecture principles.

## Project Structure

```
CRM/
│
├── CRM.API/                     # Entry point - expose REST API
│   ├── Controllers/             # API controllers
│   ├── Program.cs               # App builder & middleware
│   └── appsettings.json        # Configuration & connection strings
│
├── CRM.Application/            # Business logic & service layer
│   ├── Interfaces/             # Service interfaces
│   └── Services/               # Service implementations
│
├── CRM.Infrastructure/         # Data access & EF Core
│   ├── DbContext/              # EF DbContext & configuration
│   └── Repositories/           # Data access logic
│
└── CRM.Domain/                # Core domain: models & DTOs
    ├── Entities/              # EF Core entities
    ├── DTOs/                  # ViewModels and request/response types
    └── Enums/                 # Shared enums
```

## Technology Stack

- .NET 6
- ASP.NET Core 6
- Entity Framework Core 6
- SQL Server
- Swagger/OpenAPI
- JWT Authentication

## Setup Instructions

1. Prerequisites:
   - .NET 6 SDK
   - SQL Server
   - Visual Studio 2022 or VS Code

2. Clone the repository:
   ```bash
   git clone [repository-url]
   cd CRM
   ```

3. Update database connection string in `CRM.API/appsettings.json`

4. Run migrations:
   ```bash
   cd CRM.API
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

6. Access Swagger UI:
   ```
   https://localhost:5001/swagger
   ```

## Architecture

This project follows Clean Architecture principles with the following layers:

1. **Domain Layer** (CRM.Domain)
   - Contains enterprise logic and types
   - No dependencies on other layers or external libraries

2. **Application Layer** (CRM.Application)
   - Contains business logic
   - Depends on Domain layer
   - No dependencies on Infrastructure

3. **Infrastructure Layer** (CRM.Infrastructure)
   - Contains data access and external service implementations
   - Depends on Domain and Application layers

4. **API Layer** (CRM.API)
   - Contains controllers and configuration
   - Depends on all other layers

## Development Guidelines

- Follow Microsoft C# coding conventions
- Use async/await for I/O operations
- Implement proper exception handling
- Write unit tests for business logic
- Document public APIs
- Use dependency injection 