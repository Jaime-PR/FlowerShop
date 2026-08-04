using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Modelos;

namespace FlowerShop
{
    public partial class frmPrincipal : System.Windows.Forms.Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            FlowerShop.Utilidades.UIHelper.ConfigurarAccesibilidad(this);
            this.Load += FrmPrincipal_Load;

            // Aplicar bordes redondeados a los paneles del dashboard
            AplicarBordesRedondeados(panel1, 15);
            AplicarBordesRedondeados(panel2, 15);
            AplicarBordesRedondeados(panel3, 15);
            AplicarBordesRedondeados(panel4, 15);
            AplicarBordesRedondeados(pnlUsuarios, 15);
            AplicarBordesRedondeados(pnlUltimasVentas, 15);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarDashboard();
            this.Resize += FrmPrincipal_Resize;
            CentrarKPIs();
        }

        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            CentrarKPIs();
        }

        private void CentrarKPIs()
        {
            int totalPanelsWidth = panel1.Width + panel2.Width + panel3.Width + panel4.Width;
            int availableWidth = flowLayoutPanelKPIs.Width;

            if (availableWidth > totalPanelsWidth)
            {
                int leftoverSpace = availableWidth - totalPanelsWidth;
                int gap = leftoverSpace / 5; // Distribuir el espacio en 5 huecos (orillas + entre paneles)

                panel1.Margin = new Padding(gap, 5, 0, 5);
                panel2.Margin = new Padding(gap, 5, 0, 5);
                panel3.Margin = new Padding(gap, 5, 0, 5);
                panel4.Margin = new Padding(gap, 5, 0, 5);
                
                flowLayoutPanelKPIs.Padding = new Padding(0, flowLayoutPanelKPIs.Padding.Top, 0, flowLayoutPanelKPIs.Padding.Bottom);
            }
            else
            {
                // Fallback si la ventana se hace muy pequeña
                panel1.Margin = new Padding(10, 5, 25, 5);
                panel2.Margin = new Padding(10, 5, 25, 5);
                panel3.Margin = new Padding(10, 5, 25, 5);
                panel4.Margin = new Padding(10, 5, 10, 5);
                flowLayoutPanelKPIs.Padding = new Padding(35, flowLayoutPanelKPIs.Padding.Top, 35, flowLayoutPanelKPIs.Padding.Bottom);
            }
        }

        private void CargarDashboard()
        {
            try
            {
                DashboardDAO dao = new DashboardDAO();

                // Ingresos Totales -> lblTotalIngresos
                decimal ingresos = dao.ObtenerIngresosTotales();
                lblTotalIngresos.Text = ingresos.ToString("C2"); // Format as currency

                // Ventas Totales -> lblTotalVentas
                int ventas = dao.ObtenerVentasTotales();
                lblTotalVentas.Text = ventas.ToString();

                // Productos Bajo Inventario (usando ProductoDAO)
                FlowerShop.Datos.ProductoDAO prodDao = new FlowerShop.Datos.ProductoDAO();
                int bajoStock = prodDao.ObtenerProductosBajoStock(10);
                lblProximamente.Text = bajoStock.ToString(); 

                // Clientes Totales -> lblTotalClientes
                int clientes = dao.ObtenerClientesTotales();
                lblTotalClientes.Text = clientes.ToString();

                // Usuarios Vendedores (izquierda)
                DataTable dtUsuarios = dao.ObtenerUsuariosVendedores();
                dataGridViewUsuarios.DataSource = dtUsuarios;
                FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dataGridViewUsuarios);
                dataGridViewUsuarios.AllowUserToAddRows = false;
                dataGridViewUsuarios.AllowUserToDeleteRows = false;
                dataGridViewUsuarios.ReadOnly = true;

                // Últimas Ventas (derecha)
                DataTable dtVentas = dao.ObtenerUltimasVentas();
                dataGridViewVentas.DataSource = dtVentas;
                FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dataGridViewVentas);
                dataGridViewVentas.AllowUserToAddRows = false;
                dataGridViewVentas.AllowUserToDeleteRows = false;
                dataGridViewVentas.ReadOnly = true;

                // Mostrar la fecha actual en el label7
                label7.Text = DateTime.Now.ToString("D");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarBordesRedondeados(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            int d = radio * 2;

            if (panel.Width > 0 && panel.Height > 0)
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                panel.Region = new Region(path);
            }

            // Re-aplicar cuando el panel cambie de tamaño
            panel.Resize += (s, e) =>
            {
                if (panel.Width <= 0 || panel.Height <= 0) return;
                GraphicsPath p = new GraphicsPath();
                Rectangle r = new Rectangle(0, 0, panel.Width, panel.Height);
                int dd = radio * 2;
                p.AddArc(r.X, r.Y, dd, dd, 180, 90);
                p.AddArc(r.Right - dd, r.Y, dd, dd, 270, 90);
                p.AddArc(r.Right - dd, r.Bottom - dd, dd, dd, 0, 90);
                p.AddArc(r.X, r.Bottom - dd, dd, dd, 90, 90);
                p.CloseFigure();
                panel.Region = new Region(p);
            };
        }

        private void dataGridViewVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


