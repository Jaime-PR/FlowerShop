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
            AplicarBordesRedondeados(panel5, 15);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarDashboard();
        }


        private void CargarDashboard()
        {
            try
            {
                DashboardDAO dao = new DashboardDAO();

                // Ingresos Totales
                decimal ingresos = dao.ObtenerIngresosTotales();
                lblTotalIngresos.Text = ingresos.ToString("C2"); // Format as currency

                // Ventas Totales
                int ventas = dao.ObtenerVentasTotales();
                lblTotalVentas.Text = ventas.ToString();

                // Clientes Totales
                int clientes = dao.ObtenerClientesTotales();
                lblTotalClientes.Text = clientes.ToString();

                // Usuarios Activos (Vendedores)
                DataTable dtUsuarios = dao.ObtenerUsuariosVendedores();
                dataGridViewUsuarios.DataSource = dtUsuarios;

                // Aplicar diseño y restricciones a la tabla
                FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dataGridViewUsuarios);
                dataGridViewUsuarios.AllowUserToAddRows = false;
                dataGridViewUsuarios.AllowUserToDeleteRows = false;
                dataGridViewUsuarios.AllowUserToResizeColumns = false;
                dataGridViewUsuarios.AllowUserToResizeRows = false;
                dataGridViewUsuarios.ReadOnly = true;
                dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Mostrar la fecha actual en el label7
                label7.Text = DateTime.Now.ToString("D");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminados eventos de Paint no utilizados

        private void AplicarBordesRedondeados(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            int d = radio * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);

            // Re-aplicar cuando el panel cambie de tamaño
            panel.Resize += (s, e) =>
            {
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

