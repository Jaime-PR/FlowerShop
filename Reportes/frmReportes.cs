using System;
using System.Data;
using System.Windows.Forms;
using FlowerShop.Modelos;

namespace FlowerShop.Reportes
{
    public partial class frmReportes : Form
    {
        private ReporteDAO reporteDAO;

        public frmReportes()
        {
            InitializeComponent();
            FlowerShop.Utilidades.UIHelper.ConfigurarAccesibilidad(this);
            FlowerShop.Utilidades.UIHelper.FormatoDataGrid(this.dgvReporte);
            reporteDAO = new ReporteDAO();
            
            // Estilos para que parezca embebido
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex < 0) return;

            try
            {
                DataTable dt = new DataTable();

                switch (cmbTipoReporte.SelectedIndex)
                {
                    case 0:
                        dt = reporteDAO.ObtenerTopProductos();
                        break;
                    case 1:
                        dt = reporteDAO.ObtenerMejoresClientes();
                        break;
                    case 2:
                        dt = reporteDAO.ObtenerResumenVentasPorDia();
                        break;
                    case 3:
                        dt = reporteDAO.ObtenerVentasPorVendedor();
                        break;
                    case 4:
                        dt = reporteDAO.ObtenerProductosPocoInventario();
                        break;
                }

                dgvReporte.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

