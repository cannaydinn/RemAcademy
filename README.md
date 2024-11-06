# RemAcademy - Online Education Platform API

RemAcademy is an online education platform that allows teachers to purchase course schedules, manage educational content, and access various resources for effective learning. This project is built using **ASP.NET Core Web API**, **Entity Framework Core**, and **JWT Authentication**, leveraging the principles of a **multi-layer architecture** to ensure separation of concerns, maintainability, and scalability.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [System Architecture](#system-architecture)
- [Setup Instructions](#setup-instructions)
- [Endpoints](#endpoints)
- [Authentication](#authentication)
- [Middleware & Filters](#middleware--filters)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Management**: Register, login, and manage user roles (Admin, Teacher).
- **Course Management**: Teachers can manage course details, including name, grade, and pricing.
- **Order Management**: Teachers can place orders for course schedules and download content in PDF, PowerPoint, or Word formats.
- **Maintenance Mode**: The system supports toggling maintenance mode, restricting access to endpoints during maintenance.
- **JWT Authentication**: Secure token-based authentication for protected endpoints.
- **Role-Based Authorization**: Admin users can perform administrative tasks such as managing settings and controlling access to resources.
- **Time-Controlled Endpoints**: Restrict access to specific API endpoints based on time, ensuring certain actions are only available during defined hours.
- **Exception Handling**: Global exception handling to provide consistent error responses.

## Technologies Used

- **ASP.NET Core 6.0**: Web API framework for building RESTful services.
- **Entity Framework Core**: ORM for database operations using Code-First approach.
- **JWT Authentication**: Token-based authentication for secure user access.
- **SQL Server**: Database management system for data storage.
- **Swagger/OpenAPI**: API documentation and testing interface.
- **Middleware**: Custom middleware for maintenance mode control.
- **Action Filters**: Implementing time-based restrictions for certain API endpoints.

## System Architecture

RemAcademy follows a **three-tier architecture**, which is structured as follows:

- **Presentation Layer (Web API)**: Exposes the API endpoints and handles user requests. This is where controllers are defined.
- **Business Layer**: Contains the core business logic and service operations, abstracting the interactions between the presentation and data layers.
- **Data Layer**: Handles data access using Entity Framework Core. This layer is responsible for interacting with the database and managing entities.

## Setup Instructions

To get started with RemAcademy, follow the instructions below:

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server instance (local or remote)
- Postman (for testing the API endpoints)
- Swagger (for API documentation and testing)

# API Endpoints

Here are some key API endpoints in RemAcademy:

## User Authentication

- **POST /api/auth/register**
  - Registers a new user (Teacher or Admin).
  - **Request Body:**
    ```json
    {
      "email": "string",
      "password": "string",
      "city": "string",
      "schoolName": "string",
      "role": "string"
    }
    ```
  - **Response:**
    ```json
    {
      "message": "User registered successfully"
    }
    ```

- **POST /api/auth/login**
  - Logs in a user and provides a JWT token for subsequent requests.
  - **Request Body:**
    ```json
    {
      "email": "string",
      "password": "string"
    }
    ```
  - **Response:**
    ```json
    {
      "token": "JWT_token"
    }
    ```

## Settings

- **PATCH /api/settings**
  - Toggle the system’s maintenance mode (Admin only).
  - **Request Body:**
    ```json
    {
      "maintenanceMode": true
    }
    ```
  - **Response:**
    ```json
    {
      "message": "System maintenance mode updated"
    }
    ```

## Courses

- **POST /api/products**
  - Adds a new course (Admin only).
  - **Request Body:**
    ```json
    {
      "name": "string",
      "grade": "string",
      "price": "decimal",
      "teacherId": "int"
    }
    ```
  - **Response:**
    ```json
    {
      "message": "Course created successfully"
    }
    ```

- **PUT /api/products/{id}**
  - Updates an existing course (Admin only).
  - **Request Body:**
    ```json
    {
      "name": "string",
      "grade": "string",
      "price": "decimal"
    }
    ```
  - **Response:**
    ```json
    {
      "message": "Course updated successfully"
    }
    ```

- **DELETE /api/products/{id}**
  - Deletes a course by its ID (Admin only).
  - **Response:**
    ```json
    {
      "message": "Course deleted successfully"
    }
    ```

## Orders

- **POST /api/orders**
  - Places an order for a course.
  - **Request Body:**
    ```json
    {
      "teacherId": "int",
      "orderProducts": [
        {
          "productId": "int",
          "quantity": "int"
        }
      ]
    }
    ```
  - **Response:**
    ```json
    {
      "message": "Order placed successfully",
      "orderId": "int"
    }
    ```

- **GET /api/orders/{id}**
  - Retrieves order details by ID.
  - **Response:**
    ```json
    {
      "orderId": "int",
      "teacherId": "int",
      "totalAmount": "decimal",
      "orderProducts": [
        {
          "productId": "int",
          "quantity": "int"
        }
      ]
    }
    ```

## Authentication

Authentication in RemAcademy is handled using **JWT Bearer Tokens**. Upon successful login, the user receives a token that must be included in the Authorization header for all subsequent requests to protected endpoints.


## Middleware & Filters
**Maintenance Mode Middleware
**The MaintenanceMiddleware checks whether the system is in maintenance mode. If the system is in maintenance mode, all requests except login and settings-related requests will be blocked, and a "Service Unavailable" message will be returned.

## Time-Controlled Access Filter
**The TimeControllerFilter restricts access to specific API endpoints based on the time of day. For example, certain endpoints can only be accessed between 10:00 PM and 11:00 PM.
