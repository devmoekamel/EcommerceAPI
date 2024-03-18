# E-Commerce API

This is an ASP.NET Core-based RESTful API for managing e-commerce related information. The API serves as the backend system for an e-commerce application, providing endpoints for managing users, products, categories, coupons, favorites, carts, and more.

## Table of Contents

- [Project Structure](#project-structure)
- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Authentication](#authentication)
- [Conclusion](#conclusion)

## Project Structure

The project structure follows a typical ASP.NET Core Web API pattern:

- **Controllers:** Contains controller classes that handle HTTP requests and serve responses.
- **Services:** Contains service classes responsible for business logic and data manipulation.
- **Models:** Defines data models used throughout the application.
- **Data:** Contains the database context and migrations for Entity Framework Core.
- **DTOs (Data Transfer Objects):** Defines data models used for communication between clients and the API.
-
 ## Class Diagram
 
 ___________________________________________         1         ___________________________________________
|                    User                   |<--------------------------|                    Favourite               |
|-------------------------------------------|         *         |-------------------------------------------|
| Id: int                                   |                     | Id: int                                   |
| UserName: string                          |                     | UserId: int                               |
| Email: string                             |                     | User: User                                |
| PhoneNumber: string                       |                     | ItemId: int                               |
| Addresses: ICollection<UserAddress>       |                     | Item: Item                                |
| Carts: ICollection<Cart>                  |                     |-------------------------------------------|
| Favourites: ICollection<Favourite>        |                     |                                           |
|___________________________________________|                     |___________________________________________|
     |                                                             |
     |                                                             |
     |                                                             |
     |                                                             |
     |                                                             |
     |                                                             |
     |                                                             |
     |                                                             V
 ___________________________________________         1         ___________________________________________
|                    Item                   |<--------------------------|                    Category              |
|-------------------------------------------|         *         |-------------------------------------------|
| Id: int                                   |                     | Id: int                                   |
| Name: string                              |                     | Name: string                              |
| Description: string                       |                     | Items: ICollection<Item>                 |
| Count: int                                |                     |-------------------------------------------|
| Active: bool                              |                     |                                           |
| Discount: int                             |                     |                                           |
| Image: string                             |                     |                                           |
| Price: double                             |                     |                                           |
| Date: DateTime                            |                     |                                           |
| CategoryId: int                           |                     |                                           |
| Category: Category                        |                     |                                           |
|-------------------------------------------|                     |___________________________________________|

 ___________________________________________          1          ___________________________________________
|                    Cart                   |-------------------------->|                   User                    |
|-------------------------------------------|          *         |-------------------------------------------|
| Id: int                                   |                      | Id: int                                   |
| UserId: int                               |                      | UserName: string                          |
| User: User                                |                      | Email: string                             |
| Items: ICollection<Item>                  |                      | PhoneNumber: string                       |
|___________________________________________|                      | Addresses: ICollection<UserAddress>       |
                                                                    | Carts: ICollection<Cart>                  |
                                                                    | Favourites: ICollection<Favourite>        |
                                                                    |___________________________________________|

 ___________________________________________         1         ___________________________________________
|                  Favourite                |-------------------------->|                    Item                  |
|-------------------------------------------|         *         |-------------------------------------------|
| Id: int                                   |                     | Id: int                                   |
| UserId: int                               |                     | Name: string                              |
| User: User                                |                     | Description: string                       |
| ItemId: int                               |                     | Count: int                                |
| Item: Item                                |                     | Active: bool                              |
|-------------------------------------------|                     | Discount: int                             |
                                                                    | Image: string                             |
                                                                    | Price: double                             |
                                                                    | Date: DateTime                            |
                                                                    | CategoryId: int                           |
                                                                    | Category: Category                        |
                                                                    |-------------------------------------------|





## Key Features

- **User Management:** Supports user registration, login, and role-based access control.
- **Product Management:** Implements CRUD operations for managing products and categories.
- **Coupon Management:** Allows the creation, retrieval, and removal of coupons for discounts.
- **Favorite Management:** Enables users to add and remove products from their favorites list.
- **Cart Management:** Provides functionalities for adding, removing, and retrieving items in the user's cart.

## Technologies Used

- **ASP.NET Core:** A cross-platform framework for building modern web applications and services.
- **C# Programming Language:** The primary language used for development.
- **Entity Framework Core:** An ORM (Object-Relational Mapper) for database interactions.
- **JWT Authentication:** A token-based authentication mechanism for securing APIs.
- **Swagger/OpenAPI:** A tool for documenting and testing APIs.

## Getting Started

To run the E-Commerce API locally, follow these steps:

1. Clone this repository to your local machine.
2. Set up your database connection string in `appsettings.json`.
3. Run database migrations to create necessary tables (`dotnet ef database update`).
4. Build and run the application (`dotnet run`).
5. Access the API endpoints using your preferred HTTP client or Swagger UI (typically available at `http://localhost:5000/swagger`).

## Authentication

Authentication in the E-Commerce API is based on JWT tokens. To access protected endpoints, clients must include a valid JWT token in the `Authorization` header of the HTTP request. Users can obtain JWT tokens by registering or logging in through the appropriate endpoints.

## Conclusion

Thank you for exploring the E-Commerce API project! This repository demonstrates the development of a robust and scalable e-commerce backend using ASP.NET Core. If you have any questions or feedback, feel free to reach out.
