namespace Usuario
{
    partial class UCVENTA
    {
        /// <summary> 
        /// Variable del dise�ador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se est�n usando.
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

        #region C�digo generado por el Dise�ador de componentes

        /// <summary> 
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar
        /// el contenido de este m�todo con el editor de c�digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbStock = new System.Windows.Forms.RadioButton();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.txtCantidadPedido = new System.Windows.Forms.TextBox();
            this.lbltotalventa = new System.Windows.Forms.Label();
            this.lbltotalpedido = new System.Windows.Forms.Label();
            this.btnCancelarPedidos = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.CBOperacion = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaquila = new System.Windows.Forms.TextBox();
            this.lblMaquila = new System.Windows.Forms.Label();
            this.lblestock = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.txtStockoporcent = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.LblProducto = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.rbStock);
            this.panel3.Controls.Add(this.dgvPedido);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.CBOperacion);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1680, 944);
            this.panel3.TabIndex = 6;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(140, 13);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(137, 36);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cliente";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbStock
            // 
            this.rbStock.AutoSize = true;
            this.rbStock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStock.Location = new System.Drawing.Point(16, 13);
            this.rbStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbStock.Name = "rbStock";
            this.rbStock.Size = new System.Drawing.Size(120, 36);
            this.rbStock.TabIndex = 11;
            this.rbStock.TabStop = true;
            this.rbStock.Text = "Stock";
            this.rbStock.UseVisualStyleBackColor = true;
            // 
            // dgvPedido
            // 
            this.dgvPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(16, 285);
            this.dgvPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.RowHeadersWidth = 82;
            this.dgvPedido.RowTemplate.Height = 33;
            this.dgvPedido.Size = new System.Drawing.Size(1250, 658);
            this.dgvPedido.TabIndex = 10;
            this.dgvPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPedido_CellClick);
            this.dgvPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPedido_CellEndEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTotalPagar);
            this.groupBox3.Controls.Add(this.txtCantidadPedido);
            this.groupBox3.Controls.Add(this.lbltotalventa);
            this.groupBox3.Controls.Add(this.lbltotalpedido);
            this.groupBox3.Controls.Add(this.btnCancelarPedidos);
            this.groupBox3.Controls.Add(this.btnCobrar);
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1280, 285);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(388, 658);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalles Venta";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(80, 329);
            this.txtTotalPagar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(200, 39);
            this.txtTotalPagar.TabIndex = 16;
            // 
            // txtCantidadPedido
            // 
            this.txtCantidadPedido.Location = new System.Drawing.Point(80, 181);
            this.txtCantidadPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidadPedido.Name = "txtCantidadPedido";
            this.txtCantidadPedido.ReadOnly = true;
            this.txtCantidadPedido.Size = new System.Drawing.Size(200, 39);
            this.txtCantidadPedido.TabIndex = 15;
            // 
            // lbltotalventa
            // 
            this.lbltotalventa.AutoSize = true;
            this.lbltotalventa.Location = new System.Drawing.Point(74, 273);
            this.lbltotalventa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalventa.Name = "lbltotalventa";
            this.lbltotalventa.Size = new System.Drawing.Size(207, 32);
            this.lbltotalventa.TabIndex = 14;
            this.lbltotalventa.Text = "Total De Venta";
            // 
            // lbltotalpedido
            // 
            this.lbltotalpedido.AutoSize = true;
            this.lbltotalpedido.Location = new System.Drawing.Point(64, 123);
            this.lbltotalpedido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalpedido.Name = "lbltotalpedido";
            this.lbltotalpedido.Size = new System.Drawing.Size(236, 32);
            this.lbltotalpedido.TabIndex = 13;
            this.lbltotalpedido.Text = "Total De Pedidos";
            // 
            // btnCancelarPedidos
            // 
            this.btnCancelarPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarPedidos.Location = new System.Drawing.Point(6, 460);
            this.btnCancelarPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelarPedidos.Name = "btnCancelarPedidos";
            this.btnCancelarPedidos.Size = new System.Drawing.Size(372, 77);
            this.btnCancelarPedidos.TabIndex = 12;
            this.btnCancelarPedidos.Text = "Cancelar Pedidos";
            this.btnCancelarPedidos.UseVisualStyleBackColor = true;
            this.btnCancelarPedidos.Click += new System.EventHandler(this.btnCancelarPedidos_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.Location = new System.Drawing.Point(6, 567);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(372, 75);
            this.btnCobrar.TabIndex = 11;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // CBOperacion
            // 
            this.CBOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBOperacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOperacion.FormattingEnabled = true;
            this.CBOperacion.Items.AddRange(new object[] {
            "Producto/Semilla",
            "Maquila"});
            this.CBOperacion.Location = new System.Drawing.Point(1296, 13);
            this.CBOperacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBOperacion.Name = "CBOperacion";
            this.CBOperacion.Size = new System.Drawing.Size(364, 40);
            this.CBOperacion.TabIndex = 8;
            this.CBOperacion.SelectedIndexChanged += new System.EventHandler(this.CBOperacion_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMaquila);
            this.groupBox1.Controls.Add(this.lblMaquila);
            this.groupBox1.Controls.Add(this.lblestock);
            this.groupBox1.Controls.Add(this.nudCantidad);
            this.groupBox1.Controls.Add(this.LblCantidad);
            this.groupBox1.Controls.Add(this.txtStockoporcent);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(940, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(726, 204);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Producto";
            // 
            // txtMaquila
            // 
            this.txtMaquila.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtMaquila.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaquila.Location = new System.Drawing.Point(142, 135);
            this.txtMaquila.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaquila.Multiline = true;
            this.txtMaquila.Name = "txtMaquila";
            this.txtMaquila.ReadOnly = true;
            this.txtMaquila.Size = new System.Drawing.Size(166, 46);
            this.txtMaquila.TabIndex = 148;
            // 
            // lblMaquila
            // 
            this.lblMaquila.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMaquila.AutoSize = true;
            this.lblMaquila.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaquila.Location = new System.Drawing.Point(8, 137);
            this.lblMaquila.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaquila.Name = "lblMaquila";
            this.lblMaquila.Size = new System.Drawing.Size(115, 32);
            this.lblMaquila.TabIndex = 147;
            this.lblMaquila.Text = "Maquila";
            // 
            // lblestock
            // 
            this.lblestock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblestock.AutoSize = true;
            this.lblestock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestock.Location = new System.Drawing.Point(290, 62);
            this.lblestock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblestock.Name = "lblestock";
            this.lblestock.Size = new System.Drawing.Size(89, 32);
            this.lblestock.TabIndex = 146;
            this.lblestock.Text = "Stock";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(420, 135);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 41);
            this.nudCantidad.TabIndex = 145;
            // 
            // LblCantidad
            // 
            this.LblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(316, 137);
            this.LblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(84, 32);
            this.LblCantidad.TabIndex = 144;
            this.LblCantidad.Text = "Cant.";
            // 
            // txtStockoporcent
            // 
            this.txtStockoporcent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStockoporcent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockoporcent.Location = new System.Drawing.Point(388, 58);
            this.txtStockoporcent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStockoporcent.Multiline = true;
            this.txtStockoporcent.Name = "txtStockoporcent";
            this.txtStockoporcent.ReadOnly = true;
            this.txtStockoporcent.Size = new System.Drawing.Size(152, 46);
            this.txtStockoporcent.TabIndex = 143;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPrecio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(114, 56);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(166, 46);
            this.txtPrecio.TabIndex = 141;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(8, 58);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(99, 32);
            this.lblPrecio.TabIndex = 140;
            this.lblPrecio.Text = "Precio";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(556, 21);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(164, 177);
            this.btnAgregar.TabIndex = 139;
            this.btnAgregar.Text = "AGREGAR AL PEDIDO";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbProducto);
            this.groupBox2.Controls.Add(this.BtnBuscar);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.LblProducto);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(920, 204);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripcion del Producto";
            // 
            // cmbProducto
            // 
            this.cmbProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProducto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(20, 81);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(882, 41);
            this.cmbProducto.TabIndex = 144;
            this.cmbProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CmbProducto_KeyUp);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(304, 127);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(596, 71);
            this.BtnBuscar.TabIndex = 143;
            this.BtnBuscar.Text = "Buscar Producto";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 127);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(276, 71);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // LblProducto
            // 
            this.LblProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblProducto.AutoSize = true;
            this.LblProducto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProducto.Location = new System.Drawing.Point(18, 42);
            this.LblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProducto.Name = "LblProducto";
            this.LblProducto.Size = new System.Drawing.Size(295, 32);
            this.LblProducto.TabIndex = 141;
            this.LblProducto.Text = "Nombre del Producto";
            // 
            // FVENTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FVENTA";
            this.Size = new System.Drawing.Size(1680, 944);
            this.Load += new System.EventHandler(this.FVENTA_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblestock;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.TextBox txtStockoporcent;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label LblProducto;
        private System.Windows.Forms.ComboBox CBOperacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.TextBox txtCantidadPedido;
        private System.Windows.Forms.Label lbltotalventa;
        private System.Windows.Forms.Label lbltotalpedido;
        private System.Windows.Forms.Button btnCancelarPedidos;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbStock;
        private System.Windows.Forms.TextBox txtMaquila;
        private System.Windows.Forms.Label lblMaquila;
    }
}
