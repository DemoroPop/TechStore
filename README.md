# TechStore — WPF Desktop Shop Application

TechStore is a desktop shop application built with **C# and WPF**.
The project demonstrates practical experience in building a full-featured
desktop application with database integration and user interface design.

---

## 🚀 Features

- Product listing loaded from **MySQL database**
- Product images stored locally in the project
- Shopping cart functionality
- Dynamic calculation of total price
- Cart item counter
- Redirect to payment page (Fondy demo)
- Clean and responsive WPF UI

---

## 🛠 Tech Stack

- C# / .NET Framework 4.7.2
- WPF (XAML)
- MySQL
- MySql.Data
- Git / GitHub

---

## 📂 Project Structure
DiplomaWPF/
├── Images/
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── Db.cs
├── Product.cs
├── App.config

---

## ⚙️ Setup & Run

1. Clone the repository
2. Open the solution in **Visual Studio**
3. Make sure MySQL server is running
4. Update the connection string in `Db.cs`:

```csharp
Server=localhost;Port=3306;Database=wpf_shop;Uid=USER;Pwd=PASSWORD;


