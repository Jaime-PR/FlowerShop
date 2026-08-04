using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop.Ventas
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            this.Load += frmVentas_Load;
            AplicarBordesRedondeados(pnlContenedorVentas, 15);
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                FlowerShop.Modelos.VentaDAO dao = new FlowerShop.Modelos.VentaDAO();
                dgvVentas.DataSource = dao.ObtenerHistorialVentas();
                FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvVentas);
                if (dgvVentas.Columns.Contains("ID Venta"))
                {
                    dgvVentas.Columns["ID Venta"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            frmRegistro_Venta frm = new frmRegistro_Venta();
            // Since frmVentas is probably a top level or inside a container, 
            // usually adding new forms like this might pop them up as Dialogs or we swap panels.
            // In frmAñadir_Producto it was shown as Dialog. Let's do ShowDialog.
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            
            // Reload sales after registering
            CargarVentas();
        }

        private void AplicarBordesRedondeados(Panel panel, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
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

            panel.Resize += (s, e) =>
            {
                if (panel.Width <= 0 || panel.Height <= 0) return;
                System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
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
    }
}

