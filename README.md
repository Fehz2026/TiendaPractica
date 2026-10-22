# TiendaPractica - Sistema de Gestión de Productos (CRUD Multitabla)

## INTEGRANTE

Fernando Josué Hernández De La Cruz - 260436

## Descripción del proyecto

Aplicación de escritorio desarrollada en **C# con Windows Forms (.NET 8)**, utilizando Visual Studio 2022, Entity Framework Core y SQL Server Express LocalDB.

El proyecto implementa un sistema CRUD (Crear, Leer, Actualizar y Eliminar) para gestionar productos y sus categorías mediante una base de datos relacional.

## Características del proyecto

- Registrar productos: permite ingresar el nombre, precio y categoría de un producto.
- Consultar productos: muestra los registros almacenados en un DataGridView.
- Actualizar productos: permite modificar la información de un producto seleccionado.
- Eliminar productos: elimina registros previa confirmación del usuario.
- Relación entre tablas: utiliza las tablas `Categorias` y `Productos`, relacionadas mediante una clave foránea.
- Validación de datos: comprueba los campos antes de guardar o actualizar.
- Inicialización automática: crea la base de datos y las tablas cuando todavía no existen.

## Arquitectura de la base de datos

La aplicación utiliza una base de datos llamada `TiendaPracticaDB`, administrada mediante SQL Server Express LocalDB.

Contiene dos tablas relacionadas:

Tabla Categorias

- `Id`: entero, clave primaria.
- `Nombre`: texto de hasta 50 caracteres.

Tabla Productos

- `Id`: entero, clave primaria.
- `Nombre`: texto de hasta 100 caracteres.
- `Precio`: decimal con dos posiciones.
- `CategoriaId`: entero, clave foránea que referencia a `Categorias`.

La relación es de **uno a muchos (1:N)**: una categoría puede tener varios productos, pero cada producto pertenece a una categoría.

El archivo `Database/Creartabla.sql` contiene el script de referencia utilizado durante el desarrollo.

## Tecnologías utilizadas

- Lenguaje: C#.
- Framework:** .NET 8.
- Entorno de desarrollo: Visual Studio 2022.
- Interfaz gráfica: Windows Forms.
- Base de datos: SQL Server Express LocalDB.
- ORM: Entity Framework Core.
- Control de versiones: Git y GitHub.

## Requisitos de instalación

Para ejecutar el proyecto se necesita:

- Windows.
- Visual Studio 2022 con la carga de trabajo de desarrollo de escritorio .NET.
- .NET 8.
- SQL Server Express LocalDB.
- Acceso a NuGet para restaurar los paquetes del proyecto.

## Cómo ejecutar el proyecto

1. Clonar el repositorio:

   `git clone https://github.com/Fehz2026/TiendaPractica.git`

2. Abrir la solución del proyecto en Visual Studio 2022.
3. Restaurar los paquetes NuGet si es necesario.
4. Compilar el proyecto.
5. Ejecutar.

## Inicialización automática de la base de datos

Para facilitar la ejecución del proyecto después de clonarlo desde GitHub, se implementó el método `EnsureCreated()` de Entity Framework Core.

En la primera ejecución, si la base de datos `TiendaPracticaDB` no existe, la aplicación la crea automáticamente junto con las tablas `Categorias` y `Productos`.

También registra cinco categorías iniciales:

- Alimentos.
- Electrónica.
- Hogar.
- Ropa.
- Papelería.

De esta manera, no es necesario adjuntar manualmente un archivo `.mdf` ni ejecutar el script de creación para comenzar a utilizar el programa.

## Archivos principales

- `Form1.cs`: lógica de las operaciones CRUD.
- `Form1.Designer.cs`: diseño de la interfaz gráfica.
- `Models/Categoria.cs`: modelo de categorías.
- `Models/Producto.cs`: modelo de productos.
- `TiendaContext.cs`: configuración de Entity Framework Core y conexión con SQL Server.
- `Database/Creartabla.sql`: script de referencia de la base de datos.