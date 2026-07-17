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
    public partial class frmInventario : Form
    {
        private int idProductoSeleccionado = 0;
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";

        public frmInventario()
        {
            InitializeComponent();
        }

        
        private void frmInventario_Load(object sender, EventArgs e)
        {         
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            CargarProductos();
        }

        private void CargarProductos()
        {
            string consulta = @"SELECT p.Id_Producto AS 'ID', 
                                       p.Nombre AS 'Producto', 
                                       p.Precio_Compra AS 'P. Compra', 
                                       p.Precio_Venta AS 'P. Venta', 
                                       p.Cantidad AS 'Stock', 
                                       p.Categoria AS 'Categoría', 
                                       pr.Nombre_Empresa AS 'Proveedor' 
                                FROM PRODUCTO p
                                INNER JOIN PROVEEDOR pr ON p.Id_Proveedor = pr.Id_Proveedor";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && !dgvProductos.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                
                if (fila.Cells["ID"].Value != null && fila.Cells["ID"].Value != DBNull.Value)
                {
                    idProductoSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);

                    
                    txtNombre.Text = fila.Cells["Producto"].Value?.ToString() ?? "";
                    txtCategoria.Text = fila.Cells["Categoría"].Value?.ToString() ?? "";
                    txtProveedor.Text = fila.Cells["Proveedor"].Value?.ToString() ?? "";
                    txtCantidad.Text = fila.Cells["Stock"].Value?.ToString() ?? "";
                    txtPrecioCompra.Text = fila.Cells["P. Compra"].Value?.ToString() ?? "";
                    txtPrecioVenta.Text = fila.Cells["P. Venta"].Value?.ToString() ?? "";
                }
            }
        }
        private void AbrirFormulario<TForm>() where TForm : Form, new()
        {
            using (TForm formulario = new TForm())
            {
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
            }
        }

        //Limpiar datos
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtProveedor.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            idProductoSeleccionado = 0; 
        }
       
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtProveedor.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                MessageBox.Show("No se puede actualizar el producto si hay registros en blanco. Por favor, llena todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult confirmacion = MessageBox.Show("¿Desea realizar estos cambios en el producto?", "Confirmar actualización", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            
            if (confirmacion != DialogResult.OK)
            {
                return;
            }

            
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"UPDATE PRODUCTO 
                             SET Nombre = @Nombre, 
                                 Precio_Compra = @PrecioCompra, 
                                 Precio_Venta = @PrecioVenta, 
                                 Cantidad = @Cantidad, 
                                 Categoria = @Categoria 
                             WHERE Id_Producto = @IdProducto";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@PrecioCompra", Convert.ToDecimal(txtPrecioCompra.Text));
                        cmd.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(txtPrecioVenta.Text));
                        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                        cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                        cmd.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarProductos();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult confirmacion = MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Confirmar Eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            
            if (confirmacion == DialogResult.OK)
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        string query = "DELETE FROM PRODUCTO WHERE Id_Producto = @IdProducto";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el producto a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void bntAñadir_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmAgg_Producto>();

            CargarProductos();
        }
        private void button4_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmAgg_Producto>();

            CargarProductos();
        }
        private void panel1_Paint_1(object sender, PaintEventArgs e) { }
    }

}
