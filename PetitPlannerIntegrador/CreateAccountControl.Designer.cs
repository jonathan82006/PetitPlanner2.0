namespace PetitPlannerIntegrador
{
    partial class CreateAccountControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            create = new Button();
            user = new Label();
            password = new Label();
            gmail = new Label();
            textBoxUsuario = new TextBox();
            textBoxPassword = new TextBox();
            textBoxGmail = new TextBox();
            SuspendLayout();
            // 
            // create
            // 
            create.Location = new Point(326, 321);
            create.Name = "create";
            create.Size = new Size(184, 41);
            create.TabIndex = 0;
            create.Text = "button1";
            create.UseVisualStyleBackColor = true;
            create.Click += create_Click;
            // 
            // user
            // 
            user.AutoSize = true;
            user.Location = new Point(336, 90);
            user.Name = "user";
            user.Size = new Size(47, 25);
            user.TabIndex = 1;
            user.Text = "User";
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(336, 161);
            password.Name = "password";
            password.Size = new Size(89, 25);
            password.TabIndex = 2;
            password.Text = "password";
            // 
            // gmail
            // 
            gmail.AutoSize = true;
            gmail.Location = new Point(336, 235);
            gmail.Name = "gmail";
            gmail.Size = new Size(56, 25);
            gmail.TabIndex = 3;
            gmail.Text = "gmail";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(336, 127);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(174, 31);
            textBoxUsuario.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(336, 192);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(174, 31);
            textBoxPassword.TabIndex = 5;
            // 
            // textBoxGmail
            // 
            textBoxGmail.Location = new Point(336, 263);
            textBoxGmail.Name = "textBoxGmail";
            textBoxGmail.Size = new Size(174, 31);
            textBoxGmail.TabIndex = 6;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(textBoxGmail);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsuario);
            Controls.Add(gmail);
            Controls.Add(password);
            Controls.Add(user);
            Controls.Add(create);
            Name = "CreateAccount";
            Text = "CreateAccount";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button create;
        private Label user;
        private Label password;
        private Label gmail;
        private TextBox textBoxUsuario;
        private TextBox textBoxPassword;
        private TextBox textBoxGmail;
    }
}