# 🎬 MediaVault_API

**MediaVault_API** is a RESTful Web API built with **ASP.NET Core** and **Entity Framework Core**, designed to manage media content like Shows, Genres, Episodes, and Actors. It follows clean architecture practices with proper layering (Controllers, Services, Repositories, DTOs, Entities) and integrates with a real **SQL Server** database.

---

## 🚀 Features

- ✅ **CRUD Operations** for:
  - Shows
  - Genres
  - Episodes
  - Actors
- ✅ **Soft Delete** support (logical deletion)
- ✅ **Model Binding**:
  - `FromRoute`
  - `FromQuery`
  - `FromBody`
  - `FromForm`
- ✅ **Well-structured API responses** using custom `ApiResponse<T>` wrappers
- ✅ Tested via **Swagger UI** and **Postman**

---

## 💾 Database

- Uses **SQL Server** via **Entity Framework Core**
- **Relational Mapping:**
  - One-to-many: Show ➝ Episodes
  - Many-to-many: Shows ↔ Actors
- Sample/seed data scripts available

---

## 📦 Technologies Used

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core
- SQL Server Management Studio (SSMS)
- Swagger UI
- Postman

---

## 🛠️ How to Run

Follow these steps to set up and run the MediaVault_API project on your local machine:

### 1. **Clone the Repository**

```bash
git clone https://github.com/ayybeeeftw/MediaVault_API.git
cd MediaVault_API
```
### 2. **Install Prerequisites**
- .NET 6/7/8 SDK or later
- SQL Server (Express or Developer edition)
- SQL Server Management Studio (SSMS) (recommended)**

###  3. **Set Up the Database**
Using SQL Script
  1. Open SSMS and connect to your SQL Server instance.
  2. Open the script file located at:
     
     ```bash
     DatabaseScripts/Create_MediaVaultDb.sql
     ```
  4. Execute the script to create the database schema and (optionally) insert sample data.

###  4. **Configure the Connection String**
Open appsettings.json and update:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=MediaVaultDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## 📂 Project Structure

For a detailed breakdown, see click PROJECT_STRUCTURE.txt.
