using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador.Repositories;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class inventory : UserControl
    {
        private string IdInventorio;

        public event EventHandler IrAInicio;
        public event EventHandler IrACalendario;
        public event EventHandler IrAAgregarArticulo;
        public event EventHandler IrAAgendarEvento;

        public inventory()
        {
            InitializeComponent();
            EstiloInterfaz();
            DatosDelNegocio();
            cargarDatosProductos();
            AplicarRedondeadoTabla();
        }

        private void EstiloInterfaz()
        {
            this.BackColor = Color.White;

            // 🔹 Botón "Añadir artículo"
            añadirArticulo.BackColor = ColorTranslator.FromHtml("#48A868");
            añadirArticulo.FlatStyle = FlatStyle.Flat;
            añadirArticulo.FlatAppearance.BorderSize = 0;
            añadirArticulo.ForeColor = Color.White;
            añadirArticulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            añadirArticulo.Region = new Region(RoundedRect(new Rectangle(0, 0, añadirArticulo.Width, añadirArticulo.Height), 10));

            // 🔹 DataGridView
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.EnableHeadersVisualStyles = false;

            // 🔹 Header blanco, sin fondo gris
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 55;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // 🔹 Celdas
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // 🔹 Quitar encabezado de fila y color de líneas
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.GridColor = Color.White;

            // 🔹 Línea negra exacta debajo del header
            dataGridView1.Paint += (s, e) =>
            {
                int headerBottom = dataGridView1.ColumnHeadersHeight - 1;
                int anchoColumnas = 0;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Visible)
                        anchoColumnas += col.Width;
                }

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, 0, headerBottom, anchoColumnas - 1, headerBottom);
                }
            };
        }

        private void DatosDelNegocio()
        {
            InventoryRepositorie repo = new InventoryRepositorie();
            inventoryModel? usuarioActivo = repo.UserInformation();

            if (usuarioActivo != null)
            {
                IdInventorio = usuarioActivo.idInventory;
                inventoryId.Text = IdInventorio;
                SessionManager.setIdInventory(IdInventorio);
            }
            else
            {
                MessageBox.Show("Error al cargar la información de usuario o sesión expirada.");
            }
        }

        private void cargarDatosProductos()
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();

            // 🔹 PRODUCTO (más chico)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "PRODUCTO",
                DataPropertyName = "Name",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 🔹 DESCRIPCIÓN (más ancha)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDescription",
                HeaderText = "DESCRIPCIÓN",
                DataPropertyName = "Description",
                Width = 400,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 🔹 PRECIO
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "PRECIO",
                DataPropertyName = "Price",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "C2"
                }
            });

            ProductRepositorie repo = new ProductRepositorie();
            var productos = repo.GetProductsByInventoryId(SessionManager.CurrentIdInventory);
            dataGridView1.DataSource = productos;
        }

        // 🔹 Redondear la tabla
        private void AplicarRedondeadoTabla()
        {
            dataGridView1.Paint += (s, e) =>
            {
                int radio = 20;
                Rectangle rect = new Rectangle(0, 0, dataGridView1.Width - 1, dataGridView1.Height - 1);
                using (GraphicsPath path = RoundedRect(rect, radio))
                {
                    dataGridView1.Region = new Region(path);
                }
            };
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void botonAtras_Click(object sender, EventArgs e) => IrAInicio?.Invoke(this, EventArgs.Empty);
        private void homePage_Click(object sender, EventArgs e) => IrAInicio?.Invoke(this, EventArgs.Empty);
        private void calendario_Click(object sender, EventArgs e) => IrACalendario?.Invoke(this, EventArgs.Empty);
        public void RefrescarDatos() => cargarDatosProductos();
        private void añadirArticulo_Click_1(object sender, EventArgs e) => IrAAgregarArticulo?.Invoke(this, EventArgs.Empty);

        private void agendar_Click(object sender, EventArgs e)
        {
            IrAAgendarEvento?.Invoke(this, EventArgs.Empty);
        }
    }
}
