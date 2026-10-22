TiendaPractica Sistema CRUD de Productos

INTEGRANTE:
Fernando Josué Hernández De La Cruz   260436

Aplicación de escritorio desarrollada en C# con Windows Forms (.NET 8) y entity Framework Core, utilizando sql Server LocalDB para almacenar información.

- Windows.
- Visual Studio 2022 con soporte para desarrollo de escritorio .NET.
- .NET 8.
- SQL Server Express LocalDB.
- Acceso a NuGet para restaurar Microsoft.EntityFrameworkCore.SqlServer.

En la primera ejecución, entity Framework Core utiliza EnsureCreated() para crear la base de datos TiendaPracticaDB en SQL Server LocalDB, si todavía no existe. 
El sistema registra automáticamente cinco categorías iniciales: Alimentos, Electrónica, Hogar, Ropa y Papelería esto para facilotar la ejecucion de el proyecto luego de clonarlo desde github

La aplicación requiere que SQL Server LocalDB esté instalado y disponible. La base de datos se crea automáticamente y el script sql documenta la estructura de las tablas