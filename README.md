# Wave EF Core Lab - Entity Framework Core Learning Project

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)](https://docs.microsoft.com/en-us/ef/core/)

A comprehensive .NET 8 Web API project designed for learning Entity Framework Core with SQL Server. This lab provides hands-on experience with Code First approach, repository patterns, and advanced EF Core querying techniques.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Quick Start](#quick-start)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Learning Resources](#learning-resources)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Code First Approach**: Learn to create databases from C# models
- **Repository Pattern**: Clean separation of data access logic
- **Advanced Querying**: Pagination, filtering, sorting, and projections
- **Performance Optimization**: AsNoTracking, AsSplitQuery, and efficient queries
- **Comprehensive Examples**: 10+ practical EF Core patterns
- **Automatic Seeding**: Generate realistic test data with Bogus library
- **API Documentation**: Interactive Swagger/OpenAPI interface
- **Well Documented**: Extensive inline comments and guides

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) or [SQL Server LocalDB](https://docs.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with C# extension
- [Git](https://git-scm.com/) (for cloning the repository)

## Quick Start

### 1. Clone the Repository

```powershell
git clone https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git
cd Wave_EfCoreLab_LAB1
```

### 2. Configure Database Connection

Update `appsettings.json` with your SQL Server connection:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=efCoreLabs;User Id=sa;Password=MySecurePassword;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

**For LocalDB (Windows):**
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=efCoreLabs;Trusted_Connection=True;MultipleActiveResultSets=true"
```

### 3. Install EF Core Tools

```powershell
dotnet tool install --global dotnet-ef --version 8.0.0
```

**Corporate Environment?** See [TROUBLESHOOTING.md](TROUBLESHOOTING.md#1a-installing-ef-core-tools-locally-corporate-profile-restrictions) for local installation.

### 4. Create Database

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Run the Application

```powershell
dotnet run
```

Navigate to: `https://localhost:7xxx/swagger`

## Project Structure

```
Wave_EfCoreLab_LAB1/
├── Controllers/              # API endpoints
│   ├── CustomersController.cs
│   ├── InvoicesController.cs
│   ├── TelephoneNumbersController.cs
│   └── AdvancedExamplesController.cs
├── Data/                     # Entity models and DbContext
│   ├── AppDbContext.cs
│   ├── Customer.cs
│   ├── Invoice.cs
│   └── TelephoneNumber.cs
├── DTOs/                     # Data Transfer Objects
│   ├── CustomerDto.cs
│   ├── InvoiceDto.cs
│   ├── TelephoneNumberDto.cs
│   └── PagedResult.cs
├── Repositories/             # Repository pattern implementation
│   ├── IRepositories.cs
│   ├── CustomerRepository.cs
│   ├── InvoiceRepository.cs
│   └── TelephoneNumberRepository.cs
├── Mappings/                 # Entity-DTO mappings
├── Migrations/               # EF Core migrations
├── Docs/                     # Documentation
│   ├── LAB_INSTRUCTIONS.md
│   ├── EF_CORE_EXAMPLES.md
│   └── TROUBLESHOOTING.md
└── Bogus.cs                  # Test data generator
```

## Database Schema

### Entities Overview

#### Customer
- **Id**: Auto-generated (BIGINT)
- **Name**: String (max 200 chars)
- **Email**: String (max 200 chars, unique)
- **Balance**: Computed property (sum of invoices)
- **Relationships**: Has many Invoices and PhoneNumbers

#### Invoice
- **Id**: Auto-generated (BIGINT)
- **InvoiceNumber**: String (max 50 chars, unique, must start with "INV")
- **Amount**: Decimal(18,2) (must be >= 0)
- **InvoiceDate**: DateTime
- **CustomerId**: Foreign key to Customer

#### TelephoneNumber
- **Id**: Auto-generated (BIGINT)
- **Number**: String (max 50 chars)
- **Type**: Enum-like string ("Mobile", "Work", or "DirectDial")
- **CustomerId**: Foreign key to Customer

## Learning Resources

This project includes comprehensive learning materials:

### 1. [LAB_INSTRUCTIONS.md](LAB_INSTRUCTIONS.md)
Step-by-step guide to implementing EF Core from scratch:
- Setting up DbContext
- Creating migrations
- Implementing repositories
- Advanced querying techniques

### 2. [EF_CORE_EXAMPLES.md](EF_CORE_EXAMPLES.md)
10 practical EF Core patterns with examples:
- Pagination (Skip/Take)
- Filtering and Search
- Sorting (OrderBy/ThenBy)
- Split Queries (Cartesian Explosion)
- Projection (Select for Efficiency)
- AsNoTracking (Read-Only Queries)
- GroupBy and Aggregations
- Transactions (Atomic Operations)
- Explicit Loading
- Raw SQL Queries

### 3. [TROUBLESHOOTING.md](TROUBLESHOOTING.md)
Common issues and solutions:
- EF Core tools installation
- Connection string problems
- Migration issues
- Corporate network restrictions

## API Documentation

Once running, access the interactive API documentation at:
- **Swagger UI**: `https://localhost:7xxx/swagger`

### Key Endpoints

#### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `GET /api/customers/paginated?page=1&pageSize=10` - Paginated results
- `GET /api/customers/search?name=acme&minBalance=1000` - Search with filters
- `POST /api/customers` - Create new customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer

#### Invoices
- `GET /api/invoices` - Get all invoices
- `GET /api/invoices/{id}` - Get invoice by ID
- `GET /api/invoices/customer/{customerId}` - Get invoices by customer
- `POST /api/invoices` - Create new invoice
- `PUT /api/invoices/{id}` - Update invoice
- `DELETE /api/invoices/{id}` - Delete invoice

#### Advanced Examples
- `GET /api/advancedexamples/customer-summary` - Projection demo
- `GET /api/advancedexamples/invoice-statistics` - Aggregation demo
- `GET /api/advancedexamples/no-tracking-demo` - Performance comparison
- `GET /api/advancedexamples/explicit-loading/{id}` - Explicit loading demo
- `POST /api/advancedexamples/transfer-invoices` - Transaction demo

## Database Seeding

The project automatically generates test data using the [Bogus](https://github.com/bchavez/Bogus) library.

Configure seeding in `appsettings.json`:

```json
"SeedSettings": {
  "EnableSeeding": true,
  "CustomerCount": 1000,
  "MinInvoicesPerCustomer": 1,
  "MaxInvoicesPerCustomer": 5,
  "MinPhoneNumbersPerCustomer": 1,
  "MaxPhoneNumbersPerCustomer": 3
}
```

## Technologies Used

- **.NET 8** - Modern, high-performance framework
- **Entity Framework Core 8.0** - ORM for database access
- **SQL Server** - Relational database
- **ASP.NET Core Web API** - RESTful API framework
- **Swagger/OpenAPI** - API documentation
- **Bogus** - Test data generation
- **Repository Pattern** - Data access abstraction
- **DTO Pattern** - API response models

## Performance Tips

- Use `AsNoTracking()` for read-only queries (10-30% faster)
- Use `AsSplitQuery()` when loading multiple collections
- Always `OrderBy()` before `Skip()`/`Take()`
- Use projection (`Select`) to load only needed data
- Avoid `ToList()` before filtering (use database-side filtering)

## Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Entity Framework Core Team for excellent documentation
- Bogus library for realistic test data generation
- Community contributors and learners

## Support

- **Issues**: [GitHub Issues](https://github.com/TCBWZA/Wave_EfCoreLab_LAB1/issues)
- **Discussions**: [GitHub Discussions](https://github.com/TCBWZA/Wave_EfCoreLab_LAB1/discussions)
- **Documentation**: See [docs folder](/) for detailed guides

## Related Resources

- [EF Core Documentation](https://docs.microsoft.com/ef/core/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core/)
- [C# Programming Guide](https://docs.microsoft.com/dotnet/csharp/)

---

**Happy Learning!** If you find this project helpful, please give it a star ⭐


