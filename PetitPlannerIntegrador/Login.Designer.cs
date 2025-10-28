namespace PetitPlannerIntegrador
{
    partial class LoginControl
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxUsuario;
        private TextBox textBoxPassword;
        private Button button1;
        private Label label1;
        private Label label2;

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
            this.textBoxUsuario = new TextBox();
            this.textBoxPassword = new TextBox();
            this.button1 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new Point(100, 50);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new Size(200, 23);
            this.textBoxUsuario.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new Point(100, 100);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new Size(200, 23);
            this.textBoxPassword.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new Point(150, 150);
            this.button1.Name = "button1";
            this.button1.Size = new Size(100, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(100, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(47, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(100, 80);
            this.label2.Name = "label2";
            this.label2.Size = new Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsuario);
            this.Name = "LoginControl";
            this.Size = new Size(400, 250);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}