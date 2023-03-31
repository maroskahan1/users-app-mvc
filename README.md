# users-app-mvc

Solution is composed into 3 projects - 

**Core Project (Class Library)**  - Definitions for database entities and interface for database operations.

**Infrastructure Project (Class Library)** - Here is defined business logic and methods used to work with DB (CRUD operations)

**UI Project (MVC)** - MVC based application using both core and infrastructure projects to generate views

For demo purposes i chose implementation via repository pattern. Dependency injection is registered with using of Unity.Mvc5. 

Used ORM Framework - Entity Framework (DB First approach)
