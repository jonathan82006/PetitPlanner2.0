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
    // MainForm.cs
    public partial class MainForm : Form
    {
        private Panel panelContenedor;

        public MainForm()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            MostrarInicio();
        }

        private void ConfigurarInterfaz()
        {
            this.Text = "Petit Planner";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            panelContenedor = new Panel();
            panelContenedor.Dock = DockStyle.Fill;
            this.Controls.Add(panelContenedor);
        }

        private void MostrarLogin()
        {
            var loginControl = new LoginControl();
            loginControl.Dock = DockStyle.Fill;
            loginControl.LoginExitoso += (s, e) => MostrarHomePage();
            loginControl.LoginFallido += (s, mensaje) =>
            {
                Console.WriteLine($"Login fallido: {mensaje}");
            };
             
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(loginControl);
        }

        private void MostrarCrearCuenta()
        {
            var CreateAccountControl = new CreateAccountControl();
            CreateAccountControl.Dock = DockStyle.Fill;
            CreateAccountControl.CuentaCreadaExitosa += (s, e) => MostrarInicio();
            CreateAccountControl.CuentaFallida += (s, mensaje) =>
            {
                // Opcional: manejar errores específicos
                Console.WriteLine($"Login fallido: {mensaje}");
            };

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(CreateAccountControl);
        }

        private void MostrarInicio()
        {
            var inicioControl = new InicioControl();
            inicioControl.Dock = DockStyle.Fill;

            // Suscribir a eventos de navegación
            inicioControl.IrALogin += (s, e) => MostrarLogin();
            inicioControl.IrACrearCuenta += (s, e) => MostrarCrearCuenta();

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(inicioControl);
        }

        private void MostrarInventario()
        {
            var inventoryControl = new inventory();
            inventoryControl.Dock = DockStyle.Fill;

            inventoryControl.IrAInicio += (s, e) => MostrarHomePage();
            inventoryControl.IrACalendario += (s, e) => MostrarCalendario();
            inventoryControl.IrAAgendarEvento += (s, e) => MostrarAgendarEvento();// ← Agregar esta línea
            inventoryControl.IrAAgregarArticulo += (s, e) => MostrarAgregarArticulo();

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(inventoryControl);
            inventoryControl.RefrescarDatos();
        }

        private void MostrarCalendario()
        {
            var calendarioControl = new calendario();
            calendarioControl.Dock = DockStyle.Fill;

            // Conectar evento de navegación
            calendarioControl.IrAInventario += (s, e) => MostrarInventario();
            calendarioControl.IrAInicio += (s, e) => MostrarHomePage();
            calendarioControl.IrAAgendarEvento += (s, e) => MostrarAgendarEvento();


            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(calendarioControl);
            calendarioControl.RefrescarDatos(); // Opcional: refrescar datos al mostrar
        }

        private void MostrarAgregarArticulo()
        {
            var agregarArticuloControl = new añadirArticulo();
            agregarArticuloControl.Dock = DockStyle.Fill;

            // Conectar eventos
            agregarArticuloControl.ArticuloAgregado += (s, e) =>
            {
                MessageBox.Show("Artículo agregado correctamente");
                MostrarInventario(); // Volver al inventario después de agregar
            };

            agregarArticuloControl.Cancelar += (s, e) => MostrarInventario(); // Volver al inventario al cancelar

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(agregarArticuloControl);
            agregarArticuloControl.LimpiarCampos(); // Limpiar campos al mostrar
        }

        private void MostrarHomePage()
        {
            var homePageControl = new homePageControl();
            homePageControl.Dock = DockStyle.Fill;

            // Conectar eventos de navegación
            homePageControl.IrAInventario += (s, e) => MostrarInventario();
            homePageControl.IrACalendario += (s, e) => MostrarCalendario();
            homePageControl.IrAAgendarEvento += (s, e) => MostrarAgendarEvento();



            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(homePageControl);
        }

        private void MostrarAgendarEvento()
        {
            var agendarEvento = new agendarEvento();
            agendarEvento.Dock = DockStyle.Fill;


            // Conectar eventos de navegación

            agendarEvento.IrAInventario += (s, e) => MostrarInventario();
            agendarEvento.IrACalendario += (s, e) => MostrarCalendario();
            agendarEvento.IrAInicio += (s, e) => MostrarHomePage();
            agendarEvento.IrAInicio += (s, e) => MostrarRealizarCotizacion();



            agendarEvento.EventoAgregado += (s, e) =>
            {
                MessageBox.Show("Artículo agregado correctamente");
                MostrarInventario(); 

            };
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(agendarEvento);
        }

        private void MostrarRealizarCotizacion()
        {
            var realizarCotizacion  = new realizarCotizacion();
            realizarCotizacion.Dock = DockStyle.Fill;

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(realizarCotizacion);
        }


    }
}
