namespace TiendaPractica.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        // Relación con la tabla Categorias.
        public virtual Categoria Categoria { get; set; } = null!;
    }
}

