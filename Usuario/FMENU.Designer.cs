namespace Usuario
{
    partial class FMENU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMENU));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LlamaVentas = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.CambiaTema = new System.Windows.Forms.ToolStripButton();
            this.LlamaClientes = new System.Windows.Forms.ToolStripButton();
            this.LlamaInventario = new System.Windows.Forms.ToolStripButton();
            this.LlamaUsuarios = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.btnFacturas = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LlamaVentas,
            this.toolStripButton3,
            this.toolStripButton5,
            this.CambiaTema,
            this.LlamaClientes,
            this.LlamaInventario,
            this.LlamaUsuarios,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1440, 50);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseDown);
            // 
            // LlamaVentas
            // 
            this.LlamaVentas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlamaVentas.Image = ((System.Drawing.Image)(resources.GetObject("LlamaVentas.Image")));
            this.LlamaVentas.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.LlamaVentas.Name = "LlamaVentas";
            this.LlamaVentas.Size = new System.Drawing.Size(160, 44);
            this.LlamaVentas.Text = "Ventas";
            this.LlamaVentas.Click += new System.EventHandler(this.LlamaVentas_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(46, 44);
            this.toolStripButton3.Text = "btnCerrar";
            this.toolStripButton3.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(46, 44);
            this.toolStripButton5.Text = "btnMinimizar";
            this.toolStripButton5.Click += new System.EventHandler(this.Minimizar_Click);
            // 
            // CambiaTema
            // 
            this.CambiaTema.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CambiaTema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CambiaTema.Image = ((System.Drawing.Image)(resources.GetObject("CambiaTema.Image")));
            this.CambiaTema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CambiaTema.Name = "CambiaTema";
            this.CambiaTema.Size = new System.Drawing.Size(46, 44);
            this.CambiaTema.Text = "tsbtnCambiarTema";
            this.CambiaTema.Click += new System.EventHandler(this.tsbtnCambiarTema_Click);
            // 
            // LlamaClientes
            // 
            this.LlamaClientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlamaClientes.Image = ((System.Drawing.Image)(resources.GetObject("LlamaClientes.Image")));
            this.LlamaClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LlamaClientes.Name = "LlamaClientes";
            this.LlamaClientes.Size = new System.Drawing.Size(180, 44);
            this.LlamaClientes.Text = "Clientes";
            this.LlamaClientes.Click += new System.EventHandler(this.LlamaClientes_Click);
            // 
            // LlamaInventario
            // 
            this.LlamaInventario.Image = ((System.Drawing.Image)(resources.GetObject("LlamaInventario.Image")));
            this.LlamaInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LlamaInventario.Name = "LlamaInventario";
            this.LlamaInventario.Size = new System.Drawing.Size(209, 44);
            this.LlamaInventario.Text = "Inventario";
            this.LlamaInventario.Click += new System.EventHandler(this.LlamaInventario_Click);
            // 
            // LlamaUsuarios
            // 
            this.LlamaUsuarios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlamaUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("LlamaUsuarios.Image")));
            this.LlamaUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LlamaUsuarios.Name = "LlamaUsuarios";
            this.LlamaUsuarios.Size = new System.Drawing.Size(191, 44);
            this.LlamaUsuarios.Text = "Usuarios";
            this.LlamaUsuarios.Click += new System.EventHandler(this.LlamaUsuarios_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(203, 44);
            this.toolStripButton1.Text = "Buscador";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Controls.Add(this.toolStrip2);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 50);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1440, 759);
            this.panelContenedor.TabIndex = 18;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientes,
            this.btnFacturas});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(1440, 47);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // btnClientes
            // 
            this.btnClientes.Image = global::Usuario.Properties.Resources.add_friend;
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(180, 41);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Image = global::Usuario.Properties.Resources.invoice__1_;
            this.btnFacturas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(190, 41);
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // FMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1440, 809);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FMENU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FMENU_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton LlamaVentas;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton CambiaTema;
        private System.Windows.Forms.ToolStripButton LlamaClientes;
        private System.Windows.Forms.ToolStripButton LlamaInventario;
        private System.Windows.Forms.ToolStripButton LlamaUsuarios;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripButton btnFacturas;
    }
}