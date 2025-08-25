# Project: REST API with .NET 9 and Angular 20.1.1

This project is a REST API built with **.NET 9** using an **In-Memory Database** and several **NuGet** packages for common functionality. The frontend is developed with **Angular 20.1.1**.

## Prerequisites

Make sure you have the following tools installed:

### Backend (.NET)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)
  - Workload: **ASP.NET and web development**
  - Workload: **.NET 9 SDK**
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (if not included in Visual Studio)

### Frontend (Angular)
- [Node.js (v20 or later)](https://nodejs.org/)
- [Angular CLI 20.1.1](https://angular.io/cli)

```bash
npm install -g @angular/cli@20.1.1
```

## Clone the Project

```bash
git clone https://github.com/brauliogrc/AspiriaTecnicalAsssessment.git
cd AspiriaTecnicalAsssessment
git checkout development # or `git checkout main`
```

## Project Structure

```
/AspiriaTecnicalAsssessment
│
├── Service/    → Proyecto backend (API .NET 9)
│
└── View/       → Proyecto frontend (Angular 20.1.1)
```

## Backend: REST API (.NET 9)

### 1. Open in Visual Studio

1. Open **Visual Studio**.
2. Select **"Open a project or solution"**.
3. Navigate to the `Service/AspiriaTechnicalAssessment/` directory and open the `.sln` file.

### 2. Restore NuGet Packages

In Visual Studio:
- Menu **Tools** → **NuGet Package Manager** → **Restore Packages**
- Or right-click the solution and select **Restore NuGet Packages**

### 3. Run the Project

1. Set the API project as the **Startup Project**.
2. Press `Ctrl + F5` to run without debugging or `F5` to run with debugging.
3. The API will run at `https://localhost:44318` (or the port configured in `launchSettings.json`).

## Frontend: Angular (20.1.1)

### 1. Setup the Environment

```bash
cd View/AspiriaTechnicalAssessmentView
npm install
```

### 2. Run the Angular Application

```bash
ng serve
```

This will start the development server at `http://localhost:4200`.

## Accessing the Application

- **Frontend:** [http://localhost:4200](http://localhost:4200)
- **Backend (Swagger UI or Postman):** [https://localhost:44318](https://localhost:44318/swagger/index.html)

## Additional Notes

- The API uses an **InMemoryDatabase**, so data resets every time the application restarts.
- You can test the API endpoints directly through **Swagger**, which is enabled by default in development mode.
- **CORS** have been configured but you need to make shure that the view base url will exists in the `appsettings.Development.json` `"Config":"OriginCors"` section.
- Ensure that the variable `apiUrlBase` of `environment.development.ts` correctly points to the base url of the api