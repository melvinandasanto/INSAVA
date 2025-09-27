namespace Usuario
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.pbCambiarTema = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCambiarTema)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCambiarTema
            // 
            this.pbCambiarTema.Image = ((System.Drawing.Image)(resources.GetObject("pbCambiarTema.Image")));
            this.pbCambiarTema.Location = new System.Drawing.Point(253, 47);
            this.pbCambiarTema.Margin = new System.Windows.Forms.Padding(2);
            this.pbCambiarTema.Name = "pbCambiarTema";
            this.pbCambiarTema.Size = new System.Drawing.Size(277, 249);
            this.pbCambiarTema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCambiarTema.TabIndex = 9;
            this.pbCambiarTema.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 49);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(382, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(12, 15);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbCambiarTema);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCambiarTema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCambiarTema;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}