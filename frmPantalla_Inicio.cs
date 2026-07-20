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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxUsuario_Click(object sender, EventArgs e)
        {
            
            frmMenu menu = new frmMenu();

            
            menu.StartPosition = FormStartPosition.Manual;

            // (Opcional) Quitarle los bordes al form para que parezca un menú desplegable real
             menu.FormBorderStyle = FormBorderStyle.None; 

            // 3. Calcular la posición exacta (esquina inferior derecha de la imagen)
            // PointToScreen convierte la ubicación del control a coordenadas de tu monitor
            Point esquinaInferiorDerecha = pictureBoxUsuario.PointToScreen(new Point(pictureBoxUsuario.Width, pictureBoxUsuario.Height));

            // 4. Ajustar la ubicación para que encaje en el recuadro azul
            // Restamos el ancho del menú a la coordenada X para que quede alineado a la derecha
            int posicionX = esquinaInferiorDerecha.X - menu.Width;
            int posicionY = esquinaInferiorDerecha.Y; // Y se queda igual para que aparezca justo debajo

            // 5. Asignar la nueva ubicación y mostrar el menú
            menu.Location = new Point(posicionX, posicionY);
            menu.Show();
        }
    }
}
