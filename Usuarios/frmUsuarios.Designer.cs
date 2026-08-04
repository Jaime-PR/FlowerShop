namespace FlowerShop.Usuarios
{
    partial class frmUsuarios
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.pnlKPI1 = new System.Windows.Forms.Panel();
            this.lblUsuariosTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlKPI2 = new System.Windows.Forms.Panel();
            this.lblActivos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlKPI3 = new System.Windows.Forms.Panel();
            this.lblInactivos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlContenedorGrid = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pnlSidebarDerecho = new System.Windows.Forms.Panel();
            this.pnlKPI1.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlContenedorGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblTitulo.Location = new System.Drawing.Point(40, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 54);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Usuarios";
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(45, 85);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(188, 25);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gestiona tus usuarios";
            this.btnNuevoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.btnNuevoUsuario.FlatAppearance.BorderSize = 0;
            this.btnNuevoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoUsuario.ForeColor = System.Drawing.Color.White;
            this.btnNuevoUsuario.Location = new System.Drawing.Point(850, 45);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(200, 45);
            this.btnNuevoUsuario.TabIndex = 2;
            this.btnNuevoUsuario.Text = "+ Nuevo usuario";
            this.btnNuevoUsuario.UseVisualStyleBackColor = false;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnNuevoUsuario_Click);
            this.pnlKPI1.BackColor = System.Drawing.Color.White;
            this.pnlKPI1.Controls.Add(this.lblUsuariosTotal);
            this.pnlKPI1.Controls.Add(this.label1);
            this.pnlKPI1.Location = new System.Drawing.Point(40, 140);
            this.pnlKPI1.Name = "pnlKPI1";
            this.pnlKPI1.Size = new System.Drawing.Size(280, 130);
            this.pnlKPI1.TabIndex = 3;
            this.lblUsuariosTotal.AutoSize = true;
            this.lblUsuariosTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariosTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblUsuariosTotal.Location = new System.Drawing.Point(20, 60);
            this.lblUsuariosTotal.Name = "lblUsuariosTotal";
            this.lblUsuariosTotal.Size = new System.Drawing.Size(45, 54);
            this.lblUsuariosTotal.TabIndex = 1;
            this.lblUsuariosTotal.Text = "0";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "USUARIOS";
            this.pnlKPI2.BackColor = System.Drawing.Color.White;
            this.pnlKPI2.Controls.Add(this.lblActivos);
            this.pnlKPI2.Controls.Add(this.label3);
            this.pnlKPI2.Location = new System.Drawing.Point(340, 140);
            this.pnlKPI2.Name = "pnlKPI2";
            this.pnlKPI2.Size = new System.Drawing.Size(280, 130);
            this.pnlKPI2.TabIndex = 4;
            this.lblActivos.AutoSize = true;
            this.lblActivos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblActivos.Location = new System.Drawing.Point(20, 60);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(45, 54);
            this.lblActivos.TabIndex = 1;
            this.lblActivos.Text = "0";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "ACTIVOS";
            this.pnlKPI3.BackColor = System.Drawing.Color.White;
            this.pnlKPI3.Controls.Add(this.lblInactivos);
            this.pnlKPI3.Controls.Add(this.label5);
            this.pnlKPI3.Location = new System.Drawing.Point(640, 140);
            this.pnlKPI3.Name = "pnlKPI3";
            this.pnlKPI3.Size = new System.Drawing.Size(280, 130);
            this.pnlKPI3.TabIndex = 5;
            this.lblInactivos.AutoSize = true;
            this.lblInactivos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lblInactivos.Location = new System.Drawing.Point(20, 60);
            this.lblInactivos.Name = "lblInactivos";
            this.lblInactivos.Size = new System.Drawing.Size(45, 54);
            this.lblInactivos.TabIndex = 1;
            this.lblInactivos.Text = "0";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.label5.Location = new System.Drawing.Point(20, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "INACTIVOS";
            this.pnlContenedorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedorGrid.BackColor = System.Drawing.Color.White;
            this.pnlContenedorGrid.Controls.Add(this.dgvUsuarios);
            this.pnlContenedorGrid.Location = new System.Drawing.Point(40, 290);
            this.pnlContenedorGrid.Name = "pnlContenedorGrid";
            this.pnlContenedorGrid.Padding = new System.Windows.Forms.Padding(1);
            this.pnlContenedorGrid.Size = new System.Drawing.Size(1010, 400);
            this.pnlContenedorGrid.TabIndex = 6;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(1, 1);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvUsuarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.Size = new System.Drawing.Size(1008, 398);
            this.dgvUsuarios.TabIndex = 0;
            this.pnlSidebarDerecho.BackColor = System.Drawing.Color.White;
            this.pnlSidebarDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidebarDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebarDerecho.Location = new System.Drawing.Point(590, 0);
            this.pnlSidebarDerecho.Name = "pnlSidebarDerecho";
            this.pnlSidebarDerecho.Size = new System.Drawing.Size(500, 720);
            this.pnlSidebarDerecho.TabIndex = 7;
            this.pnlSidebarDerecho.Visible = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1090, 720);
            this.Controls.Add(this.pnlSidebarDerecho);
            this.Controls.Add(this.pnlContenedorGrid);
            this.Controls.Add(this.pnlKPI3);
            this.Controls.Add(this.pnlKPI2);
            this.Controls.Add(this.pnlKPI1);
            this.Controls.Add(this.btnNuevoUsuario);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.Resize += new System.EventHandler(this.frmUsuarios_Resize);
            this.pnlKPI1.ResumeLayout(false);
            this.pnlKPI1.PerformLayout();
            this.pnlKPI2.ResumeLayout(false);
            this.pnlKPI2.PerformLayout();
            this.pnlKPI3.ResumeLayout(false);
            this.pnlKPI3.PerformLayout();
            this.pnlContenedorGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.Panel pnlKPI1;
        private System.Windows.Forms.Label lblUsuariosTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlKPI2;
        private System.Windows.Forms.Label lblActivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlKPI3;
        private System.Windows.Forms.Label lblInactivos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlContenedorGrid;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel pnlSidebarDerecho;
    }
}



