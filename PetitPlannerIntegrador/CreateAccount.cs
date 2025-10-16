using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PetitPlannerIntegrador
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron, RegexOptions.IgnoreCase);
        }
        private void create_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;
            string gmail = textBoxGmail.Text;

            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;Allow User Variables=true;";
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(gmail))
            {
                MessageBox.Show("Por favor, complete todos");
                return;
            }

            if (!EsEmailValido(gmail))
            {
                MessageBox.Show("❌ Por favor, ingrese un correo electrónico válido");
                textBoxGmail.Focus();
                return;
            }

            // Validar contraseña
            if (password.Length < 8)
            {
                MessageBox.Show("❌ La contraseña debe tener al menos 8 caracteres");
                textBoxPassword.Focus();
                return;
            }

            // Validar usuario
            if (usuario.Length < 3)
            {
                MessageBox.Show("❌ El usuario debe tener al menos 3 caracteres");
                textBoxUsuario.Focus();
                return;
            }

          

        string query = @"INSERT INTO usuarios (user, password, email) 
                        VALUES (@usuario,@password, @gmail )";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@gmail", gmail);
                        command.Parameters.AddWithValue("@password", password);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("✅ Cuenta creada exitosamente");
                            this.Close(); // Cerrar formulario después de crear cuenta
                        }
                        else
                        {
                            MessageBox.Show("❌ Error al crear la cuenta");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejar errores específicos de MySQL
                if (ex.Number == 1062) // Duplicado
                {
                    MessageBox.Show("❌ El usuario o email ya existe");
                }
                else
                {
                    MessageBox.Show($"❌ Error de base de datos: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}");
            }
        }
    }
}
    

