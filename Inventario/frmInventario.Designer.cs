namespace FlowerShop.Inventario
{
    partial class frmInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAÒadir = new System.Windows.Forms.Button();
            
            this.flowLayoutPanelKPIs = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.lblKpi1Valor = new System.Windows.Forms.Label();
            this.lblKpi1Titulo = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.lblKpi2Valor = new System.Windows.Forms.Label();
            this.lblKpi2Titulo = new System.Windows.Forms.Label();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.lblKpi3Valor = new System.Windows.Forms.Label();
            this.lblKpi3Titulo = new System.Windows.Forms.Label();
            this.pnlKpi4 = new System.Windows.Forms.Panel();
            this.lblKpi4Valor = new System.Windows.Forms.Label();
            this.lblKpi4Titulo = new System.Windows.Forms.Label();

            this.pnlPaddingCentral = new System.Windows.Forms.Panel();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlDatosP = new System.Windows.Forms.Panel();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lb2 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lb3 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lb5 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lb6 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.flowLayoutPanelKPIs.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi4.SuspendLayout();
            this.pnlPaddingCentral.SuspendLayout();
            this.pnlContenedorPrincipal.SuspendLayout();
            this.btnA√±adir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnAcercar = new System.Windows.Forms.Button();
            this.btnAlejar = new System.Windows.Forms.Button();
            this.pnlDatosP.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlDatosP.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Controls.Add(this.btnAÒadir);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1391, 100);
            this.pnlTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(229, 46);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "INVENTARIO";

            // btnAÒadir
            this.btnAÒadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAÒadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btnAÒadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAÒadir.FlatAppearance.BorderSize = 0;
            this.btnAÒadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAÒadir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAÒadir.ForeColor = System.Drawing.Color.White;
            this.btnAÒadir.Location = new System.Drawing.Point(1171, 25);
            this.btnAÒadir.Name = "btnAÒadir";
            this.btnAÒadir.Size = new System.Drawing.Size(180, 40);
            this.btnAÒadir.TabIndex = 1;
            this.btnAÒadir.Text = "+ Nuevo producto";
            this.btnAÒadir.UseVisualStyleBackColor = false;
            this.btnAÒadir.Click += new System.EventHandler(this.btnAÒadir_Click);

            // flowLayoutPanelKPIs
            this.flowLayoutPanelKPIs.Controls.Add(this.pnlKpi1);
            this.flowLayoutPanelKPIs.Controls.Add(this.pnlKpi2);
            this.flowLayoutPanelKPIs.Controls.Add(this.pnlKpi3);
            this.flowLayoutPanelKPIs.Controls.Add(this.pnlKpi4);
            this.flowLayoutPanelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelKPIs.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelKPIs.Name = "flowLayoutPanelKPIs";
            this.flowLayoutPanelKPIs.Padding = new System.Windows.Forms.Padding(35, 10, 35, 10);
            this.flowLayoutPanelKPIs.Size = new System.Drawing.Size(1391, 160);
            this.flowLayoutPanelKPIs.TabIndex = 1;

            // pnlKpi1
            this.pnlKpi1.BackColor = System.Drawing.Color.White;
            this.pnlKpi1.Controls.Add(this.lblKpi1Valor);
            this.pnlKpi1.Controls.Add(this.lblKpi1Titulo);
            this.pnlKpi1.Location = new System.Drawing.Point(45, 15);
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(10, 5, 25, 5);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Size = new System.Drawing.Size(260, 120);
            this.pnlKpi1.TabIndex = 0;

            this.lblKpi1Valor.AutoSize = true;
            this.lblKpi1Valor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblKpi1Valor.Location = new System.Drawing.Point(12, 50);
            this.lblKpi1Valor.Name = "lblKpi1Valor";
            this.lblKpi1Valor.Size = new System.Drawing.Size(46, 54);
            this.lblKpi1Valor.TabIndex = 1;
            this.lblKpi1Valor.Text = "0";

            this.lblKpi1Titulo.AutoSize = true;
            this.lblKpi1Titulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpi1Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblKpi1Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblKpi1Titulo.Name = "lblKpi1Titulo";
            this.lblKpi1Titulo.Size = new System.Drawing.Size(155, 28);
            this.lblKpi1Titulo.TabIndex = 0;
            this.lblKpi1Titulo.Text = "Total Productos";

            // pnlKpi2
            this.pnlKpi2.BackColor = System.Drawing.Color.White;
            this.pnlKpi2.Controls.Add(this.lblKpi2Valor);
            this.pnlKpi2.Controls.Add(this.lblKpi2Titulo);
            this.pnlKpi2.Location = new System.Drawing.Point(340, 15);
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(10, 5, 25, 5);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Size = new System.Drawing.Size(260, 120);
            this.pnlKpi2.TabIndex = 1;

            this.lblKpi2Valor.AutoSize = true;
            this.lblKpi2Valor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblKpi2Valor.Location = new System.Drawing.Point(12, 50);
            this.lblKpi2Valor.Name = "lblKpi2Valor";
            this.lblKpi2Valor.Size = new System.Drawing.Size(46, 54);
            this.lblKpi2Valor.TabIndex = 1;
            this.lblKpi2Valor.Text = "0";

            this.lblKpi2Titulo.AutoSize = true;
            this.lblKpi2Titulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpi2Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblKpi2Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblKpi2Titulo.Name = "lblKpi2Titulo";
            this.lblKpi2Titulo.Size = new System.Drawing.Size(161, 28);
            this.lblKpi2Titulo.TabIndex = 0;
            this.lblKpi2Titulo.Text = "Bajo Inventario";

            // pnlKpi3
            this.pnlKpi3.BackColor = System.Drawing.Color.White;
            this.pnlKpi3.Controls.Add(this.lblKpi3Valor);
            this.pnlKpi3.Controls.Add(this.lblKpi3Titulo);
            this.pnlKpi3.Location = new System.Drawing.Point(635, 15);
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(10, 5, 25, 5);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Size = new System.Drawing.Size(260, 120);
            this.pnlKpi3.TabIndex = 2;

            this.lblKpi3Valor.AutoSize = true;
            this.lblKpi3Valor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblKpi3Valor.Location = new System.Drawing.Point(12, 50);
            this.lblKpi3Valor.Name = "lblKpi3Valor";
            this.lblKpi3Valor.Size = new System.Drawing.Size(46, 54);
            this.lblKpi3Valor.TabIndex = 1;
            this.lblKpi3Valor.Text = "0";

            this.lblKpi3Titulo.AutoSize = true;
            this.lblKpi3Titulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpi3Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblKpi3Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblKpi3Titulo.Name = "lblKpi3Titulo";
            this.lblKpi3Titulo.Size = new System.Drawing.Size(107, 28);
            this.lblKpi3Titulo.TabIndex = 0;
            this.lblKpi3Titulo.Text = "Categor√≠as";

            // pnlKpi4
            this.pnlKpi4.BackColor = System.Drawing.Color.White;
            this.pnlKpi4.Controls.Add(this.lblKpi4Valor);
            this.pnlKpi4.Controls.Add(this.lblKpi4Titulo);
            this.pnlKpi4.Location = new System.Drawing.Point(930, 15);
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.Size = new System.Drawing.Size(260, 120);
            this.pnlKpi4.TabIndex = 3;

            this.lblKpi4Valor.AutoSize = true;
            this.lblKpi4Valor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblKpi4Valor.Location = new System.Drawing.Point(12, 50);
            this.lblKpi4Valor.Name = "lblKpi4Valor";
            this.lblKpi4Valor.Size = new System.Drawing.Size(46, 54);
            this.lblKpi4Valor.TabIndex = 1;
            this.lblKpi4Valor.Text = "$0";

            this.lblKpi4Titulo.AutoSize = true;
            this.lblKpi4Titulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpi4Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblKpi4Titulo.Location = new System.Drawing.Point(15, 15);
            this.lblKpi4Titulo.Name = "lblKpi4Titulo";
            this.lblKpi4Titulo.Size = new System.Drawing.Size(162, 28);
            this.lblKpi4Titulo.TabIndex = 0;
            this.lblKpi4Titulo.Text = "Valor Inventario";

            // pnlPaddingCentral
            this.pnlPaddingCentral.Controls.Add(this.pnlContenedorPrincipal);
            this.pnlPaddingCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaddingCentral.Location = new System.Drawing.Point(0, 260);
            this.pnlPaddingCentral.Name = "pnlPaddingCentral";
            this.pnlPaddingCentral.Padding = new System.Windows.Forms.Padding(45, 10, 45, 30);
            this.pnlPaddingCentral.Size = new System.Drawing.Size(1391, 538);
            this.pnlPaddingCentral.TabIndex = 2;

            // pnlContenedorPrincipal
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlContenedorPrincipal.Controls.Add(this.dgvProductos);
            this.pnlContenedorPrincipal.Controls.Add(this.pnlDatosP);
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(45, 10);
            this.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1301, 498);
            this.pnlContenedorPrincipal.TabIndex = 0;

            // dgvProductos
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // Hacer que el DataGridView ocupe todo el espacio del contenedor principal
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // pnlDatosP
            this.pnlDatosP.BackColor = System.Drawing.Color.White;
            this.pnlDatosP.Controls.Add(this.lblFormulario);
            this.pnlDatosP.Controls.Add(this.btnEliminar);
            this.pnlDatosP.Controls.Add(this.btnGuardar);
            this.pnlDatosP.Controls.Add(this.txtPrecioVenta);
            this.pnlDatosP.Controls.Add(this.lb6);
            this.pnlDatosP.Controls.Add(this.txtPrecioCompra);
            this.pnlDatosP.Controls.Add(this.lb5);
            this.pnlDatosP.Controls.Add(this.txtCantidad);
            this.pnlDatosP.Controls.Add(this.lb4);
            this.pnlDatosP.Controls.Add(this.txtProveedor);
            this.pnlDatosP.Controls.Add(this.lb3);
            this.pnlDatosP.Controls.Add(this.txtCategoria);
            this.pnlDatosP.Controls.Add(this.lb2);
            this.pnlDatosP.Controls.Add(this.txtNombre);
            this.pnlDatosP.Controls.Add(this.lb1);
            this.pnlDatosP.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDatosP.Location = new System.Drawing.Point(1001, 0);
            this.pnlDatosP.Name = "pnlDatosP";
            this.pnlDatosP.Size = new System.Drawing.Size(300, 498);
            // Ocultar panel de detalle para que la tabla ocupe todo el espacio
            this.pnlDatosP.Visible = false;
            this.pnlDatosP.TabIndex = 1;

            // lblFormulario
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblFormulario.Location = new System.Drawing.Point(20, 20);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(217, 32);
            this.lblFormulario.TabIndex = 0;
            this.lblFormulario.Text = "Detalle Producto";

            this.pnlDatosP.Size = new System.Drawing.Size(263, 679);
            this.pnlDatosP.TabIndex = 6;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(19, 637);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(225, 34);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(19, 594);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(225, 37);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrecioVenta.Location = new System.Drawing.Point(19, 400);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(225, 34);
            this.txtPrecioVenta.TabIndex = 23;
            // 
            // lb6
            // 
            this.lb6.AutoSize = true;
            this.lb6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lb6.Location = new System.Drawing.Point(14, 369);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(201, 28);
            this.lb6.TabIndex = 22;
            this.lb6.Text = "Precio de venta (Mxn)";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrecioCompra.Location = new System.Drawing.Point(19, 332);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(225, 34);
            this.txtPrecioCompra.TabIndex = 21;
            // 
            // lb1
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb1.Location = new System.Drawing.Point(20, 70);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(171, 23);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "Nombre de producto";

            // txtNombre
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(20, 95);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(260, 30);
            this.txtNombre.TabIndex = 2;

            // lb2
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb2.Location = new System.Drawing.Point(20, 135);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(84, 23);
            this.lb2.TabIndex = 3;
            this.lb2.Text = "Categor√≠a";

            // txtCategoria
            this.txtCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoria.Location = new System.Drawing.Point(20, 160);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(260, 30);
            this.txtCategoria.TabIndex = 4;

            // lb3
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb3.Location = new System.Drawing.Point(20, 200);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(89, 23);
            this.lb3.TabIndex = 5;
            this.lb3.Text = "Proveedor";

            // txtProveedor
            this.txtProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProveedor.Location = new System.Drawing.Point(20, 225);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(260, 30);
            this.txtProveedor.TabIndex = 6;

            // lb4
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb4.Location = new System.Drawing.Point(20, 265);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(79, 23);
            this.lb4.TabIndex = 7;
            this.lb4.Text = "Cantidad";

            // txtCantidad
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(20, 290);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(260, 30);
            this.txtCantidad.TabIndex = 8;

            // lb5
            this.lb5.AutoSize = true;
            this.lb5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb5.Location = new System.Drawing.Point(20, 330);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(123, 23);
            this.lb5.TabIndex = 9;
            this.lb5.Text = "Precio Compra";

            // txtPrecioCompra
            this.txtPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioCompra.Location = new System.Drawing.Point(20, 355);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(260, 30);
            this.txtPrecioCompra.TabIndex = 10;

            // lb6
            this.lb6.AutoSize = true;
            this.lb6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb6.Location = new System.Drawing.Point(20, 395);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(106, 23);
            this.lb6.TabIndex = 11;
            this.lb6.Text = "Precio Venta";

            // txtPrecioVenta
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioVenta.Location = new System.Drawing.Point(20, 420);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(260, 30);
            this.txtPrecioVenta.TabIndex = 12;

            // btnGuardar
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(155, 460);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            // btnEliminar
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(20, 460);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 30);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;

            // frmInventario
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1391, 798);
            this.Controls.Add(this.pnlPaddingCentral);
            this.Controls.Add(this.flowLayoutPanelKPIs);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmInventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.frmInventario_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.flowLayoutPanelKPIs.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlKpi1.PerformLayout();
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi2.PerformLayout();
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi3.PerformLayout();
            this.pnlKpi4.ResumeLayout(false);
            this.pnlKpi4.PerformLayout();
            this.pnlPaddingCentral.ResumeLayout(false);
            this.pnlContenedorPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlDatosP.ResumeLayout(false);
            this.pnlDatosP.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAÒadir;
        
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelKPIs;
        private System.Windows.Forms.Panel pnlKpi1;
        private System.Windows.Forms.Label lblKpi1Valor;
        private System.Windows.Forms.Label lblKpi1Titulo;
        private System.Windows.Forms.Panel pnlKpi2;
        private System.Windows.Forms.Label lblKpi2Valor;
        private System.Windows.Forms.Label lblKpi2Titulo;
        private System.Windows.Forms.Panel pnlKpi3;
        private System.Windows.Forms.Label lblKpi3Valor;
        private System.Windows.Forms.Label lblKpi3Titulo;
        private System.Windows.Forms.Panel pnlKpi4;
        private System.Windows.Forms.Label lblKpi4Valor;
        private System.Windows.Forms.Label lblKpi4Titulo;

        private System.Windows.Forms.Panel pnlPaddingCentral;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel pnlDatosP;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lb6;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnA√±adir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAlejar;
        private System.Windows.Forms.Button btnAcercar;
    }
}



