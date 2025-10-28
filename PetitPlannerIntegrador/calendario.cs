using PetitPlannerIntegrador.Models;
using PetitPlannerIntegrador.Repositories;
using System;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class calendario : UserControl
    {
        private string idCalender;
        private string idEvent;
        private string eventName; // Cambiado de "Name"
        private string eventHour;
        private string eventDescription; // Cambiado de "Description"
        private string dateEvent;

        // Evento para navegación
        public event EventHandler IrAInicio;
        public event EventHandler IrAInventario;
        public event EventHandler IrAAgendarEvento;


        public calendario()
        {
            InitializeComponent();
            CargarDatosCalender();
            CargarDatosEvento();
        }

        private void CargarDatosCalender()
        {
            CalenderRepositorie repo = new CalenderRepositorie();
            CalenderModel? usuarioActivo = repo.UserInformation();

            if (usuarioActivo == null)
            {
                MessageBox.Show("No se encontraron datos del calendario.");
                return;
            }
            if (string.IsNullOrEmpty(usuarioActivo.idCalender))
            {
                MessageBox.Show("El ID del calendario está vacío.");
                return;
            }

            idCalender = usuarioActivo.idCalender;
            SessionManager.setIdCalender(idCalender);
            MessageBox.Show($"ID de calendario obtenido: {idCalender}");

            if (string.IsNullOrEmpty(SessionManager.CurrentIdCalender))
            {
                MessageBox.Show("No hay ID de calendario disponible.");
                return;
            }

            if (usuarioActivo != null)
            {
                idCalenderLabel.Text = idCalender;
            }
            else
            {
                MessageBox.Show("No se encontraron productos para este inventario.");
            }
        }

        private void CargarDatosEvento()
        {
            EventRepositorie repo = new EventRepositorie();
            EventModel? usuarioActivo = repo.UserInformation();

            if (usuarioActivo == null)
            {
                MessageBox.Show("No se encontraron eventos.");
                return;
            }

            idEvent = usuarioActivo.IdEvent;
            SessionManager.setIdEvent(idEvent);
            MessageBox.Show($"ID de evento obtenido: {idEvent}");

            if (string.IsNullOrEmpty(SessionManager.CurrentIdEvent))
            {
                MessageBox.Show("No hay ID de evento disponible.");
                return;
            }

            if (usuarioActivo != null)
            {
                idEvent = usuarioActivo.IdEvent;
                idCalender = usuarioActivo.IdCalender;
                eventName = usuarioActivo.Name; // Usando el nuevo nombre
                eventHour = usuarioActivo.Eventhour;
                dateEvent = usuarioActivo.Date;
                eventDescription = usuarioActivo.Description; // Usando el nuevo nombre

                idCalenderLabel.Text = idCalender;
                nameLabel.Text = eventName;
                hourEvent.Text = eventHour;
                descriptionEvent.Text = eventDescription;

                // Manejo seguro de la fecha
                if (DateTime.TryParse(dateEvent, out DateTime fechaEvento))
                {
                    monthCalendar1.SetDate(fechaEvento);
                }
                else
                {
                    MessageBox.Show("La fecha del evento no es válida.");
                }
            }
            else
            {
                MessageBox.Show("No se encontraron eventos para este calendario.");
            }
        }

        // Método para refrescar datos cuando se muestre este control
        public void RefrescarDatos()
        {
            CargarDatosCalender();
            CargarDatosEvento();
        }

        private void inventary_Click(object sender, EventArgs e)
        {
            IrAInventario?.Invoke(this, EventArgs.Empty);
        }

        private void homePage_Click(object sender, EventArgs e)
        {
            IrAInicio?.Invoke(this, EventArgs.Empty);
        }

        private void agendar_Click(object sender, EventArgs e)
        {
            IrAAgendarEvento?.Invoke(this, EventArgs.Empty);

        }
    }
}