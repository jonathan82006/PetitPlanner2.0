using MySqlConnector;
using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class agendarEvento : UserControl
    {

        private string idCalender;

        // ✅ DECLARAR dtpHora como variable de clase aquí
        private DateTimePicker dtpHora;
        public event EventHandler IrAInventario;
        public event EventHandler IrAInicio;
        public event EventHandler IrACalendario;
        public event EventHandler IrAAgendarEvento;
        public event EventHandler EventoAgregado;
        public event EventHandler IrARealizarCotizacion;


        public agendarEvento()
        {
            InitializeComponent();
            CrearDateTimePicker();
            DatosDelNegocio();
        }

        private void CrearDateTimePicker()
        {
            // ✅ Ahora dtpHora es accesible en toda la clase
            dtpHora = new DateTimePicker();
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(100, 20);
            dtpHora.Location = new Point(250, 250);

            this.Controls.Add(dtpHora);
        }

        private void DatosDelNegocio()
        {
            CalenderRepositorie repo = new CalenderRepositorie();
            CalenderModel? usuarioActivo = repo.UserInformation();

            if (usuarioActivo != null)
            {
                idCalender = usuarioActivo.idCalender;
                SessionManager.setIdCalender(idCalender);
            }
            else
            {
                MessageBox.Show("Error al cargar la información de usuario o sesión expirada.");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            string nombre = nameLabel.Text;
            DateTime fechaSola = dtpFecha.Value.Date;
            TimeSpan horaSola = dtpHora.Value.TimeOfDay;
            string descripcion = descriptionLabel.Text;
            string ubicacion = ubicationEvent.Text;
            string numeroTelefono = numberPhoneEvent.Text;
            string tipoEvento = typeEvent.Text;
            string montoEvento = montoEvent.Text;



            // ✅ Ahora puedes acceder a la hora seleccionada
            string horaSeleccionada = dtpHora.Value.ToString("HH:mm");

            // Validaciones
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(tipoEvento))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }



            string connectionString = "Server=localhost;Database=petitplanner;Uid=root;Pwd=root;";

            string query = @"INSERT INTO event (id_calender, name, date, eventhour,ubication, description, numberPhone, typeEvent, monto) 
                            VALUES (@id_calender, @nombre, @fechasola, @hora,@ubication, @description,@numberPhone, @typeEvent, @Monto)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_calender", SessionManager.CurrentIdCalender);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@fechaSola", fechaSola);
                        command.Parameters.AddWithValue("@hora", horaSola);
                        command.Parameters.AddWithValue("@description", descripcion);
                        command.Parameters.AddWithValue("@ubication", ubicacion);
                        command.Parameters.AddWithValue("@numberPhone", numeroTelefono);
                        command.Parameters.AddWithValue("@typeEvent", tipoEvento);
                        command.Parameters.AddWithValue("@monto", montoEvento);



                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("✅ Evento agregado exitosamente");
                            EventoAgregado?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("❌ Error al agregar el evento");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al agregar el evento: {ex.Message}");
            }
        }

        private void homePage_Click(object sender, EventArgs e)
        {
            IrAInicio?.Invoke(this, EventArgs.Empty);
        }

        private void inventary_Click(object sender, EventArgs e)
        {
            IrAInventario?.Invoke(this, EventArgs.Empty);
        }

        private void calendario_Click(object sender, EventArgs e)
        {
            IrACalendario?.Invoke(this, EventArgs.Empty);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IrARealizarCotizacion?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler ArticuloAgregado;
    }
}