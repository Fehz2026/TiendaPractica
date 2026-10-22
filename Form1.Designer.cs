
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TiendaPractica
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private ComboBox cmbCategoria;

        private DataGridView dgvProductos;

        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            cmbCategoria = new ComboBox();

            dgvProductos = new DataGridView();

            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            Label lblTitulo = new Label();
            Label lblId = new Label();
            Label lblNombre = new Label();
            Label lblPrecio = new Label();
            Label lblCategoria = new Label();
            Label lblListado = new Label();

            SuspendLayout();

            // CONFIGURACIÓN DEL FORMULARIO
            Text = "TiendaPractica - Gestión de Productos";
            ClientSize = new Size(980, 540);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            // TÍTULO
            lblTitulo.Text = "GESTIÓN DE PRODUCTOS";
            lblTitulo.Font = new Font(
                "Segoe UI", 18, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.AutoSize = true;

            // IDENTIFICADOR
            lblId.Text = "ID:";
            lblId.Location = new Point(30, 90);
            lblId.AutoSize = true;

            txtId.Location = new Point(30, 115);
            txtId.Size = new Size(260, 27);
            txtId.ReadOnly = true;

            // NOMBRE
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(30, 155);
            lblNombre.AutoSize = true;

            txtNombre.Location = new Point(30, 180);
            txtNombre.Size = new Size(260, 27);

            // PRECIO
            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new Point(30, 220);
            lblPrecio.AutoSize = true;

            txtPrecio.Location = new Point(30, 245);
            txtPrecio.Size = new Size(260, 27);

            // CATEGORÍA
            lblCategoria.Text = "Categoría:";
            lblCategoria.Location = new Point(30, 285);
            lblCategoria.AutoSize = true;

            cmbCategoria.Location = new Point(30, 310);
            cmbCategoria.Size = new Size(260, 28);
            cmbCategoria.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // BOTONES
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(30, 365);
            btnAgregar.Size = new Size(125, 40);

            btnActualizar.Text = "Actualizar";
            btnActualizar.Location = new Point(165, 365);
            btnActualizar.Size = new Size(125, 40);

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(30, 415);
            btnEliminar.Size = new Size(125, 40);

            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(165, 415);
            btnLimpiar.Size = new Size(125, 40);

            // LISTADO DE PRODUCTOS
            lblListado.Text = "Productos registrados";
            lblListado.Font = new Font(
                "Segoe UI", 12, FontStyle.Bold);
            lblListado.Location = new Point(330, 90);
            lblListado.AutoSize = true;

            dgvProductos.Location = new Point(330, 125);
            dgvProductos.Size = new Size(620, 365);
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLUMNAS DE LA TABLA
            dgvProductos.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    FillWeight = 35
                });

            dgvProductos.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colNombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

            dgvProductos.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colPrecio",
                    HeaderText = "Precio",
                    DataPropertyName = "Precio",
                    DefaultCellStyle =
                        new DataGridViewCellStyle
                        {
                            Format = "N2"
                        }
                });

            dgvProductos.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colCategoria",
                    HeaderText = "Categoría",
                    DataPropertyName = "Categoria"
                });

            // AGREGAR CONTROLES
            Controls.AddRange(new Control[]
            {
                lblTitulo,
                lblId, txtId,
                lblNombre, txtNombre,
                lblPrecio, txtPrecio,
                lblCategoria, cmbCategoria,
                btnAgregar, btnActualizar,
                btnEliminar, btnLimpiar,
                lblListado, dgvProductos
            });

            ResumeLayout(false);
            PerformLayout();
        }
    }
}

