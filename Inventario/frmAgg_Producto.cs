using System;
using System.Windows.Forms;
using FlowerShop.Modelos; 
using FlowerShop.Datos;   

namespace FlowerShop.Inventario
{
    public partial class frmAgg_Producto : Form
    {
        

        public frmAgg_Producto()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            this.btnCancelar.Click += btnCancelar_Click;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtProveedor.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                MessageBox.Show("No se puede añadir el producto. Por favor, asegúrate de llenar todos los campos del formulario.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas agregar este nuevo producto al inventario?", "Confirmar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.OK)
            {
                return;
            }

            
            try
            {
                
                Producto nuevoProducto = new Producto();
                nuevoProducto.Nombre = txtNombre.Text;
                nuevoProducto.Categoria = txtCategoria.Text;

                
                nuevoProducto.Precio_Compra = Convert.ToDecimal(txtPrecioCompra.Text);
                nuevoProducto.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text);
                nuevoProducto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                nuevoProducto.Id_Proveedor = Convert.ToInt32(txtProveedor.Text);

                
                ProductoDAO dao = new ProductoDAO();
                bool seGuardo = dao.AgregarProducto(nuevoProducto);

                if (seGuardo)
                {
                    MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifica que los precios, la cantidad y el ID del proveedor sean números válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgg_Producto_Load(object sender, EventArgs e)
        {

        }
    }
}