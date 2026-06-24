# Hertz Peru Rental Orders API

## Overview

RESTful API built with **C#**, **.NET 9**, and **ASP.NET Core** to support Hertz Peru rental order operations. The solution follows **Domain-Driven Design (DDD)**, **Clean Architecture**, **CQRS**, and layered bounded contexts.

## Author

**Dhilsen Armil Mallqui Vilca**

## Bounded Contexts

The solution is organized into two bounded contexts at the project root, following the same style as the course reference project:

```
pc27414u202319440.API/
├── Shared/                          # Cross-cutting bounded context
│   ├── Application/Patterns/
│   ├── Domain/Model/
│   ├── Domain/Repositories/
│   └── Infrastructure/
│       ├── Interfaces/ASP/Configuration/
│       └── Persistence/EFC/
│           ├── Configuration/
│           ├── Interceptors/
│           └── Repositories/
└── Services/                        # Rental order bounded context
    ├── Domain/
    │   ├── Model/Aggregates/
    │   ├── Model/Commands/
    │   ├── Model/ValueObjects/
    │   └── Repositories/
    ├── Application/
    │   ├── Services/
    │   ├── Errors/
    │   └── Internal/CommandServices/
    ├── Infrastructure/Persistence/EFC/Repositories/
    └── Interfaces/REST/
        ├── Resources/
        └── Transform/
```

## Technologies

- C# / .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo MySQL provider
- Swagger / OpenAPI

## Business Rules

- A rental order cannot be registered twice for the same `customer` and `vehiclesId`.
- `amount` must be greater than zero.
- `requestedAt` cannot be earlier than the current system date.
- A `plate` cannot belong to different `vehiclesId` values.
- `vehiclesId` must match one of the valid `EVehicles` values:
  1. Picanto
  2. Soluto
  3. Corolla
  4. RAV4
  5. Versa
  6. Sportage

## Database

- Engine: MySQL
- Database name: `Hertz`
- Table: `rental_orders`
- Primary key column: `id`

Default local connection string:

```json
"Server=localhost;Port=3306;Database=Hertz;User=root;Password=admin123;"
```

## Endpoint

### Create Rental Order

- **Method:** `POST`
- **Route:** `/api/v1/rental-orders`
- **Success:** `201 Created`
- **Response body:** rental order resource with generated `rentalOrderId`
- **Excluded from response:** `amount`, `createdAt`, `updatedAt`

## Running the Application

1. Start MySQL locally.
2. Create the `Hertz` database if it does not exist.
3. Run:

```bash
dotnet restore
dotnet build
dotnet run --launch-profile http
```

4. Open Swagger UI:

```text
http://localhost:5208/swagger
```

## Out of Scope

- CORS
- Security
- Automated testing
