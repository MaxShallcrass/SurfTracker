# Feature Spec: Signup / Login

## Status: Complete

---

## Overview

Authentication is handled entirely by AWS Cognito via the AWS Amplify SDK and the Amplify
Authenticator UI component. The Authenticator manages the full auth state machine — sign up,
email verification, and sign in — without custom form pages. The app gates access to all
authenticated routes by conditionally rendering either the Authenticator or the app router
based on auth state.

---

## User Flow

1. App loads → Amplify checks for a stored session
2. **Not authenticated** → `Login.tsx` renders with the Amplify Authenticator
3. **Sign Up** → user enters email + password; Amplify enforces the Cognito password policy
4. **Email Verification** → Amplify automatically transitions to a code entry screen; user enters the 6-digit code sent via SES
5. **Auto sign-in** → Amplify signs the user in after verification and fires a Hub `signedIn` event
6. **Post-auth** → `AuthContext` Hub listener retrieves the ID token, calls `POST /api/users` (idempotent — 409 treated as success), sets `isAuthenticated: true`
7. App renders the authenticated router; user lands on `/home`
8. **Sign Out** → user opens the `AppMenu` side drawer and taps Sign Out; Hub fires `signedOut`; `AuthContext` clears state; Authenticator renders again

---

## Password Policy

Enforced by Cognito (CloudFormation) and reflected automatically in the Amplify Authenticator UI:

- Minimum 8 characters
- At least one uppercase letter (A–Z)
- At least one lowercase letter (a–z)
- At least one number (0–9)
- At least one special character (`! @ # $ % ^ & *`)

---

## Architecture

### Auth library

`aws-amplify` + `@aws-amplify/ui-react`. Amplify provides a built-in state machine for the
full auth flow, automatic token storage and refresh via `localStorage` (no manual token
management needed), a Hub event bus for auth lifecycle events, and a themeable Authenticator
UI component.

### Amplify configuration

Configured once in `src/main.tsx` before the app renders:

```typescript
Amplify.configure({
  Auth: {
    Cognito: {
      userPoolId: import.meta.env.VITE_COGNITO_USER_POOL_ID,
      userPoolClientId: import.meta.env.VITE_COGNITO_CLIENT_ID,
      loginWith: { email: true },
    },
  },
});
```

`loginWith: { email: true }` is required — without it the Authenticator defaults to a
username-based flow and Cognito rejects sign-up requests because the `email` user attribute
is not included in the request body.

### App routing

`AppContent` in `App.tsx` conditionally renders based on auth state — no route-based auth
guards needed:

```
isLoading        →  <IonSpinner />
!isAuthenticated →  <Login />           (Amplify Authenticator)
isAuthenticated  →  <IonReactRouter>    (app routes)
```

---

## Frontend Files

| File | Role |
|---|---|
| `src/main.tsx` | Amplify.configure() and Amplify UI CSS import |
| `src/pages/Login.tsx` | Wraps `Authenticator` in `ThemeProvider` with the full design system theme |
| `src/pages/Login.css` | Page wrapper layout and CSS fallbacks for Amplify token properties not exposed by its type system |
| `src/context/AuthContext.tsx` | Auth state (idToken, isAuthenticated, isLoading); Hub listener for signedIn/signedOut events; calls createBackendUser on sign-in |
| `src/services/authService.ts` | `signOut`, `getIdToken`, `createBackendUser` |
| `src/App.tsx` | `AppContent` — conditional render logic; `IonRouterOutlet` with `id="main-content"` for menu wiring |
| `src/components/AppMenu.tsx` | `IonMenu` side drawer on all authenticated pages; Sign Out button in `IonFooter` |
| `src/pages/Home.tsx` | Post-auth landing page with `IonMenuButton` to open the drawer |
| `src/theme/variables.css` | Added `--accent-hover`, `--accent-active`, `--accent-focus` tokens for Amplify interaction states |

---

## Theming

The Amplify Authenticator is themed via `createTheme` + `ThemeProvider` from `@aws-amplify/ui-react`:

- All colour tokens reference CSS custom properties (e.g. `var(--bg-base)`) — no hardcoded hex values
- `colorMode="dark"` activates Amplify's dark base before custom tokens are applied
- Three Amplify type constraints required CSS fallbacks in `Login.css` rather than theme tokens:
  - `borderRadius` on the auth card
  - `backgroundColor` on inputs
  - `borderWidth` on focused inputs
- Heading font (Bricolage Grotesque) applied via CSS — no font-family token exists for headings in Amplify's type system

---

## Infrastructure

### `Infrastructure/cognito.yaml`

CloudFormation template deployed manually via the AWS Console.

Provisions a Cognito User Pool with email as the username attribute, SES email sending,
the password policy above, and email-based account recovery. The App Client has no client
secret, uses `ALLOW_USER_SRP_AUTH` + `ALLOW_REFRESH_TOKEN_AUTH`, and has
`PreventUserExistenceErrors: ENABLED`.

**Outputs:** `UserPoolId`, `UserPoolArn`, `AppClientId`

**Required in `SurfTracker/.env`:**
```
VITE_COGNITO_USER_POOL_ID=<UserPoolId>
VITE_COGNITO_CLIENT_ID=<AppClientId>
VITE_API_BASE_URL=http://localhost:5246
```

### Local database

SQL Server runs in Docker via `local/docker-compose.yml`. Start with `docker compose up -d`,
then apply migrations with `dotnet ef database update`.

---

## Backend

### `POST /api/users`

JWT-protected endpoint called after every sign-in. Idempotent — returns 409 if the user
already exists, which the frontend treats as success.

- Validates the Cognito JWT (via `AddJwtBearer` with the User Pool authority URL)
- Extracts `sub` (Cognito ID) from token claims — email is intentionally not stored; Cognito is the source of truth for user identity data
- Creates a user record if none exists for that `CognitoId`; unique index enforces no duplicates at the DB level

### CORS

Configured in `Program.cs` with `AllowedOrigins` read from `appsettings.json`.
Development origins in `appsettings.Development.json`:
- `http://localhost:8100` — Ionic dev server
- `capacitor://localhost` — iOS Capacitor
- `http://localhost` — Android Capacitor

### Files

| File | Role |
|---|---|
| `Program.cs` | JWT auth middleware, CORS policy, service registrations |
| `Controllers/UsersController.cs` | `POST /api/users` — extracts `sub`, calls service |
| `Services/UserService.cs` | Duplicate check, creates `User` entity |
| `Repositories/UserRepository.cs` | `ExistsByCognitoIdAsync`, `AddAsync` |
| `Models/Domain/User.cs` | `UserId`, `CognitoId`, `CreatedAt`, `UpdatedAt` |
| `Data/Configurations/UserConfiguration.cs` | Unique index on `CognitoId` |
| `Models/Exceptions/ConflictException.cs` | Mapped to 409 by `GlobalExceptionHandler` |
| `Migrations/20260522054703_AddUsersTable.cs` | Creates `Users` table |
