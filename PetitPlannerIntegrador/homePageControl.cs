using MySqlConnector;
using System;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class homePageControl : UserControl
    {
        public event EventHandler IrAInventario;
        public event EventHandler IrACalendario;
        public event EventHandler IrAAgendarEvento;



        public homePageControl()
        {
            InitializeComponent();
            CargarBusinessId(); // ← ESTA LÍNEA ES CLAVE
        }

        private void CargarBusinessId()
        {
            string userId = SessionManager.CurrentUserId;

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("❌ No hay usuario logueado");
                return;
            }

            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            // Consulta para obtener el business_id
            string query = "SELECT id_bussines FROM bussines WHERE id_user = @userId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        string businessId = result?.ToString();

                        if (!string.IsNullOrEmpty(businessId))
                        {
                            SessionManager.setIdBussines(businessId);
                        }
                        else
                        {
                            MessageBox.Show("❌ No se encontró business para este usuario");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al cargar business ID: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar que tenemos Business ID antes de navegar
            if (string.IsNullOrEmpty(SessionManager.CurrentIdBusiness))
            {
                MessageBox.Show("❌ Business ID no disponible");
                return;
            }

            IrAInventario?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IrACalendario?.Invoke(this, EventArgs.Empty);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IrAAgendarEvento?.Invoke(this, EventArgs.Empty);

        }
    }
}