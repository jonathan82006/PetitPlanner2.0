namespace PetitPlannerIntegrador
{
    partial class añadirArticulo
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
            backInventory = new Button();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxPrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // backInventory
            // 
            backInventory.Location = new Point(1609, 27);
            backInventory.Name = "backInventory";
            backInventory.Size = new Size(265, 70);
            backInventory.TabIndex = 0;
            backInventory.Text = "atras";
            backInventory.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(801, 175);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(362, 31);
            textBoxName.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(801, 247);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(362, 31);
            textBoxDescription.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(801, 316);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(362, 31);
            textBoxPrice.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(807, 143);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(807, 219);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 5;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(801, 288);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 6;
            label3.Text = "Precio";
            // 
            // button1
            // 
            button1.Location = new Point(881, 376);
            button1.Name = "button1";
            button1.Size = new Size(192, 44);
            button1.TabIndex = 7;
            button1.Text = "Añadir Articulo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // añadirArticulo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(backInventory);
            Name = "añadirArticulo";
            Size = new Size(1898, 1024);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backInventory;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}