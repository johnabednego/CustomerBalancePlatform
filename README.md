# Customer Balance Platform

The Customer Balance Platform is an ASP.NET Core application designed to manage customer data and transactions. It provides an API to handle customer and transaction data efficiently.

## Project Structure

### Project Files

- **CustomerBalancePlatform.csproj**: Configuration file for project dependencies and framework targets.
- **Program.cs**: The entry point of the application, setting up the web host.
- **appsettings.json & appsettings.Development.json**: Store configuration settings for the application.

### Key Directories

- **Models**: Contains data models for the application.
  - **Customer.cs**: Defines the customer entity.
  - **Transaction.cs**: Defines the transaction entity.
  - **TransactionType.cs**: Enum defining types of transactions.

- **Controllers**: Manages web requests and responses.
  - **CustomersController.cs**: Handles customer-related actions.
  - **TransactionsController.cs**: Handles transaction-related actions.

- **Data**: Manages the database context.
  - **AppDbContext.cs**: Configures the Entity Framework Core context.

- **Properties**: 
  - **launchSettings.json**: Contains web server settings and environment variables.

### Additional Files

- **CustomerBalancePlatform.http**: Contains HTTP requests for testing API endpoints.

## Installation

To get started with the Customer Balance Platform, follow these steps:

1. Ensure you have [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.
2. Clone the repository to your local machine.
3. Navigate to the project directory and restore the dependencies:
   ```bash
   dotnet restore
