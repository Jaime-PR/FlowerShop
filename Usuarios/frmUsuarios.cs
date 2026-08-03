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

namespace FlowerShop.Usuarios
{
    public partial class frmUsuarios : Form
    {
        private UsuarioDAO dao = new UsuarioDAO();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Aplicar bordes redondeados a los paneles y botón
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI1, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI2, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI3, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlContenedorGrid, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnNuevoUsuario, 20);

            // Cargar datos
            CargarDatos();
        }

        private void CargarDatos()
        {
            // KPIs
            lblUsuariosTotal.Text = dao.ObtenerTotalUsuarios().ToString();
            lblActivos.Text = dao.ObtenerUsuariosActivos().ToString();
            lblInactivos.Text = dao.ObtenerUsuariosInactivos().ToString();

            // Grid
            DataTable dtUsuarios = dao.ObtenerTodosLosUsuarios();
            dgvUsuarios.DataSource = dtUsuarios;
            FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvUsuarios);
            
            // Si la tabla no tiene estilo visual de encabezado
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(74, 85, 115);
            dgvUsuarios.EnableHeadersVisualStyles = false;
        }

        private void frmUsuarios_Resize(object sender, EventArgs e)
        {
            // Reaplicar bordes si se cambia de tamaño
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI1, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI2, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlKPI3, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlContenedorGrid, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnNuevoUsuario, 20);
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            frmAñadir_Usuario frm = new frmAñadir_Usuario();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            
            pnlSidebarDerecho.Controls.Clear();
            pnlSidebarDerecho.Controls.Add(frm);
            
            frm.OperacionCompletada += Frm_OperacionCompletada;

            frm.Show();
            pnlSidebarDerecho.Visible = true;
        }

        private void Frm_OperacionCompletada(object sender, EventArgs e)
        {
            pnlSidebarDerecho.Visible = false;
            pnlSidebarDerecho.Controls.Clear();
            CargarDatos();
        }
    }
}
