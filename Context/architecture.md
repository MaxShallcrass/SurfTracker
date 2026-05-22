# Architecture Context

## Stack

| Layer     | Technology                  | Role   |
| --------- | --------------------------- | ------ |
| Framework backend | .NET Core REST API using| [Role] |
| UI        | Ionic + React + Capacitor | Component composition and styling |
| Auth      | AWS Cognito               | User identity and route protection |
| Database  | SQL Server  | Relational metadata for storing user's, sessions, surf spots |
| Infrastructure   | AWS Beanstalk, AWS RDS, Cognito             | Hosting auth, backend server and database

## System boundaries

- `SurfTracker` — Frontend Ionic + React + Capacitor Project
- - `SurfTracker/src/components` — Houses reusable UI elements like custom buttons or form inputs used across multiple pages
- - `SurfTracker/src/pages` — Contains top-level components that represent different routes
- - `SurfTracker/src/services` — Logic for API calls and data fetching.
- `Database` — Contains database schema
- `SurfTrackerBackend` — .NET Core REST Web API backend project
- `Infrastructure` — Contain YAML AWS CloudFormation files

## Storage Model

- **Database**: All data for storing user's, sessions, user inputted session data, data fetched by external API's
- - Database schema to be stored in the Database folder in sql files with one file per schema object. These schema need to be updated whenever the data stored is to be changed

## Infrastructure Model

- Infrastructure is to be built using AWS Cloudformation with YAML files
- A local way to run the server and database will be available but commented out for dev usage

## Auth and Access Model

- Every user signs in via AWS Cognito
- Data stored and cretaed by a user is only visible to the user that created it
- Another user cannot view the data that another user created

## Invariants

1. All 'buisness logic' is to be handled in the backend REST API's