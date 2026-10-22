
using Microsoft.EntityFrameworkCore;

namespace TiendaPractica.Models
{
    public class TiendaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string conexion =
                @"Server=(localdb)\MSSQLLocalDB;" +
                @"Database=TiendaPracticaDB;" +
                @"Trusted_Connection=True;" +
                @"TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(conexion);
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(p => p.Precio)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
