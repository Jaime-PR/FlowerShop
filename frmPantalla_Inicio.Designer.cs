namespace FlowerShop
{
    partial class frmPantalla_Inicio
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.bntCategotia = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(156)))));
            this.pnlMenu.Controls.Add(this.tableLayoutPanel1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(196, 665);
            this.pnlMenu.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Controls.Add(this.btnInicio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bntCategotia, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnVentas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClientes, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnInventario, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnProveedor, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 665);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnInicio
            // 
            this.btnInicio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInicio.Location = new System.Drawing.Point(55, 30);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInicio.Size = new System.Drawing.Size(138, 50);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Iniciooooo";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnProveedor.FlatAppearance.BorderSize = 0;
            this.btnProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedor.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedor.Location = new System.Drawing.Point(55, 582);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(138, 50);
            this.btnProveedor.TabIndex = 3;
            this.btnProveedor.Text = "Proveedores";
            this.btnProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Location = new System.Drawing.Point(55, 250);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(138, 50);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // bntCategotia
            // 
            this.bntCategotia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bntCategotia.FlatAppearance.BorderSize = 0;
            this.bntCategotia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntCategotia.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCategotia.Location = new System.Drawing.Point(55, 140);
            this.bntCategotia.Name = "bntCategotia";
            this.bntCategotia.Size = new System.Drawing.Size(138, 50);
            this.bntCategotia.TabIndex = 5;
            this.bntCategotia.Text = "Categorias";
            this.bntCategotia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntCategotia.UseVisualStyleBackColor = true;
            this.bntCategotia.Click += new System.EventHandler(this.bntCategotia_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Location = new System.Drawing.Point(55, 360);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(138, 50);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(55, 470);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(138, 50);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.txtBusqueda);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1118, 70);
            this.pnlTop.TabIndex = 1;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBusqueda.Location = new System.Drawing.Point(286, 29);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(482, 22);
            this.txtBusqueda.TabIndex = 1;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(205, 3);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(910, 665);
            this.pnlContenedor.TabIndex = 2;
            this.pnlContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenedor_Paint_2);
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 2;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.06798F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.93202F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.pnlMenu, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.pnlContenedor, 1, 0);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 1;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(1118, 671);
            this.tableLayoutPanelPrincipal.TabIndex = 3;
            // 
            // frmPantalla_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 741);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmPantalla_Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPantalla_Inicio";
            this.pnlMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button bntCategotia;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
    }
}