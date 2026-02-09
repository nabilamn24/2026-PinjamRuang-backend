# PinjamRuang - Backend API

Backend API untuk aplikasi peminjaman ruangan kampus. Dibangun menggunakan **ASP.NET Core 8** dan **Entity Framework Core**.

Project ini menerapkan arsitektur **RESTful API** dengan standar industri seperti **DTO Pattern**, **Soft Delete**, dan **Data Seeding**.

## Tech Stack

- **Framework:** .NET 8.0 (ASP.NET Core Web API)
- **Database:** SQL Server (via Entity Framework Core)
- **ORM:** EF Core 8
- **Architecture:** MVC (Model-View-Controller) + DTO Pattern

## Fitur Utama

1. **CRUD Peminjaman Ruang**
   - Create, Read, Update, Delete data peminjaman.
   - Validasi input (Required, MinLength, Date Validation).
2. **Soft Delete Mechanism**
   - Data yang dihapus **tidak hilang permanen** dari database.
   - Menggunakan kolom `DeletedAt` untuk menandai data terhapus.
   - API otomatis memfilter data sampah agar tidak muncul di frontend.
3. **DTO Pattern (Data Transfer Object)**
   - Pemisahan antara **Entity Database** dan **API Request/Response**.
   - Mencegah _Over-Posting_ dan manipulasi kolom sensitif (seperti `DeletedAt` atau `CreatedAt`).
4. **Data Seeding**
   - Database otomatis terisi data dummy saat pertama kali dijalankan (via Migration).

## Cara Menjalankan Project

### 1. Prasyarat

- .NET SDK 8.0
- SQL Server (LocalDB atau SQL Express)

### 2. Instalasi & Setup Database

Clone repository ini, lalu buka terminal di folder backend:

```bash
# Restore dependencies
dotnet restore

# Update Database (Penting! Untuk menerapkan Data Seeding & Tabel)
dotnet ef database update
```
