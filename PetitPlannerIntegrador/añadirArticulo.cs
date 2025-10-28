using MySqlConnector;
using System;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class añadirArticulo : UserControl
    {
        // Eventos para navegación
        public event EventHandler ArticuloAgregado;
        public event EventHandler Cancelar;

        public añadirArticulo()
        {
            InitializeComponent();
        }



        private void atras_Click(object sender, EventArgs e)
        {
            Cancelar?.Invoke(this, EventArgs.Empty);
        }

        // Método para limpiar campos
        public void LimpiarCampos()
        {
            textBoxName.Text = "";
            textBoxDescription.Text = "";
            textBoxPrice.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nombre = textBoxName.Text;
            string descripcion = textBoxDescription.Text;
            string precio = textBoxPrice.Text;

            // Validaciones
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(precio))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!decimal.TryParse(precio, out decimal precioDecimal) || precioDecimal <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido mayor a 0.");
                textBoxPrice.Focus();
                return;
            }

            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            string query = @"INSERT INTO product (Name, Description, Price, id_inventory) 
                            VALUES (@nombre, @descripcion, @precio, @id_inventory)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@precio", precioDecimal);
                        command.Parameters.AddWithValue("@id_inventory", SessionManager.CurrentIdInventory);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("✅ Artículo agregado exitosamente");
                            ArticuloAgregado?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("❌ Error al agregar el artículo");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al agregar el artículo: {ex.Message}");
            } } }
}
