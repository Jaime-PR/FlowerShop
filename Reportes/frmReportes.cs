using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Modelos;

namespace FlowerShop.Reportes
{
    public partial class frmReportes : Form
    {
        private ReportesDAO dao = new ReportesDAO();

        public frmReportes()
        {
            InitializeComponent();
            FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvReporte);
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            cmbTipoReporte.Items.Add("Productos Bajo Inventario");
            cmbTipoReporte.Items.Add("Últimas Ventas");
            cmbTipoReporte.Items.Add("Distribución de Clientes");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReporteSeleccionado();
        }

        private void CargarReporteSeleccionado()
        {
            if (cmbTipoReporte.SelectedItem == null) return;
            string seleccion = cmbTipoReporte.SelectedItem.ToString();

            if (seleccion == "Productos Bajo Inventario")
            {
                dgvReporte.DataSource = dao.ObtenerProductosBajoInventario(10);
            }
            else if (seleccion == "Últimas Ventas")
            {
                dgvReporte.DataSource = dao.ObtenerVentasRecientes();
            }
            else if (seleccion == "Distribución de Clientes")
            {
                dgvReporte.DataSource = dao.ObtenerDistribucionClientes();
            }

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ReadOnly = true;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            dgvReporte.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }
    }
}


