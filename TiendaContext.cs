

using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace TiendaPractica.Models
{
    public class TiendaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            // Obtener la ruta de la carpeta del proyecto.
            string rutaBD = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "..", "..", "..",
                    "TiendaDB.mdf"
                )
            );

            // Configurar la conexión con SQL Server LocalDB.
            string conexion =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;" +
                $@"AttachDbFilename={rutaBD};" +
                @"Integrated Security=True;" +
                @"TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(conexion);
        }
    }
}



