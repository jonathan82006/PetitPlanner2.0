namespace PetitPlannerIntegrador
{
    partial class homePageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(24, 120);
            button1.Name = "button1";
            button1.Size = new Size(188, 61);
            button1.TabIndex = 0;
            button1.Text = "Inventario";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(24, 217);
            button2.Name = "button2";
            button2.Size = new Size(188, 61);
            button2.TabIndex = 1;
            button2.Text = "Calendario";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(24, 310);
            button3.Name = "button3";
            button3.Size = new Size(188, 61);
            button3.TabIndex = 2;
            button3.Text = "Agendar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // homePageControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "homePageControl";
            Size = new Size(1312, 628);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
    }
}
