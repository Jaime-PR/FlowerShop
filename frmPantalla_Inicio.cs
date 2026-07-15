using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Inventario;

namespace FlowerShop
{
    public partial class frmPantalla_Inicio : Form
    {
        public frmPantalla_Inicio()
        {
            InitializeComponent();
        }
         
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            
            Form formulario = pnlContenedor.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                
                formulario = new MiForm();
                formulario.TopLevel = false; 
                formulario.FormBorderStyle = FormBorderStyle.None;  
                formulario.Dock = DockStyle.Fill; 

                pnlContenedor.Controls.Add(formulario);
                pnlContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
            
                formulario.BringToFront();
            }
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmInventario>();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Ventas.frmVentas>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Clientes.frmClientes>();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proveedor.frmProveedores>();
        }

        private void bntCategotia_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmCategorias>();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
