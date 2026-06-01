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

## Frontend React / Ionic

- Use the Ionic documentation found here for information about building with Ionic https://ionicframework.com/docs/react/overviews
- Never call navigation (`history.replace`, `history.push`) directly in the render body — this is a side effect and will cause a React state transition error. Always wrap navigation in a `useEffect`
- Render methods must be pure — no side effects (API calls, subscriptions, timers, navigation) directly in the component body. All side effects belong in `useEffect`
- `IonRouterOutlet` pre-mounts *all* route components on app load (not just the active route) so that it can animate between them. This means `useEffect` guards that call `history.replace` will fire on every page at startup, not just when that page is active. Use `useIonViewDidEnter` instead — it only fires when the user actually navigates to that page

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

