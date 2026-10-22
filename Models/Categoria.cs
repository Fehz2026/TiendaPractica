using System.Collections.Generic;

namespace TiendaPractica.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        // Una categoría puede tener muchos productos.
        public virtual ICollection<Producto> Productos { get; set; }
            = new List<Producto>();
    }
}
