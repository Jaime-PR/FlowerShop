namespace FlowerShop.Proveedor
{
    partial class frmProveedores
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
            this.btnAñadir = new System.Windows.Forms.Button();
            
            this.pnlPaddingCentral = new System.Windows.Forms.Panel();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.pnlSidebarDerecho = new System.Windows.Forms.Panel();
            
            this.pnlListaProveedores = new System.Windows.Forms.Panel();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            
            this.pnlDatosProv = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            
            this.label3 = new System.Windows.Forms.Label();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            
            this.label4 = new System.Windows.Forms.Label();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            
            this.label11 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            
            this.label9 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            
            this.label12 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            
            this.label6 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            
            this.label7 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            
            this.button2 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlPaddingCentral.SuspendLayout();
            this.pnlContenedorPrincipal.SuspendLayout();
            this.pnlListaProveedores.SuspendLayout();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.pnlDatosProv.SuspendLayout();
            this.SuspendLayout();
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Controls.Add(this.btnAñadir);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 100);
            this.pnlTop.TabIndex = 0;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(256, 46);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "PROVEEDORES";
            this.btnAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAñadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btnAñadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAñadir.FlatAppearance.BorderSize = 0;
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.Location = new System.Drawing.Point(950, 25);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(210, 40);
            this.btnAñadir.TabIndex = 1;
            this.btnAñadir.Text = "+ Nuevo Proveedor";
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadirCliente_Click);
            this.pnlPaddingCentral.Controls.Add(this.pnlContenedorPrincipal);
            this.pnlPaddingCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaddingCentral.Location = new System.Drawing.Point(0, 100);
            this.pnlPaddingCentral.Name = "pnlPaddingCentral";
            this.pnlPaddingCentral.Padding = new System.Windows.Forms.Padding(45, 10, 45, 30);
            this.pnlPaddingCentral.Size = new System.Drawing.Size(1200, 600);
            this.pnlPaddingCentral.TabIndex = 1;
            this.pnlSidebarDerecho.BackColor = System.Drawing.Color.White;
            this.pnlSidebarDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidebarDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebarDerecho.Location = new System.Drawing.Point(700, 0);
            this.pnlSidebarDerecho.Name = "pnlSidebarDerecho";
            this.pnlSidebarDerecho.Size = new System.Drawing.Size(500, 700);
            this.pnlSidebarDerecho.TabIndex = 6;
            this.pnlSidebarDerecho.AutoScroll = true;
            this.pnlSidebarDerecho.Visible = false;
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlContenedorPrincipal.Controls.Add(this.pnlListaProveedores);
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(45, 10);
            this.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1110, 560);
            this.pnlContenedorPrincipal.TabIndex = 0;
            this.pnlListaProveedores.BackColor = System.Drawing.Color.White;
            this.pnlListaProveedores.Controls.Add(this.dgvProveedor);
            this.pnlListaProveedores.Controls.Add(this.pnlBuscador);
            this.pnlListaProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaProveedores.Location = new System.Drawing.Point(0, 0);
            this.pnlListaProveedores.Name = "pnlListaProveedores";
            this.pnlListaProveedores.Padding = new System.Windows.Forms.Padding(15);
            this.pnlListaProveedores.Size = new System.Drawing.Size(710, 560);
            this.pnlListaProveedores.TabIndex = 0;
            this.pnlBuscador.Controls.Add(this.label13);
            this.pnlBuscador.Controls.Add(this.textBox12);
            this.pnlBuscador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscador.Location = new System.Drawing.Point(15, 15);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(680, 60);
            this.pnlBuscador.TabIndex = 0;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Buscar proveedor";
            this.textBox12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox12.Location = new System.Drawing.Point(0, 25);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(300, 30);
            this.textBox12.TabIndex = 1;
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            this.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedor.BackgroundColor = System.Drawing.Color.White;
            this.dgvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedor.Location = new System.Drawing.Point(15, 75);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            this.dgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedor.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvProveedor.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvProveedor.RowHeadersVisible = false;
            this.dgvProveedor.RowHeadersWidth = 51;
            this.dgvProveedor.RowTemplate.Height = 24;
            this.dgvProveedor.Size = new System.Drawing.Size(680, 470);
            this.dgvProveedor.TabIndex = 1;
            this.dgvProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellClick);
            this.pnlDatosProv.BackColor = System.Drawing.Color.White;
            this.pnlDatosProv.Controls.Add(this.label14);
            
            this.pnlDatosProv.Controls.Add(this.label2);
            this.pnlDatosProv.Controls.Add(this.txtNombre);
            this.pnlDatosProv.Controls.Add(this.label3);
            this.pnlDatosProv.Controls.Add(this.txtApPaterno);
            this.pnlDatosProv.Controls.Add(this.label4);
            this.pnlDatosProv.Controls.Add(this.txtApMaterno);
            
            this.pnlDatosProv.Controls.Add(this.label8);
            this.pnlDatosProv.Controls.Add(this.txtEmpresa);
            this.pnlDatosProv.Controls.Add(this.label11);
            this.pnlDatosProv.Controls.Add(this.txtCiudad);
            this.pnlDatosProv.Controls.Add(this.label10);
            this.pnlDatosProv.Controls.Add(this.txtEstado);
            this.pnlDatosProv.Controls.Add(this.label9);
            this.pnlDatosProv.Controls.Add(this.txtCP);
            this.pnlDatosProv.Controls.Add(this.label12);
            this.pnlDatosProv.Controls.Add(this.txtDireccion);
            
            this.pnlDatosProv.Controls.Add(this.label5);
            this.pnlDatosProv.Controls.Add(this.txtTelefono);
            this.pnlDatosProv.Controls.Add(this.label6);
            this.pnlDatosProv.Controls.Add(this.txtCorreo);
            this.pnlDatosProv.Controls.Add(this.label7);
            this.pnlDatosProv.Controls.Add(this.txtRFC);
            
            this.pnlDatosProv.Controls.Add(this.button2);
            this.pnlDatosProv.Controls.Add(this.btnEliminar);
            this.pnlDatosProv.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDatosProv.Location = new System.Drawing.Point(730, 0); 
            this.pnlDatosProv.Name = "pnlDatosProv";
            this.pnlDatosProv.Size = new System.Drawing.Size(380, 560);
            this.pnlDatosProv.TabIndex = 2;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.label14.Location = new System.Drawing.Point(20, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(209, 32);
            this.label14.TabIndex = 0;
            this.label14.Text = "Datos de Proveedor";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.Location = new System.Drawing.Point(20, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 27);
            this.txtNombre.TabIndex = 2;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(20, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ap. Paterno";
            this.txtApPaterno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApPaterno.Location = new System.Drawing.Point(20, 145);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(160, 27);
            this.txtApPaterno.TabIndex = 4;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(20, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ap. Materno";
            this.txtApMaterno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApMaterno.Location = new System.Drawing.Point(20, 200);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(160, 27);
            this.txtApMaterno.TabIndex = 6;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(20, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "TelÃ©fono";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(20, 255);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(160, 27);
            this.txtTelefono.TabIndex = 8;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label6.Location = new System.Drawing.Point(20, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Correo";
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCorreo.Location = new System.Drawing.Point(20, 310);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(160, 27);
            this.txtCorreo.TabIndex = 10;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label7.Location = new System.Drawing.Point(20, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "RFC";
            this.txtRFC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRFC.Location = new System.Drawing.Point(20, 365);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(160, 27);
            this.txtRFC.TabIndex = 12;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label8.Location = new System.Drawing.Point(200, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Empresa";
            this.txtEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpresa.Location = new System.Drawing.Point(200, 90);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(160, 27);
            this.txtEmpresa.TabIndex = 14;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label11.Location = new System.Drawing.Point(200, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ciudad";
            this.txtCiudad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCiudad.Location = new System.Drawing.Point(200, 145);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(160, 27);
            this.txtCiudad.TabIndex = 16;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label10.Location = new System.Drawing.Point(200, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Estado";
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstado.Location = new System.Drawing.Point(200, 200);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(160, 27);
            this.txtEstado.TabIndex = 18;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label9.Location = new System.Drawing.Point(200, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "C.P.";
            this.txtCP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCP.Location = new System.Drawing.Point(200, 255);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(160, 27);
            this.txtCP.TabIndex = 20;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label12.Location = new System.Drawing.Point(200, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 19);
            this.label12.TabIndex = 21;
            this.label12.Text = "DirecciÃ³n";
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(200, 310);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Size = new System.Drawing.Size(160, 82);
            this.txtDireccion.TabIndex = 22;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(200, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(20, 490);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 30);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlSidebarDerecho);
            this.Controls.Add(this.pnlPaddingCentral);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlPaddingCentral.ResumeLayout(false);
            this.pnlContenedorPrincipal.ResumeLayout(false);
            this.pnlListaProveedores.ResumeLayout(false);
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.pnlDatosProv.ResumeLayout(false);
            this.pnlDatosProv.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Panel pnlPaddingCentral;
        private System.Windows.Forms.Panel pnlSidebarDerecho;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.Panel pnlListaProveedores;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.Panel pnlDatosProv;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEliminar;
    }
}






