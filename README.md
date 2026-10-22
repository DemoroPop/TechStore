# TechStore — WPF Desktop Shop Application

TechStore is a desktop shop application built with **C#, WPF, and MySQL**. It demonstrates database integration, product management, and shopping cart functionality.

## Features

- Product listing loaded from a MySQL database
- Product images stored locally in the project
- Shopping cart with item quantity tracking
- Automatic calculation of the cart total
- Cart item counter
- Redirect to a Fondy payment page (demo)
- WPF user interface built with XAML

## Tech Stack

- C#
- .NET Framework 4.7.2
- WPF / XAML
- MySQL
- MySql.Data
- Git / GitHub

## Project Structure

```text
DiplomaWPF/
├── Data/
│   └── ProductRepository.cs
├── Images/
├── Models/
│   ├── CartItem.cs
│   └── Product.cs
├── Properties/
├── App.config
├── connectionStrings.config.example
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── DiplomaWPF.csproj
```

## Setup and Run

### 1. Clone the repository

Clone the repository and open the solution in Visual Studio.

### 2. Configure MySQL

Make sure your MySQL server is running and that your database contains a `products` table with the following columns:

- `id`
- `name`
- `price`
- `image`

### 3. Configure the connection string

In the project directory, copy `connectionStrings.config.example` and rename the copy to `connectionStrings.config`.

You can do this in PowerShell:

```powershell
Copy-Item connectionStrings.config.example connectionStrings.config
```

Open `connectionStrings.config` and replace the example values with your own MySQL server, port, database name, username, and password.

Keep this file in the project directory, alongside `App.config`.

**Security note:** `connectionStrings.config` is excluded from Git. Do not commit real database credentials or passwords.

### 4. Build and run

Build the project in Visual Studio and run the application.

## Notes

- The database must be configured separately.
- The connection string template contains example values only.
- The payment-page redirect is for demonstration purposes.

