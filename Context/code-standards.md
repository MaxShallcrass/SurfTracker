# Code Standards

## General

- Keep modules small and single-purpose
- Fix root causes, do not layer workarounds
- Do not mix unrelated concerns in one component or route
- Respect the system boundaries defined in architecture.md

## TypeScript

- Strict mode is required throughout the project
- Avoid any — use explicit interfaces or narrowly scoped types
- Validate unknown external input at system boundaries before trusting it

## Backend .NET Core Web APIs — 

- Keep controllers thin — business logic belongs in a service layer
- Use DTOs, never expose your database models directly
- Keep route handlers focused on a single responsibility
- Use RESTful route conventions consistently
- Protect endpoints with authorisation attributes, every endpoint except signup and login should require an authenticated user.
- Never expose raw exception messages to the client. Stack traces and database error messages must never reach the API response. Use a global exception handler to catch unhandled errors and return a safe, consistent error shape.
- Extract the authenticated user's ID from the JWT token — never trust it from the request body
- Follow clearn architecture practices for file and folder structure

## Styling

- Use CSS custom property tokens — no hardcoded hex values
- Follow the border radius scale defined in ui-context.md

## API Routes

- Validate and parse request input before  any logic runs
- Enforce auth and ownership before any mutation
- Return consistent, predictable response shapes

## Data and Storage

- Adhere to SQL Server standards

## Entity Framework Core

- Every entity must have its own configuration class implementing `IEntityTypeConfiguration<T>`
- Configuration classes live in `SurfTrackerBackend/Data/Configurations/` — one file per entity (e.g. `UserConfiguration.cs`)
- `AppDbContext` must never contain inline entity configuration — all configuration is picked up automatically via `modelBuilder.ApplyConfigurationsFromAssembly()`
- `AppDbContext` contains only `DbSet<T>` properties and the single `ApplyConfigurationsFromAssembly` call in `OnModelCreating`
- Every new database table requires a corresponding SQL schema file in `Database/` before the migration is run

