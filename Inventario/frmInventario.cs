using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShop.Datos;
using FlowerShop.Modelos;
using MySql.Data.MySqlClient;

namespace FlowerShop.Inventario
{
    public partial class frmInventario : Form
    {
        
        private int idProductoSeleccionado = 0;

        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarDatosInventario();
        }

        
        private void CargarDatosInventario()
        {
            try
            {
                ProductoDAO dao = new ProductoDAO();
                dgvProductos.DataSource = dao.ObtenerTodosLosProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                
                idProductoSeleccionado = Convert.ToInt32(fila.Cells["Id_Producto"].Value);

               
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                txtProveedor.Text = fila.Cells["Id_Proveedor"].Value.ToString();
                txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();
                txtPrecioCompra.Text = fila.Cells["Precio_Compra"].Value.ToString();
                txtPrecioVenta.Text = fila.Cells["Precio_Venta"].Value.ToString();
            }
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas actualizar la información de este producto?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    
                    Producto prod = new Producto();
                    prod.Id_Producto = idProductoSeleccionado; // Le damos el ID que teníamos guardado
                    prod.Nombre = txtNombre.Text;
                    prod.Categoria = txtCategoria.Text;
                    prod.Id_Proveedor = Convert.ToInt32(txtProveedor.Text);
                    prod.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    prod.Precio_Compra = Convert.ToDecimal(txtPrecioCompra.Text);
                    prod.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text);

                    
                    ProductoDAO dao = new ProductoDAO();
                    if (dao.ActualizarProducto(prod))
                    {
                        MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosInventario(); 
                        LimpiarCajas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar este producto por completo? Esta acción no se puede deshacer.", "Advertencia Crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    ProductoDAO dao = new ProductoDAO();
                    
                    if (dao.EliminarProducto(idProductoSeleccionado))
                    {
                        MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosInventario();
                        LimpiarCajas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            frmAgg_Producto ventanaAgregar = new frmAgg_Producto();

            
            if (ventanaAgregar.ShowDialog() == DialogResult.OK)
            {
                
                CargarDatosInventario();
            }
        }

        
        private void LimpiarCajas()
        {
            idProductoSeleccionado = 0;
            txtNombre.Clear();
            txtCategoria.Clear();
            txtProveedor.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
        }
    }

}
