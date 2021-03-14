# StockHubApi

This project represents the backend for the Angular application <a href="https://github.com/samuelschnurr/stock-hub/tree/main/StockHubApp#stockhubapp">StockHubApp</a>. 

- REST API based on .NET 5
- Configured to run on IISExpress and Kestrel
- Database runs on Microsoft SQL Server Express 2019 LocalDB
- Single controller for CRUD operations of stocks
- Global logging and exception handling
- ORM with EF Core 5
- Unit tests for all application layers
- XML documentation

## Before you start
- Install the <a href="https://dotnet.microsoft.com/download/dotnet/5.0">.NET 5 SDK</a>
- Install the <a href="https://www.microsoft.com/de-de/sql-server/sql-server-downloads?rtc=1">Microsoft SQL Server Express 2019 LocalDB</a>
- Install the <a href="https://docs.microsoft.com/en-us/ef/core/cli/dotnet">EF Core cli tools</a> with the command `dotnet tool install --global dotnet-ef`
- Notice that this application is hosted at `https://localhost:44370/`

## Build and run

### Using an IDE

If you're using an integrated development environment like Visual Studio, you can easily open the project in it.
After a `package restore` and `build` of the project make sure you executed `Update-Database` to apply the EF Core Migrations.
Now the project can be started and operated under IISExpress.

### Using an CLI

Open the `dotnet` CLI and navigate to the folder where the `.csproj` of the project `StockHubApi` is located.

Run the following command to build the project:

```
dotnet build
```

Now setup the database with the command:

```
dotnet ef database update
```

After that you can run the project under Kestrel by:

```
dotnet run
```

## Run tests

### Using an IDE

Test classes are named by the schema `{Model}{Layer}Tests.cs`. They are located in the project `StockHubApi.Tests`. You can execute them by using your preferred testrunner. 

### Using an CLI

Open the `dotnet` CLI and navigate to the folder where the `.csproj` of the project `StockHubApi.Tests` is located. To start the unit tests, run the command:

```
dotnet test
```

## License

Get more information about the licensing of this repository at the <a href="https://github.com/samuelschnurr/stock-hub#license">root level</a>.
