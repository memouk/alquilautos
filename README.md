# alquilautos
Aplicacion diseñada bajo el patron MVC .net utilizando entityFramework para el manejo delas bases de datos, se utilizaron migraciones para crear la DB.
Db esta ubicada en azure
el string de conexion esta en appsettings.json

algunos comandos para la contruccion de la applicacion

dotnet new mvc -o alquilautos
cd alquilautos
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet aspnet-codegenerator controller -name AlquilerController -m Alquiler -dc alquilautos.Data.AlquilautosContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlserver
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet aspnet-codegenerator controller -name VehiculosController -m Vehisculos -dc alquilautos.Data.AlquilautosContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlserver
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update

para correr la applicacion utilizas

dotnet watch
