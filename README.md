# Pokédex API

Welcome to the Pokédex API, a .NET 6 application designed to manage Pokémon information!

## Prerequisites

Before you begin, make sure you have the following tools installed in your development environment:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/)

## Database Configuration

Execute the provided SQL script in DatabaseScripts to create the necessary tables.

## How to Run

Open a terminal and navigate to the project directory.

Run the following command to start the application:
```
dotnet run
```

## Project Layers
### Pokedex.API:

Contains the main application and API controllers.
Configuration files: appsettings.json, appsettings.Development.json.

### Pokedex.Domain:

Contains domain models and interfaces.
Subfolders: Dto for Data Transfer Objects, Interfaces, Model for domain models.

### Pokedex.Infrastructure:

Manages data access and database-related tasks.
Subfolders: Context for database context, Migrations for EF Core migrations, Repository for data repositories.

### Pokedex.Service:

Implements business logic and services.
Subfolders: Mappers for DTO to Entity mapping, Services for application services.


## Available Endpoints

The API will be accessible at [https://localhost:44379/](https://localhost:5001).

- **GET /api/pokemon:** Retrieve information about all Pokémon.
- **GET /api/pokemon/{number}:** Retrieve information about a Pokémon by its number.
- **POST /api/pokemon:** Create a new Pokémon.
- **PUT /api/pokemon/{number}:** Update information about a Pokémon by its number.

To use these endpoints, you can use tools like Postman or curl.

## Request Examples

Retrieve all Pokémon:

```
https://localhost:44379/api/pokemon
```

Retrieve a Pokémon by number:

```
https://localhost:44379/api/pokemon/{number}
```

Create a new Pokémon:

```
Post:
https://localhost:44379/api/pokemon

Object Examples:
{"number": 1, "name": "Bulbaur", "type1": "Grass", "type2": "Poison"}' 
{"number": 4, "name": "Charmander", "type1": "Fire", "type2": null}' 
```

Update information about a Pokémon:
```
Put:
https://localhost:44379/api/pokemon/{number}

Object Examples:
{"number": 1, "name": "Bulbaur", "type1": "Grass", "type2": "Poison"}' 
{"number": 4, "name": "Charmander", "type1": "Fire", "type2": null}' 
```

Remember to adjust the data as needed.

## Contributions

Contributions are welcome! Feel free to open issues or pull requests.

## License

This project is licensed under the MIT License