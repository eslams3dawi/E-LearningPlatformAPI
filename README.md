# **E-LearningPlatformAPI**  

A **RESTful API** for an **E-Learning Platform** built using **.NET Core**, following **Clean Architecture principles**.  

## 📌 **Features**  

- ✅ **Generic Repository Pattern** for reusable and clean data access logic  
- ✅ **N-Tier Architecture** for better separation of concerns  
- ✅ **JWT Authentication & Authorization** using ASP.NET Core Identity  
- ✅ **DTOs** for efficient and secure data exchange  
- ✅ **RESTful API Design** to support seamless front-end integration  
- ✅ **Caching** (e.g., MemoryCache or DistributedCache) to enhance performance  
- ✅ **Global Exception Handling** via custom middleware  
- ✅ **Custom Filters** for logging, validation, and other cross-cutting concerns  
- ✅ **Custom Middleware** for request/response manipulation and centralized logging  
- ✅ **CORS Configuration** to enable safe cross-origin communication

## 🛠️ Technologies Used

- .NET Core  
- Entity Framework Core (EF Core)  
- SQL Server  
- JWT Authentication & ASP.NET Core Identity  
- Generic Repository Pattern  
- Dependency Injection  
- Caching (IMemoryCache / IDistributedCache)  
- Custom Middleware  
- Global Exception Handling  
- Custom Action Filters  
- CORS

## 🔐 Authentication
This API uses JWT (JSON Web Tokens) with ASP.NET Core Identity to secure endpoints. Tokens are generated upon login and used in the Authorization header as a Bearer token.

## 🌐 CORS
Cross-Origin Resource Sharing is configured to allow secure communication between the API and front-end applications hosted on different origins.


## 🚀 **Getting Started**  

### 1️⃣ Clone the Repository  
```sh
git clone https://github.com/eslams3dawi/E-LearningPlatformAPI.git
```  

### 2️⃣ Configure the Database  
- Update the connection string in `appsettings.json`.  
- Run EF Migrations:  
  ```sh
  dotnet ef database update
  ```  

### 3️⃣ Run the API  
```sh
dotnet run
```

---

### 🎯 **Contributions are welcome!** Feel free to fork, improve, and submit a pull request. 

---
