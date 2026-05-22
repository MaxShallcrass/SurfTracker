# Progress Tracker

Update this file after every meaningful implementation
change.

## Current Phase

In progress

## Current Goal

Backend project base setup complete. Ready to begin feature implementation (Auth → Session creation → Session views).

## Completed

- Ionic React Capacitor frontend scaffolded (blank project)
- .NET 10 Web API backend scaffolded and cleaned up
  - Removed weather forecast boilerplate
  - Clean architecture folder structure established:
    `Controllers/`, `Services/Interfaces/`, `Repositories/Interfaces/`,
    `Data/`, `Middleware/`, `Models/Domain/`, `Models/DTOs/`
  - EF Core 10 + SQL Server provider added; skeleton `AppDbContext` created
  - Global exception handler wired (`IExceptionHandler`, returns safe `ErrorResponse`)
  - AWS Cognito JWT auth added as package but middleware commented out pending real Cognito pool
  - `/api/health` endpoint added for connectivity testing

## In Progress

- Nothing actively in progress

## Next Up

1. Set up AWS Cognito User Pool and fill in `appsettings.json` placeholders, then uncomment auth middleware
2. Define SQL Server schema (Users, SurfSpots, SurfSessions) in `Database/` folder
3. Create EF Core domain models and run first migration
4. Implement Auth endpoints (signup/login proxy or Cognito-hosted UI)

## Open Questions

- Will login/signup be handled via Cognito hosted UI or custom API endpoints that call the Cognito SDK?
- What external APIs will be used for swell, wind, and tide data?
- What is the expected SurfSession data model (fields for user-inputted performance stats)?

## Architecture Decisions

- Single-project clean-folder structure chosen over multi-project solution — appropriate scope for this app size
- .NET 10 retained (already scaffolded; stable release as of Nov 2025)
- Global exception handler uses `IExceptionHandler` interface (ASP.NET Core 8+ pattern) registered via `AddExceptionHandler<T>()`
- Cognito JWT auth commented out in `Program.cs` — uncomment once UserPoolId/Region are known

## Session Notes

- Backend at `SurfTrackerBackend/`, frontend at `SurfTracker/`
- `appsettings.json` has placeholder values for `ConnectionStrings:DefaultConnection` and `AWS:Cognito` — replace before running
- `appsettings.Development.json` targets `localhost` SQL Server (`SurfTrackerDev` database)
