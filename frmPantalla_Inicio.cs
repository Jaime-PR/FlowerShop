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

        // Constructor sin parámetros requerido por el Diseñador de Visual Studio
        public frmPantalla_Inicio()
        {
            InitializeComponent();
            RedimensionarIconos();
            this.Load += FrmPantalla_Inicio_Load;
        }

        // 2. Único constructor unificado que recibe el rol
        public frmPantalla_Inicio(string rolUsuario)
        {
            InitializeComponent();
            RedimensionarIconos();
            this.Load += FrmPantalla_Inicio_Load;

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

        private void FrmPantalla_Inicio_Load(object sender, EventArgs e)
        {
            AbrirFormulario<frmPrincipal>();
        }

        private void RedimensionarIconos()
        {
            Button[] botones = { btnInicio, bntProductos, btnVentas, btnPedidos, btnClientes, btnUsuarios, btnInventario, btnProveedor, btnCerrarSesion };
            int nuevoTamano = 24;

            foreach (Button btn in botones)
            {
                if (btn.Image != null)
                {
                    Bitmap original = new Bitmap(btn.Image);
                    Bitmap resized = new Bitmap(nuevoTamano, nuevoTamano);
                    using (Graphics g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, nuevoTamano, nuevoTamano);
                    }
                    btn.Image = resized;
                }
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuarios.frmUsuarios>();
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
            AbrirFormulario<frmPrincipal>();
        }

        // Manejador para Cerrar Sesión (agregado para el botón inferior)
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // O lógica de cerrar sesión específica
        }
    }
}