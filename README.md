# E-commerce Web Application

## Project Overview:
The E-commerce Web Application is a fully-featured online shopping platform designed to provide users with a seamless shopping experience. It offers a wide range of products, organized into categories, and includes user authentication, authorization, and secure payment processing.
This project is built using the MVC (Model-View-Controller) architectural pattern and is designed to provide an efficient workflow for managing product categories and products. Below, you'll find important information to help you get started with this project.

    
   ##  Key Features:

- User Authentication: Users can create accounts, log in, and securely manage their profiles.
- Product Catalog: A comprehensive product catalog with categories and detailed product listings.


![](./Images/product.PNG)


- User Roles: Different user roles, including administrators, editors, and regular users, with varying levels of access and permissions.
- Responsive Design: The application is responsive and accessible across various devices.
## Technology Stack:

- ASP.NET Core for the backend
- Entity Framework Core for database management
- Microsoft SQL Server for data storage
- Razor Pages and Views for the frontend
- Bootstrap for responsive design
- Azure for cloud hosting and database services




## Authentication and Authorization:
Users can create accounts and log in, and different roles (e.g., administrators, editors) are assigned specific permissions to manage the application.

## Policies and Security:
The application enforces security policies to protect user data and maintain data integrity. User data is securely stored and transmitted.

## Deployment and Hosting:
The project is hosted on Azure, ensuring high availability and scalability.
## Challenges Faced:
Challenges during development included database setup, role-based authorization, and integrating secure payment processing.

## Project Structure

- Controllers: Contains the controller classes responsible for handling user requests and directing them to appropriate actions.

- Models: Includes the data models, properties, navigation properties, and DTOs used to represent categories and products.

- Services: Contains service classes that implement interfaces for managing categories and products.

- Views: Contains the Razor views that define the user interface for different actions. Views are organized by controller and action names.
## Database Schema:
The database includes tables for Categories, Products, Users, Roles, and UserRoles, among others. These tables are interconnected to manage product data and user authentication efficiently.
### Introduction
The database schema for our application is designed to support the functionality of our e-commerce store. It includes tables for managing products, categories, shopping baskets, orders, and user information. The schema is built on Microsoft SQL Server and hosted on Azure and on deployment we use Azure SQL databases
.

### Schema Overview
Our database schema consists of the following tables:

![](./Images/tables.PNG)

- Categories: Stores information about product categories.
- Products: Contains details about individual products, including name, price, description, and category.
- Users: Captures user information, including usernames, email addresses, and roles.

### Explanation of DB Schema
1. Categories and Products:


     * The Categories table allows us to categorize products, making it easier for users to browse and search for items.

     * The Products table stores detailed information about each product, such as name, price, description, and category. This enables users to view product details and make informed purchase decisions.

2. Users

      - The Users table captures user data, including usernames, email addresses, and roles. Roles help us enforce security policies and control access to certain parts of the application.


## Claims
In our application, we capture the following claims:

- Username: We capture the username of authenticated users to provide a personalized shopping experience.

- Email Address: We capture the email address of users for communication purposes, such as order confirmations and notifications.

- Role: We assign roles (e.g., Administrator, Editor, User) to users to enforce access control policies. Each role has specific permissions within the application.

## Policies
We enforce the following policies in our application:

- Authentication Policy:

All users must authenticate using their username and password or other authentication methods supported by our Identity system.

- Authorization Policy: 
 
Different roles (Administrator, Editor, User) have varying levels of access to application features and data. For example, only Administrators can manage product categories and user roles.

- Category and Product Policy:

Only Administrators and Editors can create, edit, or delete categories and products. Regular users can view and purchase products.
if any user try to access one of these using the path of it it will show him a page represent "access deined" as it shown below :



![](./Images/acc.PNG)

By defining these policies, we ensure data security, access control, and a smooth user experience within our e-commerce application.

## Roles :
1. Administrator:

- AuthController: Administrators can sign up, log in, and log out like regular users. However, their primary role is to manage other aspects of the application.
- CategoryController: Administrators have full control over categories. They can view, create, edit, and delete categories. This role is responsible for maintaining the category structure of the store.
- ProductController: Administrators can perform all actions related to products. They can view the product list, view product details, create new products, edit existing products, and delete products. This role is responsible for managing the product catalog.
- HomeController: Administrators have access to general pages like the home page, privacy policy, and error pages.
2. Editor:

- AuthController: Editors can sign up, log in, and log out like regular users.
- CategoryController: Editors can view categories, but their primary role is to edit existing categories. They can make changes to category names.
- ProductController: Editors have similar permissions to administrators but with limitations. They can view products, view product details, edit existing products, and create new products. However, they cannot delete products.
- HomeController: Editors have access to general pages.
3. User:

- AuthController: Users can sign up, log in, and log out.
- CategoryController: Users can view categories but cannot make any changes.
- ProductController: Users can browse the product catalog, view product details, and purchase products. They cannot create, edit, or delete products.
- HomeController: Users have access to general pages.



These role-based permissions ensure that each user type has a specific set of actions they can perform within the application, providing a secure and controlled environment for managing your e-commerce platform.

## Project Deployment Link:

You can access the deployed version of this project by clicking  here [E-commerce](https://e-ccommerce.azurewebsites.net/)