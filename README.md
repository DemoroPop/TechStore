
# TechStore — WPF Desktop Shop Application

TechStore is a desktop shopping application developed using C#, WPF, and MySQL. The project demonstrates desktop application development, database integration, data binding, and event-driven communication between windows.

## Features

- Product catalog loaded from a MySQL database
- Product search by name
- Product sorting by price (ascending and descending)
- Detailed product view with images and descriptions
- Shopping cart with item quantity management
- Add products to the cart from the catalog and product details window
- Automatic cart total calculation
- Cart item counter
- Local product image storage
- Demo checkout with Fondy payment-page redirection
- Event-driven communication between WPF windows

## Tech Stack

- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **Desktop UI:** WPF, XAML
- **Database:** MySQL
- **Data Access:** MySql.Data
- **Querying and Sorting:** LINQ
- **Development Tools:** Visual Studio, Git, GitHub

## Project Structure

```text
TechStore/
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
├── ProductDetailsWindow.xaml
├── ProductDetailsWindow.xaml.cs
└── DiplomaWPF.csproj
```

## Application Architecture

The application uses a simple separation of responsibilities:

- **MainWindow:** Displays the product catalog and manages the shopping cart.
- **ProductDetailsWindow:** Displays detailed information about the selected product.
- **ProductRepository:** Handles product retrieval from the MySQL database.
- **Product:** Represents product data.
- **CartItem:** Represents a product in the cart, including its quantity.

The product details window communicates with the main window through C# events and delegates. This allows both windows to interact without duplicating shopping cart logic.

## Database Setup

TechStore uses a MySQL database with a `products` table.

The application expects the following columns:

| Column | Data Type | Description |
|---|---|---|
| id | INT | Product identifier |
| name | VARCHAR(150) | Product name |
| price | DECIMAL(10,0) | Product price |
| image | VARCHAR(30) | Product image filename |
| description | TEXT | Product description |

Product images are stored locally in the `Images/` directory. The database stores the corresponding image filenames.

## Setup and Run

### 1. Clone the repository

```bash
git clone https://github.com/DemoroPop/TechStore.git
```

Open `DiplomaWPF.csproj` in Visual Studio.

### 2. Configure MySQL

Make sure your MySQL server is running and create a database containing the `products` table described above.

You can use MySQL Workbench, MAMP, or another compatible MySQL environment.

### 3. Configure the connection string

In the project directory, copy `connectionStrings.config.example` and rename the copy to:

`connectionStrings.config`

Using PowerShell:

```powershell
Copy-Item connectionStrings.config.example connectionStrings.config
```

Open the new file and replace the example values with your own:

- MySQL server address
- Port
- Database name
- Username
- Password

Keep `connectionStrings.config` in the same directory as `App.config`.

**Security note:** The actual connection string file is excluded from Git. Never commit database credentials or passwords.

### 4. Build and run

1. Open the project in Visual Studio.
2. Restore the required NuGet packages if necessary.
3. Build the solution.
4. Run the application.

## Payment Notice

The checkout functionality currently redirects users to a Fondy payment page for demonstration purposes.

This project does not implement complete payment processing, transaction verification, or order confirmation.

## Project Purpose

TechStore was developed as a portfolio project to practice C# and WPF development, MySQL database integration, LINQ, data binding, event-driven programming, and basic application architecture.
