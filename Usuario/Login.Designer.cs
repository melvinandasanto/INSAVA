﻿namespace Usuario
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.pbCambiarTema = new System.Windows.Forms.PictureBox();
            this.pbContra = new System.Windows.Forms.PictureBox();
            this.lblolvidocontra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCambiarTema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContra)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(383, 124);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(545, 45);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(383, 246);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(6);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(545, 45);
            this.txtContrasena.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(674, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese su usuario y contraseña para acceder.";
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chartreuse;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(590, 356);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(159, 65);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chartreuse;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(761, 356);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(167, 65);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbUsuario
            // 
            this.pbUsuario.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbUsuario.Image = ((System.Drawing.Image)(resources.GetObject("pbUsuario.Image")));
            this.pbUsuario.Location = new System.Drawing.Point(308, 124);
            this.pbUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(63, 45);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsuario.TabIndex = 7;
            this.pbUsuario.TabStop = false;
            // 
            // pbCambiarTema
            // 
            this.pbCambiarTema.Image = ((System.Drawing.Image)(resources.GetObject("pbCambiarTema.Image")));
            this.pbCambiarTema.Location = new System.Drawing.Point(1, 2);
            this.pbCambiarTema.Name = "pbCambiarTema";
            this.pbCambiarTema.Size = new System.Drawing.Size(252, 233);
            this.pbCambiarTema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCambiarTema.TabIndex = 8;
            this.pbCambiarTema.TabStop = false;
            this.pbCambiarTema.Click += new System.EventHandler(this.lblCambiarTema_Click);
            // 
            // pbContra
            // 
            this.pbContra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbContra.Image = ((System.Drawing.Image)(resources.GetObject("pbContra.Image")));
            this.pbContra.Location = new System.Drawing.Point(308, 246);
            this.pbContra.Margin = new System.Windows.Forms.Padding(6);
            this.pbContra.Name = "pbContra";
            this.pbContra.Size = new System.Drawing.Size(63, 45);
            this.pbContra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbContra.TabIndex = 9;
            this.pbContra.TabStop = false;
            // 
            // lblolvidocontra
            // 
            this.lblolvidocontra.AutoSize = true;
            this.lblolvidocontra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblolvidocontra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblolvidocontra.Location = new System.Drawing.Point(17, 374);
            this.lblolvidocontra.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblolvidocontra.Name = "lblolvidocontra";
            this.lblolvidocontra.Size = new System.Drawing.Size(378, 30);
            this.lblolvidocontra.TabIndex = 17;
            this.lblolvidocontra.Text = "¿Ha olvidado su contraseña?";
            this.lblolvidocontra.Click += new System.EventHandler(this.lblolvidocontra_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(976, 466);
            this.Controls.Add(this.lblolvidocontra);
            this.Controls.Add(this.pbContra);
            this.Controls.Add(this.pbCambiarTema);
            this.Controls.Add(this.pbUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "INSAVA";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCambiarTema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.PictureBox pbCambiarTema;
        private System.Windows.Forms.PictureBox pbContra;
        private System.Windows.Forms.Label lblolvidocontra;
    }
}

