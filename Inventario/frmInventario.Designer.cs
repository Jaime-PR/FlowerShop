namespace FlowerShop.Inventario
{
    partial class frmInventario
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRSC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelC = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoMC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellidoPC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(156)))));
            this.pnlTop.Controls.Add(this.btnAñadir);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1232, 70);
            this.pnlTop.TabIndex = 2;
            // 
            // btnAñadir
            // 
            this.btnAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAñadir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.Location = new System.Drawing.Point(1021, 21);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(199, 34);
            this.btnAñadir.TabIndex = 4;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRSC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTelC);
            this.panel1.Controls.Add(this.txtNombreCliente);
            this.panel1.Controls.Add(this.txtApellidoMC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtApellidoPC);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(990, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 662);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(21, 519);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 34);
            this.button4.TabIndex = 6;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(21, 559);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 37);
            this.button2.TabIndex = 24;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(21, 395);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 34);
            this.textBox1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(16, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 22;
            this.label1.Text = "Proveedor";
            // 
            // txtRSC
            // 
            this.txtRSC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRSC.Location = new System.Drawing.Point(21, 327);
            this.txtRSC.Name = "txtRSC";
            this.txtRSC.Size = new System.Drawing.Size(199, 34);
            this.txtRSC.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre";
            // 
            // txtTelC
            // 
            this.txtTelC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelC.Location = new System.Drawing.Point(21, 259);
            this.txtTelC.Name = "txtTelC";
            this.txtTelC.Size = new System.Drawing.Size(199, 34);
            this.txtTelC.TabIndex = 20;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(21, 54);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(199, 34);
            this.txtNombreCliente.TabIndex = 12;
            // 
            // txtApellidoMC
            // 
            this.txtApellidoMC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtApellidoMC.Location = new System.Drawing.Point(21, 190);
            this.txtApellidoMC.Name = "txtApellidoMC";
            this.txtApellidoMC.Size = new System.Drawing.Size(199, 34);
            this.txtApellidoMC.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Precio compra (Mxn)";
            // 
            // txtApellidoPC
            // 
            this.txtApellidoPC.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtApellidoPC.Location = new System.Drawing.Point(21, 122);
            this.txtApellidoPC.Name = "txtApellidoPC";
            this.txtApellidoPC.Size = new System.Drawing.Size(199, 34);
            this.txtApellidoPC.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(16, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 28);
            this.label4.TabIndex = 15;
            this.label4.Text = "Precio venta (Mxn)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(16, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 28);
            this.label6.TabIndex = 17;
            this.label6.Text = "Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(16, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cantidad";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvProductos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 662);
            this.panel3.TabIndex = 7;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(981, 662);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbInventario_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.11599F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.88401F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1232, 668);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 738);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmInventario";
            this.Text = "frmInventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventario_Load);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelC;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtApellidoMC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellidoPC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvProductos;
    }
}