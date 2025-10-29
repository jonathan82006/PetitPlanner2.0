namespace PetitPlannerIntegrador
{
    partial class LoginControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelLogin;
        private Label labelTitulo;
        private Label labelUser;
        private Label labelPass;
        private Panel panelUser;
        private Panel panelPass;
        private TextBox textBoxUsuario;
        private TextBox textBoxPassword;
        private Button buttonLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelLogin = new Panel();
            labelTitulo = new Label();
            labelUser = new Label();
            labelPass = new Label();
            panelUser = new Panel();
            textBoxUsuario = new TextBox();
            panelPass = new Panel();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            panelLogin.SuspendLayout();
            panelUser.SuspendLayout();
            panelPass.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelTitulo);
            panelLogin.Controls.Add(labelUser);
            panelLogin.Controls.Add(labelPass);
            panelLogin.Controls.Add(panelUser);
            panelLogin.Controls.Add(panelPass);
            panelLogin.Controls.Add(buttonLogin);
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(400, 380);
            panelLogin.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.Dock = DockStyle.Top;
            labelTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(0, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(400, 70);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Inicia Sesión";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.ForeColor = Color.FromArgb(180, 180, 200);
            labelUser.Location = new Point(60, 90);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(41, 20);
            labelUser.TabIndex = 1;
            labelUser.Text = "User:";
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.ForeColor = Color.FromArgb(180, 180, 200);
            labelPass.Location = new Point(60, 170);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(73, 20);
            labelPass.TabIndex = 2;
            labelPass.Text = "Password:";
            // 
            // panelUser
            // 
            panelUser.BackColor = Color.FromArgb(65, 60, 140);
            panelUser.Controls.Add(textBoxUsuario);
            panelUser.Location = new Point(60, 110);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(280, 40);
            panelUser.TabIndex = 3;
            //
            //textBoxUsuario
            //
            textBoxUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsuario.BackColor = Color.FromArgb(65, 60, 140);
            textBoxUsuario.BorderStyle = BorderStyle.None;
            textBoxUsuario.Font = new Font("Segoe UI", 10F);
            textBoxUsuario.ForeColor = Color.White;
            textBoxUsuario.Location = new Point(8, 8);       // 🔹 adds padding
            textBoxUsuario.Width = 264;                      // 🔹 smaller width so text stays inside panel
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.PlaceholderText = "Ingresa tu usuario";
            textBoxUsuario.Size = new Size(264, 23);
            textBoxUsuario.TabIndex = 0;
            // 
            // panelPass
            // 
            panelPass.BackColor = Color.FromArgb(65, 60, 140);
            panelPass.Controls.Add(textBoxPassword);
            panelPass.Location = new Point(60, 190);
            panelPass.Name = "panelPass";
            panelPass.Size = new Size(280, 40);
            panelPass.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.BackColor = Color.FromArgb(65, 60, 140);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.Location = new Point(8, 8);       // 🔹 adds padding
            textBoxPassword.Width = 264;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Ingresa tu contraseña";
            textBoxPassword.Size = new Size(264, 23);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.White;
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 11F);
            buttonLogin.ForeColor = Color.FromArgb(30, 27, 84);
            buttonLogin.Location = new Point(125, 270);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(150, 40);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // LoginControl
            // 
            Controls.Add(panelLogin);
            Name = "LoginControl";
            Size = new Size(800, 600);
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            panelPass.ResumeLayout(false);
            panelPass.PerformLayout();
            ResumeLayout(false);
        }
    }
}

