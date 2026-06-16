# Progress Tracker

Update this file after every meaningful implementation change.

## Current Phase

In progress

## Current Goal

Signup / Login feature complete. Ready for next feature — surf session creation.

## Completed

- **Database tables** (`context/feature-specs/02-database-structure.md`)

  *Database*
  - `Database/SurfSpots.sql`, `Database/Surfboards.sql`, `Database/SurfSessions.sql`,
    `Database/SurfSessionUserObservations.sql`, `Database/SurfSessionSwell.sql`,
    `Database/SurfSessionWeather.sql` — SQL schema files for all tables

  *Backend*
  - `SurfTrackerBackend/Models/Domain/` — domain models for all 6 new entities
  - `SurfTrackerBackend/Data/Configurations/` — EF Core configuration class per entity
  - `SurfTrackerBackend/Data/AppDbContext.cs` — DbSet properties added for all entities
  - `SurfTrackerBackend/Migrations/20260616232611_AddDatabaseTables.cs` — EF migration generated

- **Signup / Login** (`context/feature-specs/01-singup-login.md`)

  *Infrastructure*
  - `Infrastructure/cognito.yaml` — CloudFormation template (User Pool with email auth +
    SES email sending, App Client with SRP auth + PreventUserExistenceErrors, Outputs)

  *Frontend*
  - `src/main.tsx` — Amplify.configure() with userPoolId, userPoolClientId,
    `loginWith: { email: true }`; Amplify UI CSS import
  - `src/services/authService.ts` — signOut, getIdToken, createBackendUser
  - `src/context/AuthContext.tsx` — auth state (idToken, isAuthenticated, isLoading);
    Hub listener for signedIn/signedOut events; calls createBackendUser on sign-in
  - `src/pages/Login.tsx` — Amplify Authenticator wrapped in ThemeProvider with full
    design system theme (all tokens reference variables.css)
  - `src/pages/Login.css` — page wrapper layout + CSS fallbacks for unexposed Amplify tokens
  - `src/components/AppMenu.tsx` — IonMenu side drawer on all authenticated pages;
    Sign Out button in IonFooter
  - `src/pages/Home.tsx` — placeholder post-auth landing page with menu button
  - `src/App.tsx` — AppContent conditionally renders spinner/Login/router by auth state;
    AppMenu + IonRouterOutlet(id="main-content") in authenticated branch
  - `src/theme/variables.css` — added --accent-hover, --accent-active, --accent-focus tokens

  *Backend*
  - `SurfTrackerBackend/Controllers/UsersController.cs` — POST /api/users (JWT-protected,
    extracts sub from token claims; email intentionally not stored)
  - `SurfTrackerBackend/Services/UserService.cs` + `Interfaces/IUserService.cs`
  - `SurfTrackerBackend/Repositories/UserRepository.cs` + `Interfaces/IUserRepository.cs`
  - `SurfTrackerBackend/Models/Exceptions/ConflictException.cs` — mapped to 409
  - `SurfTrackerBackend/Program.cs` — JWT auth middleware enabled, services registered

- Ionic React Capacitor frontend scaffolded (blank project)
- .NET 10 Web API backend scaffolded and cleaned up
  - Removed weather forecast boilerplate
  - Clean architecture folder structure:
    `Controllers/`, `Services/Interfaces/`, `Repositories/Interfaces/`,
    `Data/`, `Middleware/`, `Models/Domain/`, `Models/DTOs/`
  - EF Core 10 + SQL Server provider; skeleton `AppDbContext`
  - Global exception handler (`IExceptionHandler`, returns safe `ErrorResponse`)
  - JWT auth middleware enabled with Cognito User Pool configuration
  - `/api/health` endpoint for connectivity testing

## In Progress

- Nothing actively in progress

## Next Up

1. Implement surf session creation feature

## Open Questions

- What external APIs will be used for swell, wind, and tide data?
- What is the expected SurfSession data model (fields, performance stats)?

## Architecture Decisions

- **Amplify Authenticator over custom auth pages** — Amplify's built-in state machine
  handles sign up → verify → sign in without custom pages or routing workarounds.
  Replaced the originally planned `amazon-cognito-identity-js` + custom pages approach.
- **Conditional rendering over auth routes** — `AppContent` renders either the Authenticator
  or the app router based on auth state. Avoids IonRouterOutlet pre-mounting issues that
  would require `useIonViewDidEnter` + `useRef` guards on every auth page.
- **Hub listener for post-auth side effects** — `AuthContext` listens to Amplify's Hub
  `signedIn` event to call createBackendUser, rather than doing it inline after a manual
  signIn call. Keeps auth side effects centralised.
- **Single-project clean-folder structure** — appropriate scope for this app size
- **.NET 10 retained** — stable release as of Nov 2025, already scaffolded
- **Global exception handler** — uses `IExceptionHandler` interface (ASP.NET Core 8+ pattern)

## Session Notes

- Backend at `SurfTrackerBackend/`, frontend at `SurfTracker/`
- `appsettings.Development.json` and `.claude/settings.local.json` are gitignored
- Cognito env vars live in `SurfTracker/.env`: `VITE_COGNITO_USER_POOL_ID`,
  `VITE_COGNITO_CLIENT_ID`
- `appsettings.json` has placeholder values for `ConnectionStrings:DefaultConnection`
  and `AWS:Cognito` — replace before running
