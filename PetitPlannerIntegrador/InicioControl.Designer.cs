namespace PetitPlannerIntegrador
{
    partial class InicioControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLogin;
        private Button btnCrearCuenta;
        private Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLogin = new Button();
            btnCrearCuenta = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(464, 333);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(214, 67);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(464, 433);
            btnCrearCuenta.Margin = new Padding(4, 5, 4, 5);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(214, 67);
            btnCrearCuenta.TabIndex = 2;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(452, 229);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(236, 43);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Petit Planner";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InicioControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCrearCuenta);
            Controls.Add(btnLogin);
            Controls.Add(lblTitulo);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InicioControl";
            Size = new Size(1143, 1000);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}