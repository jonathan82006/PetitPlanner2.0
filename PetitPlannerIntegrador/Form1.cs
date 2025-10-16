using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
namespace PetitPlannerIntegrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;

            // Validar que no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos");
                return;
            }

            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para verificar credenciales
                    string query = "SELECT COUNT(*) FROM usuarios WHERE user = @usuario AND password = @password";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    string userId = "";
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@password", password);

                    string get_idx = "SELECT id_user FROM usuarios WHERE usuario = @user";
                    MySqlCommand get_id = new MySqlCommand(get_idx, connection);

                    object id = command.ExecuteScalar();

                    if (id != null && id != DBNull.Value)
                    {
                        userId = id.ToString();
                    }

                    get_id.Parameters.AddWithValue("@password", password);


                    command.Parameters.AddWithValue("@user", usuario);


                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show(userId);


                        // Aquí abres el siguiente formulario
                        //home formPrincipal = new home();
                        //formPrincipal.Show();      // Muestra el nuevo formulario
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
