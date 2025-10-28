using MySqlConnector;
using System;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class LoginControl : UserControl
    {
        // Eventos para comunicación con MainForm
        public event EventHandler LoginExitoso;
        public event EventHandler<string> LoginFallido;

        public LoginControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Usar la práctica de usar 'using' en el ConnectionString
            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta OPTIMIZADA: Verifica las credenciales Y devuelve el ID en un solo paso.
                    string query = "SELECT id_user FROM usuarios WHERE user = @usuario AND password = @password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Asignar los parámetros solo una vez.
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@password", password);

                        // ExecuteScalar() devolverá el id_user si se encuentra un match, o null si no hay match.
                        object idResult = command.ExecuteScalar();

                        string userId = null;

                        if (idResult != null && idResult != DBNull.Value)
                        {
                            userId = idResult.ToString();
                        }

                        if (!string.IsNullOrEmpty(userId))
                        {
                            // Mandamos el UserId a Clase de SessionManager para hacer la variable userId global
                            SessionManager.StartSession(userId);


                            // En lugar de abrir nuevo form, disparamos evento
                            LoginExitoso?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            // Si idResult es null, significa que no se encontró el usuario/contraseña
                            LoginFallido?.Invoke(this, "Credenciales incorrectas");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión o de base de datos: {ex.Message}");
                LoginFallido?.Invoke(this, ex.Message);
            }
        }

        // Método para limpiar campos
        public void LimpiarCampos()
        {
            textBoxUsuario.Text = "";
            textBoxPassword.Text = "";
        }

        
    }
}