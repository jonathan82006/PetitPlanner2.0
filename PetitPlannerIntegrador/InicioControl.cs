using System;
using System.Windows.Forms;

namespace PetitPlannerIntegrador
{
    public partial class InicioControl : UserControl
    {
        // Eventos para navegación
        public event EventHandler IrALogin;
        public event EventHandler IrACrearCuenta;

        public InicioControl()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IrALogin?.Invoke(this, EventArgs.Empty);
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            IrACrearCuenta?.Invoke(this, EventArgs.Empty);
        }
    }
}