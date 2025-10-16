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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = new Form1(); // Usa Form1 en lugar de "home"
            formPrincipal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount formPrincipal = new CreateAccount(); // Usa Form1 en lugar de "home"
            formPrincipal.Show();
            this.Hide();
        }
    }
}
