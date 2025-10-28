namespace PetitPlannerIntegrador
{
    partial class inventory
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
            inventoryId = new Label();
            botonAtras = new Button();
            añadirArticulo = new Button();
            dataGridView1 = new DataGridView();
            homePage = new Button();
            inventary = new Button();
            calendario = new Button();
            agendar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // inventoryId
            // 
            inventoryId.AutoSize = true;
            inventoryId.Location = new Point(824, 29);
            inventoryId.Name = "inventoryId";
            inventoryId.Size = new Size(59, 25);
            inventoryId.TabIndex = 6;
            inventoryId.Text = "label4";
            // 
            // botonAtras
            // 
            botonAtras.Location = new Point(612, 12);
            botonAtras.Name = "botonAtras";
            botonAtras.Size = new Size(196, 58);
            botonAtras.TabIndex = 7;
            botonAtras.Text = "Atras";
            botonAtras.UseVisualStyleBackColor = true;
            botonAtras.Click += botonAtras_Click;
            // 
            // añadirArticulo
            // 
            añadirArticulo.Location = new Point(1502, 29);
            añadirArticulo.Name = "añadirArticulo";
            añadirArticulo.Size = new Size(196, 58);
            añadirArticulo.TabIndex = 8;
            añadirArticulo.Text = "Añadir Articulo";
            añadirArticulo.UseVisualStyleBackColor = true;
            añadirArticulo.Click += añadirArticulo_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Window;
            dataGridView1.Location = new Point(612, 136);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1086, 759);
            dataGridView1.TabIndex = 9;
            // 
            // homePage
            // 
            homePage.Location = new Point(12, 136);
            homePage.Name = "homePage";
            homePage.Size = new Size(210, 57);
            homePage.TabIndex = 10;
            homePage.Text = "Home Page";
            homePage.UseVisualStyleBackColor = true;
            homePage.Click += homePage_Click;
            // 
            // inventary
            // 
            inventary.Location = new Point(12, 222);
            inventary.Name = "inventary";
            inventary.Size = new Size(210, 61);
            inventary.TabIndex = 11;
            inventary.Text = "Inventario";
            inventary.UseVisualStyleBackColor = true;
            // 
            // calendario
            // 
            calendario.Location = new Point(12, 310);
            calendario.Name = "calendario";
            calendario.Size = new Size(210, 72);
            calendario.TabIndex = 12;
            calendario.Text = "Calendario";
            calendario.UseVisualStyleBackColor = true;
            calendario.Click += calendario_Click;
            // 
            // agendar
            // 
            agendar.Location = new Point(12, 426);
            agendar.Name = "agendar";
            agendar.Size = new Size(210, 72);
            agendar.TabIndex = 13;
            agendar.Text = "Agendar";
            agendar.UseVisualStyleBackColor = true;
            agendar.Click += agendar_Click;
            // 
            // inventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(agendar);
            Controls.Add(calendario);
            Controls.Add(inventary);
            Controls.Add(homePage);
            Controls.Add(dataGridView1);
            Controls.Add(añadirArticulo);
            Controls.Add(botonAtras);
            Controls.Add(inventoryId);
            Name = "inventory";
            Size = new Size(1898, 1024);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label inventoryId;
        private Button botonAtras;
        private Button añadirArticulo;
        private DataGridView dataGridView1;
        private Button homePage;
        private Button inventary;
        private Button calendario;
        private Button agendar;
    }
}