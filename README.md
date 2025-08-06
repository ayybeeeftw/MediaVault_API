# 🎬 MediaVault_API

**MediaVault_API** is a RESTful Web API built with **ASP.NET Core** and **Entity Framework Core**, designed to manage media content like Shows, Genres, Episodes, and Actors. It follows **Clean Architecture** principles by separating concerns into distinct layers (API, Services, Repositories, and Domain) and integrates with a real **SQL Server** database.

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
- ✅ **Standardized API Responses** via `ApiResponse<T>` wrapper
- ✅ Fully testable via **Swagger UI** and **Postman**

---

## 🗂️ Architecture

The solution follows **layered backend architecture**:

| Layer             | Responsibility                                 |
|------------------|-------------------------------------------------|
| `MediaVault.API` | Handles HTTP requests and maps to services      |
| `MediaVault.Services` | Business logic and orchestration               |
| `MediaVault.Repositories` | Data access using Entity Framework Core      |
| `MediaVault.Models` | DTOs, Entities, Response wrappers, etc.       |

Each layer is a separate **.NET class library** and only references the layer directly below it.

---

## 💾 Database

- Built on **SQL Server**
- Uses **Entity Framework Core** for ORM
- Relationships:
  - One-to-many: `Show ➝ Episodes`
  - Many-to-many: `Shows ↔ Actors`
- Includes optional seed/sample data via SQL script

---

## 📦 Technologies Used

- ASP.NET Core Web API (`.NET 8`)
- Entity Framework Core
- SQL Server + SSMS
- AutoMapper
- Swagger (Swashbuckle)
- Visual Studio 2022
- Git + GitHub

---

## 🛠️ How to Run

### 1. **Clone the Repository**
```bash
git clone https://github.com/ayybeeeftw/MediaVault_API.git
cd MediaVault_API
```
---

## 📂 Project Structure
For a full structural breakdown of all folders and files pushed to GitHub, see:

👉 PROJECT_STRUCTURE.txt
