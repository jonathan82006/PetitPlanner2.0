namespace PetitPlannerIntegrador
{
    partial class calendario // ✅ Mismo nombre
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
            monthCalendar1 = new MonthCalendar();
            nameLabel = new Label();
            hourEvent = new Label();
            descriptionEvent = new Label();
            idCalenderLabel = new Label();
            atras = new Button();
            btnCalendario = new Button();
            inventary = new Button();
            homePage = new Button();
            agendar = new Button();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(508, 190);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(534, 68);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 25);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "label1";
            // 
            // hourEvent
            // 
            hourEvent.AutoSize = true;
            hourEvent.Location = new Point(662, 68);
            hourEvent.Name = "hourEvent";
            hourEvent.Size = new Size(59, 25);
            hourEvent.TabIndex = 2;
            hourEvent.Text = "label2";
            // 
            // descriptionEvent
            // 
            descriptionEvent.AutoSize = true;
            descriptionEvent.Location = new Point(783, 68);
            descriptionEvent.Name = "descriptionEvent";
            descriptionEvent.Size = new Size(59, 25);
            descriptionEvent.TabIndex = 4;
            descriptionEvent.Text = "label3";
            // 
            // idCalenderLabel
            // 
            idCalenderLabel.AutoSize = true;
            idCalenderLabel.Location = new Point(662, 20);
            idCalenderLabel.Name = "idCalenderLabel";
            idCalenderLabel.Size = new Size(59, 25);
            idCalenderLabel.TabIndex = 5;
            idCalenderLabel.Text = "label4";
            // 
            // atras
            // 
            atras.Location = new Point(944, 40);
            atras.Name = "atras";
            atras.Size = new Size(162, 47);
            atras.TabIndex = 6;
            atras.Text = "atras";
            atras.UseVisualStyleBackColor = true;
            // 
            // btnCalendario
            // 
            btnCalendario.Location = new Point(30, 344);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Size = new Size(210, 72);
            btnCalendario.TabIndex = 15;
            btnCalendario.Text = "Calendario";
            btnCalendario.UseVisualStyleBackColor = true;
            // 
            // inventary
            // 
            inventary.Location = new Point(30, 256);
            inventary.Name = "inventary";
            inventary.Size = new Size(210, 61);
            inventary.TabIndex = 14;
            inventary.Text = "Inventario";
            inventary.UseVisualStyleBackColor = true;
            inventary.Click += inventary_Click;
            // 
            // homePage
            // 
            homePage.Location = new Point(30, 170);
            homePage.Name = "homePage";
            homePage.Size = new Size(210, 57);
            homePage.TabIndex = 13;
            homePage.Text = "Home Page";
            homePage.UseVisualStyleBackColor = true;
            homePage.Click += homePage_Click;
            // 
            // agendar
            // 
            agendar.Location = new Point(30, 450);
            agendar.Name = "agendar";
            agendar.Size = new Size(210, 72);
            agendar.TabIndex = 16;
            agendar.Text = "Agendar";
            agendar.UseVisualStyleBackColor = true;
            agendar.Click += agendar_Click;
            // 
            // calendario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(agendar);
            Controls.Add(btnCalendario);
            Controls.Add(inventary);
            Controls.Add(homePage);
            Controls.Add(atras);
            Controls.Add(idCalenderLabel);
            Controls.Add(descriptionEvent);
            Controls.Add(hourEvent);
            Controls.Add(nameLabel);
            Controls.Add(monthCalendar1);
            Name = "calendario";
            Size = new Size(1898, 1024);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private Label nameLabel;
        private Label hourEvent;
        private Label descriptionEvent;
        private Label idCalenderLabel;
        private Button atras;
        private Button btnCalendario; // ✅ Nombre cambiado
        private Button inventary;
        private Button homePage;
        private Button agendar;
    }
}