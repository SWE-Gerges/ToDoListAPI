# ToDoListAPI
# Task for Oasis code test - implementing CRUD operations, consume APIs, Pagination, Authorization & Authentication using Clean Architecture with Repository pattern and UnitOfWork
---------------------------------------------------------------------------------------------------------------
#Technology Used
- .Net Core 8 ( ASP.NET Core )
- EF Core 8
- Database : MSSQL Server
  * Clean Architecture ( 3-Layers: Core, Infrastructure, Web)
  * Pagination to limit / decide data count to retrieve at once
  * DTO to Transfer Data
  * Auto Mapper to map data between domain models and DTOs
  * Repository Pattern
  * UnitOfWork
  * Authorization & JWT Authentication
------------------------------------------------------------------------------------------------------------------
# API End Points
## LiveToDosControllers
- URL: [GET] /api/LiveToDos
- Parameters: Pagination (Page Number - Page Size ) *Note : Max Page Size is set to 50 in PaginationParameters class
## Accounts
- URL: [POST] /api/Accounts  --> register new account
- Parameters: UserName - Password - Name
       [POST] /api/Accounts/auth --> Login
- Parameters: UserName - Password    

## ToDo
* URLs
- [GET] /api/todos     --> Get all ToDo Lists available
- [GET] /api/todos/id  --> Get a specific Todo by Id
    Parameter: Id
- [PUT] /api/todos/id  --> Update specific Todo
  Parameter: Id
- [DELETE] /api/todos/id  --> Delete specific Todo
  Parameter: Id
  
