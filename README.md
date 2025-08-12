# RateEat — Gourmet Restaurant Reservation & Review Platform

---

## 🏗️ Architecture Overview & Design Patterns

RateEat is built on a clean, modular layered architecture following **Domain-Driven Design (DDD)** principles combined with **Repository**, **Unit of Work**, and **Service Layer** design patterns. This ensures separation of concerns, maintainability, testability, and scalability.

### Layers & Responsibilities

| Layer                 | Responsibility                                                                                     | Technologies & Patterns                 |
|-----------------------|--------------------------------------------------------------------------------------------------|---------------------------------------|
| **Core (Domain)**      | Defines business entities, domain logic, interfaces, and validation rules                         | POCO Entities, FluentValidation, Domain Exceptions, DTOs, AutoMapper, Interface Abstraction |
| **Infrastructure**     | Data access implementations, EF Core DbContext, repositories, caching, external integrations      | EF Core (Code-First), Dapper, IMemoryCache, Fluent API, Migrations, Repository Pattern      |
| **API (Presentation)** | RESTful API controllers, request/response handling, validation pipeline, middleware, API versioning | ASP.NET Core Web API (.NET 9), Middleware, Swagger (OpenAPI), FluentValidation.AspNetCore, **Rate Limiting**, Serilog |

---

## 🎯 Design Patterns Used

- **Repository Pattern:** Abstracts data access, provides CRUD operations without leaking EF Core specifics. Separate repositories for EF Core (write) and Dapper (read/reporting) to optimize performance.
- **Unit of Work:** Manages transactions and coordinates changes across multiple repositories ensuring atomic operations, especially in reservation flows.
- **Service Layer:** Encapsulates business logic, coordinating between repositories and applying domain rules, e.g., managing TrustScore updates and weighted rating calculations.
- **DTO (Data Transfer Object):** Decouples API contracts from domain entities to enhance security and flexibility; mapped using AutoMapper.
- **FluentValidation:** Centralizes input validation rules in the Core layer, providing consistent validation across API requests.
- **Middleware Pipeline:** Implements global exception handling, correlation IDs for tracing, and **rate limiting to protect critical endpoints**.
- **Caching:** `IMemoryCache` to store frequently accessed data such as restaurant details, with cache invalidation on data changes.
- **API Versioning & Documentation:** URL path versioning plus Swagger UI for discoverability and interactive testing.
- **Custom Domain Exceptions:** Enables expressive error handling aligned with domain rules, automatically translated into proper HTTP responses.
- **Options Pattern:** Application settings (e.g., rating weights) are encapsulated in strongly typed POCO classes bound to configuration sections using the Options Pattern (`IOptions<T>`). This promotes configuration modularity, type safety, and easy testing/modification without recompiling.

---

## 🛡️ Rate Limiting (Critical System Highlight)

One of the key reliability and security features implemented in RateEat is **Rate Limiting**:

- Protects expensive and sensitive endpoints (e.g., login, reservation creation) from abuse or DoS attacks.
- Implemented using **.NET 9 built-in RateLimiter Middleware** with configurable rules.
- Limits the number of requests per IP/client over specified time windows.
- Provides meaningful HTTP 429 (Too Many Requests) responses with retry-after headers.
- Helps maintain system stability and consistent performance under high load or attack scenarios.

This system is critical to guarantee a smooth experience for genuine users and protect backend resources.

---

## 🧩 Domain Model & Entities

- **BaseEntity:** Abstract base class containing common properties (`Id`, `CreatedAt`, `UpdatedAt`) inherited by all domain entities.
- **User:** Represents platform users with personal info, authentication fields (password hash & salt), and `TrustScore`.
- **Restaurant:** Contains details about dining venues, linked with menus, reviews, availability schedules, and reservations.
- **Review:** Captures multi-dimensional ratings (Service, Flavor, Ambiance) plus textual comments.
- **Reservation:** Stores booking information with status tracking and date/time details.
- **RestaurantAvailability:** Manages available seating per time slot, critical for concurrency-safe reservation transactions.
- **Menu & MenuItem:** Model restaurant offerings with hierarchical relation from menu to individual items.

---

## 🔄 Transaction Management

Reservation creation is a critical business process requiring atomicity:

- EF Core's **manual transactions** (`BeginTransactionAsync`) ensure:
  - Contention-safe decrement of available seats in `RestaurantAvailability`.
  - Consistent creation of `Reservation` records.
  - Rollback in case of concurrency conflicts or no available seats.
- Concurrency handled via optimistic or pessimistic locking strategies to prevent race conditions.
- Business rules enforced to prevent duplicate bookings by same user/time.

---

## ⚙️ Technology Stack & Rationale

| Technology/Tool       | Purpose                                                   | Why This Choice?                                         |
|----------------------|-----------------------------------------------------------|---------------------------------------------------------|
| **.NET 9 / ASP.NET Core** | Backend framework providing high performance, modularity | Latest .NET runtime with long-term support and modern features |
| **Entity Framework Core**  | ORM for data persistence and migrations                   | Code-first, LINQ support, transaction management        |
| **Dapper**            | Lightweight micro-ORM for read-optimized queries and reports | Superior performance for complex SQL queries            |
| **AutoMapper**        | Object-object mapping between entities and DTOs           | Reduces boilerplate mapping code                         |
| **FluentValidation**  | Declarative, reusable validation logic                     | Separates validation from models/controllers             |
| **IMemoryCache**      | Caching layer for frequently accessed data                 | Improves API responsiveness                              |
| **Swagger (Swashbuckle)** | API documentation and interactive UI                      | Industry-standard, auto-generated docs                   |
| **Serilog**           | Structured logging with correlation IDs                    | Enhances traceability and debugging                       |
| **Options Pattern**   | Strongly-typed configuration binding                       | Centralizes config in POCOs, supports dynamic reload and testability |
| **Rate Limiting Middleware** | Protects system from abuse, enforces request quotas         | Ensures stability and security for sensitive endpoints   |
| **SQL Server (or other RDBMS)** | Persistent relational storage                             | Reliable, supports transactions and concurrency          |

---

## 🧱 Project Structure & Layer Interactions

```
RateEat/
├── RateEat.Core/
├── RateEat.Infrastructure/
└── RateEat.API/
```

The **Core** project is the heart of the domain logic and has **no external dependencies**.

**Infrastructure** depends on Core for entity definitions and interface implementations.

**API** depends on both Core and Infrastructure, exposing functionality externally.

---

### 📝 API Versioning & Validation

- Versioning is done via URL paths: `/api/v1/...` allowing smooth evolution.
- Request DTOs are validated automatically using **FluentValidation** integrated into ASP.NET Core’s pipeline.
- Validation failures produce standard HTTP **400 Bad Request** responses with detailed error messages.

---

### 🚦 Health Checks & Reliability

- Implements liveness (`/health/live`) and readiness (`/health/ready`) probes for container orchestration.
- Checks database connectivity and other critical dependencies.
- Supports high availability and graceful degradation.

---

### 📊 Reporting Module

- Specialized read operations use **Dapper** for optimized raw SQL queries.
- Reports include:
  - Best value restaurants (price/performance)
  - Top-rated by cuisine type and criteria
- Uses specialized DTOs to shape report data for frontend consumption.

---

### 📲 Frontend Integration (Mini UI)

- JavaScript-based minimal frontend consumes the API endpoints.
- Includes restaurant listing, detailed views, review forms, and reservation booking UI.
- Designed for responsive and user-friendly experience.

---

### Summary

RateEat is designed with robust, clean architecture and proven design patterns tailored for scalability, maintainability, and performance. The technology stack is thoughtfully chosen to balance developer productivity and runtime efficiency. Transaction management, caching, validation, configuration management via Options Pattern, and especially **rate limiting middleware** ensure a smooth and reliable user experience even under high load or attack.
