
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TiendaPractica.Models;

namespace TiendaPractica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Conectar los botones con sus funciones.
            btnAgregar.Click += btnAgregar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            // Detectar cuando se selecciona un producto.
            dgvProductos.CellClick += dgvProductos_CellClick;

            if (InicializarBaseDeDatos())
            {
                CargarCategorias();
                CargarProductos();
            }


        }


        private bool InicializarBaseDeDatos()
        {
            try
            {
                using var db = new TiendaContext();

                // Crear la base de datos y sus tablas
                // si todavía no existen.
                db.Database.EnsureCreated();

                // Insertar categorías solo si la tabla está vacía.
                if (!db.Categorias.Any())
                {
                    db.Categorias.AddRange(
                        new Categoria { Nombre = "Alimentos" },
                        new Categoria { Nombre = "Electrónica" },
                        new Categoria { Nombre = "Hogar" },
                        new Categoria { Nombre = "Ropa" },
                        new Categoria { Nombre = "Papelería" }
                    );

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo inicializar la base de datos:\n"
                    + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }


        // =========================================
        // CARGAR CATEGORÍAS
        // =========================================
        private void CargarCategorias()
        {
            try
            {
                using var db = new TiendaContext();

                var categorias = db.Categorias
                    .AsNoTracking()
                    .OrderBy(c => c.Nombre)
                    .ToList();

                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar categorías:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // MOSTRAR PRODUCTOS
        // =========================================
        private void CargarProductos()
        {
            try
            {
                using var db = new TiendaContext();

                var productos = (
                    from p in db.Productos.AsNoTracking()
                    join c in db.Categorias.AsNoTracking()
                        on p.CategoriaId equals c.Id
                    orderby p.Id
                    select new
                    {
                        p.Id,
                        p.Nombre,
                        p.Precio,
                        Categoria = c.Nombre
                    }
                ).ToList();

                dgvProductos.DataSource = productos;
                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar productos:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // VALIDAR LOS CAMPOS
        // =========================================
        private bool ValidarCampos(
            out string nombre,
            out decimal precio,
            out int categoriaId)
        {
            nombre = txtNombre.Text.Trim();
            precio = 0;
            categoriaId = 0;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresa el nombre del producto.");
                txtNombre.Focus();
                return false;
            }

            if (nombre.Length > 100)
            {
                MessageBox.Show(
                    "El nombre no puede superar 100 caracteres.");
                return false;
            }

            bool precioValido =
                decimal.TryParse(
                    txtPrecio.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out precio
                );

            if (!precioValido)
            {
                precioValido = decimal.TryParse(
                    txtPrecio.Text,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out precio
                );
            }

            if (!precioValido || precio < 0)
            {
                MessageBox.Show("Ingresa un precio válido.");
                txtPrecio.Focus();
                return false;
            }

            if (Math.Round(precio, 2) != precio)
            {
                MessageBox.Show(
                    "El precio debe tener máximo dos decimales.");
                return false;
            }

            if (cmbCategoria.SelectedValue is not int id)
            {
                MessageBox.Show("Selecciona una categoría.");
                return false;
            }

            categoriaId = id;
            return true;
        }

        // =========================================
        // AGREGAR PRODUCTO
        // =========================================
        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos(
                out string nombre,
                out decimal precio,
                out int categoriaId))
                return;

            try
            {
                using var db = new TiendaContext();

                Producto producto = new Producto
                {
                    Nombre = nombre,
                    Precio = precio,
                    CategoriaId = categoriaId
                };

                db.Productos.Add(producto);
                db.SaveChanges();

                MessageBox.Show("Producto agregado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al agregar producto:\n" + ex.Message);
            }
        }

        // =========================================
        // ACTUALIZAR PRODUCTO
        // =========================================
        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecciona un producto para actualizar.");
                return;
            }

            if (!ValidarCampos(
                out string nombre,
                out decimal precio,
                out int categoriaId))
                return;

            try
            {
                using var db = new TiendaContext();

                var producto = db.Productos.Find(id);

                if (producto == null)
                {
                    MessageBox.Show("El producto no existe.");
                    CargarProductos();
                    LimpiarCampos();
                    return;
                }

                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.CategoriaId = categoriaId;

                db.SaveChanges();

                MessageBox.Show("Producto actualizado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar producto:\n" + ex.Message);
            }
        }

        // =========================================
        // ELIMINAR PRODUCTO
        // =========================================
        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecciona un producto para eliminar.");
                return;
            }

            var respuesta = MessageBox.Show(
                "¿Seguro que deseas eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using var db = new TiendaContext();

                var producto = db.Productos.Find(id);

                if (producto == null)
                {
                    MessageBox.Show("El producto ya no existe.");
                    CargarProductos();
                    LimpiarCampos();
                    return;
                }

                db.Productos.Remove(producto);
                db.SaveChanges();

                MessageBox.Show("Producto eliminado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar producto:\n" + ex.Message);
            }
        }

        // =========================================
        // SELECCIONAR PRODUCTO EN LA TABLA
        // =========================================
        private void dgvProductos_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var fila = dgvProductos.Rows[e.RowIndex];

            txtId.Text =
                fila.Cells["colId"].Value?.ToString() ?? "";

            txtNombre.Text =
                fila.Cells["colNombre"].Value?.ToString() ?? "";

            txtPrecio.Text =
                fila.Cells["colPrecio"].Value?.ToString() ?? "";

            string categoria =
                fila.Cells["colCategoria"].Value?.ToString() ?? "";

            cmbCategoria.Text = categoria;
        }

        // =========================================
        // LIMPIAR FORMULARIO
        // =========================================
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();

            cmbCategoria.SelectedIndex = -1;
            dgvProductos.ClearSelection();

            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
