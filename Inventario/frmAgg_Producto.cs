using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FlowerShop.Inventario
{
    public partial class frmAgg_Producto : Form
    {
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        public frmAgg_Producto()
        {
            InitializeComponent();

            
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

            
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    string query = @"INSERT INTO PRODUCTO (Nombre, Precio_Compra, Precio_Venta, Cantidad, Categoria, Id_Proveedor) 
                             VALUES (@Nombre, @PrecioCompra, @PrecioVenta, @Cantidad, @Categoria, @IdProveedor)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@PrecioCompra", Convert.ToDecimal(txtPrecioCompra.Text));
                        cmd.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(txtPrecioVenta.Text));
                        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                        cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                        cmd.Parameters.AddWithValue("@IdProveedor", Convert.ToInt32(txtProveedor.Text));

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
