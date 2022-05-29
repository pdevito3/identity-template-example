# Project

## Migrations
```bash
dotnet ef migrations add InitialMigration --context ApplicationDbContext --output-dir Migrations/Application
dotnet ef migrations add InitialMigration --context ConfigurationDbContext --output-dir Migrations/Configuration
dotnet ef migrations add InitialMigration --context PersistedGrantDbContext --output-dir Migrations/PersistedGrant
```