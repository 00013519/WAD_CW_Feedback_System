#This application was developed for Web
Application module, as coursework portfolio project @ WIUT by student ID: 00013519
###Calculation for topic out of the list
13519 % 20 = 19 Feedback System
## Prerequisites
Before running the application, ensure you have the following installed:
- Node.js
- npm
- .NET SDK
- SQL Server or another compatible database management system

## Backend Setup
### NuGet Packages
- EntityFrameworkCore (version 6.0.27)
- EntityFrameworkCore.Sqlite (version 6.0.27)
- EntityFrameworkCore.SqlServer (version 6.0.27)
- EntityFrameworkCore.Tools (version 6.0.27)
- VisualStudio.Web.CodeGeneration.Design (version 6.0.16)
- Swashbuckle.AspNetCore (version 6.5.0)

### Configuration
#### appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "SqlServerConnection": "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ToDoItems;Integrated Security=True;"
  }
}
