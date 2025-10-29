using MySqlConnector;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler LoginExitoso;
        public event EventHandler<string> LoginFallido;

        public LoginControl()
        {
            InitializeComponent();
            this.Resize += LoginControl_Resize;
            this.Load += LoginControl_Load;
        }

        private void Redondear(Control c, int radio)
        {
            if (c.Width <= 0 || c.Height <= 0) return;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(c.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(c.Width - radio, c.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, c.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            c.Region = new Region(path);
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(220, 220, 230); // Fondo gris claro
            panelLogin.BackColor = Color.FromArgb(30, 27, 84); // Azul oscuro
            panelUser.BackColor = Color.FromArgb(65, 60, 140); // Azul medio
            panelPass.BackColor = Color.FromArgb(65, 60, 140);

            labelTitulo.ForeColor = Color.White;
            labelUser.ForeColor = Color.FromArgb(180, 180, 200);
            labelPass.ForeColor = Color.FromArgb(180, 180, 200);

            buttonLogin.BackColor = Color.White;
            buttonLogin.ForeColor = Color.FromArgb(30, 27, 84);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Cursor = Cursors.Hand;

            // Bordes redondeados
            Redondear(panelLogin, 30);
            Redondear(panelUser, 10);
            Redondear(panelPass, 10);
            Redondear(buttonLogin, 10);

            CentrarPanel();
        }

        private void LoginControl_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        private void CentrarPanel()
        {
            if (panelLogin == null) return;
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_user FROM usuarios WHERE user = @usuario AND password = @password";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@password", password);

                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string userId = result.ToString();
                            SessionManager.StartSession(userId);
                            LoginExitoso?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            LoginFallido?.Invoke(this, "Credenciales incorrectas");
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginFallido?.Invoke(this, ex.Message);
            }
        }

        public void LimpiarCampos()
        {
            textBoxUsuario.Text = "";
            textBoxPassword.Text = "";
        }
    }
}

