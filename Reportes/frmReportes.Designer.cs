namespace FlowerShop.Reportes
{
    partial class frmReportes
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

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(146, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes y Estad�sticas";
            this.pnlFiltro.BackColor = System.Drawing.Color.White;
            this.pnlFiltro.Controls.Add(this.cmbTipoReporte);
            this.pnlFiltro.Controls.Add(this.lblTipoReporte);
            this.pnlFiltro.Location = new System.Drawing.Point(36, 70);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(960, 60);
            this.pnlFiltro.TabIndex = 1;
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoReporte.ForeColor = System.Drawing.Color.Gray;
            this.lblTipoReporte.Location = new System.Drawing.Point(20, 20);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(130, 20);
            this.lblTipoReporte.TabIndex = 0;
            this.lblTipoReporte.Text = "Tipo de Reporte:";
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(160, 18);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(250, 24);
            this.cmbTipoReporte.TabIndex = 1;
            this.cmbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReporte_SelectedIndexChanged);
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(223)))));
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(36, 150);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.RowTemplate.Height = 35;
            this.dgvReporte.Size = new System.Drawing.Size(960, 400);
            this.dgvReporte.TabIndex = 2;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1044, 570);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
    }
}



