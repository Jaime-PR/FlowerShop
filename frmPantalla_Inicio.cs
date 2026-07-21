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
        // 1. Variable global privada para guardar el rol
        private string rolDelUsuarioLogueado;

        // 2. Único constructor unificado que recibe el rol
        public frmPantalla_Inicio(string rolUsuario)
        {
            InitializeComponent();

            // Guardamos el rol que viene del Login en nuestra variable
            rolDelUsuarioLogueado = rolUsuario;

            // Restricción de módulos en el panel lateral izquierdo
            if (rolDelUsuarioLogueado == "Vendedor")
            {
                // Ejemplo para ocultar botones del menú lateral verde
                // btnProveedor.Visible = false;
                // bntCategotia.Visible = false;
            }
            else if (rolDelUsuarioLogueado == "Administrador")
            {
                // El administrador ve todo el menú intacto
            }
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        // 3. Evento del ícono de usuario arreglado con el paso del Rol
        private void pictureBoxUsuario_Click(object sender, EventArgs e)
        {
            // Instanciamos frmMenu y le PASAMOS EL ROL guardado
            frmMenu menu = new frmMenu(rolDelUsuarioLogueado);

            menu.StartPosition = FormStartPosition.Manual;
            menu.FormBorderStyle = FormBorderStyle.None;

            // Calcular la posición exacta
            Point esquinaInferiorDerecha = pictureBoxUsuario.PointToScreen(new Point(pictureBoxUsuario.Width, pictureBoxUsuario.Height));

            // Ajustar la ubicación para que encaje
            int posicionX = esquinaInferiorDerecha.X - menu.Width;
            int posicionY = esquinaInferiorDerecha.Y;

            // Asignar la nueva ubicación y mostrar el menú
            menu.Location = new Point(posicionX, posicionY);
            menu.Show();
        }
    }
}