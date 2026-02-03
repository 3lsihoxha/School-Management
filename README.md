# School Management System (WinForms)

This is a single-project WinForms School Management System built with C# and SQL Server.
The application performs CRUD operations only. The database must be created manually using SQL.

---

## Requirements

- Visual Studio 2022 or newer  
  - .NET desktop development workload
- SQL Server Express or LocalDB
- SQL Server Management Studio (SSMS)

---

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/3lsihoxha/School-Management.git
```

Open the solution file in Visual Studio.

---

### 2. Create the Database Manually

1. Open SQL Server Management Studio
2. Connect to:
   - .\SQLEXPRESS or
   - (localdb)\MSSQLLocalDB
3. Open a New Query
4. Paste and execute the provided SQL script which has the name "QUERY.txt" inside the repository to create the database and tables

---

### 3. Configure Connection String

Open App.config in the project.

For SQL Server Express:
```xml
Server=\.\SQLEXPRESS;Database=School_Database;Integrated Security=True
```

For LocalDB:
```xml
Server=(localdb)\MSSQLLocalDB;Database=School_Database;Integrated Security=True
```

The connection string exists only in App.config.

---

### 4. Run the Application

Press F5 or click Start in Visual Studio.

Default admin login:
- Email: admin@school.com
- Password: 1234

---

## Notes

- Single project (no layered architecture)
- Manual database creation (no migrations)
- SHA-256 password hashing
- Clean and centralized database access

---

## License

Educational use only.
