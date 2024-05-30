# EquipmentStatusTrackerAPI
An API for keeping track of equipment status.

Overview:
The EquipmentAPI is a web-based application designed to manage and track equipment shipping details, including equipment information, addresses, communication details, customer data, and GPS positions. The application provides endpoints to perform CRUD (Create, Read, Update, Delete) operations on various entities like equipment, addresses, customers, and their associated details. It offers functionalities to create, update, delete, and retrieve information related to equipment shipping, including tracking GPS positions.

Setting Up and Running the Application:
To set up and run the EquipmentAPI application, follow these steps:

Clone the Repository: Clone the EquipmentAPI repository from the Git repository location.

Install Dependencies: Ensure that you have the necessary dependencies installed. You might need .NET SDK, Entity Framework Core, and other related packages.

There is already configured database, but if any error happens, follow this Database Configuration:

Configure the database connection string in the appsettings.json file according to your database setup.
Ensure that the database server is running and accessible.
Database Migration: Run database migration commands to create the database schema and seed initial data. Use the following commands:

sql
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
Run the Application: Set the EquipmentAPI project as the startup project and run the application using the preferred IDE or command line. By default, the application should start running on the specified port (e.g., localhost:5000).

Test Endpoints: Once the application is running, you can test the API endpoints using tools like Postman or Swagger UI. Use the provided controllers to perform CRUD operations on various entities.

Database and Architectural Pattern:
For the database, Entity Framework Core is used as the ORM (Object-Relational Mapper) to interact with the database. The choice of a relational database like SQLite provides a structured approach to data storage, enabling efficient querying and management of complex relationships between entities.

Regarding architectural pattern, the application follows a layered architecture, consisting of:

Entities Layer: Defines the domain entities representing the data model.
Data Access Layer: Contains the database context and repository classes responsible for database interactions.
Business Layer: Implements business logic and orchestrates interactions between the data access layer and the API layer.
ASP.NET Web API Layer: Provides API endpoints for client interaction, handling HTTP requests, and responses.
This layered architecture promotes separation of concerns, modularity, and maintainability of the application codebase. It allows for easier testing, scalability, and extensibility of the application components. Additionally, the use of dependency injection facilitates loose coupling between different layers, promoting code reusability and easier maintenance.