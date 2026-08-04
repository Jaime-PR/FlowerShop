using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlowerShop.Modelos;

namespace FlowerShop.Ventas
{
    public partial class frmRegistro_Venta : Form
    {
        private VentaDAO ventaDAO = new VentaDAO();
        private DataTable dtProductos;
        private DataTable dtCarrito;
        private decimal totalVenta = 0;

        public frmRegistro_Venta()
        {
            InitializeComponent();
            InicializarCarrito();
            AplicarEstilosRedondeados();
        }

        private void frmRegistro_Venta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            
            if (cmbOrigen.Items.Count > 0)
                cmbOrigen.SelectedIndex = 0;
        }

        private void AplicarEstilosRedondeados()
        {
            // Simple helper for rounded panels/buttons
            Utilidades.UIHelper.AplicarBordesRedondeados(pnlTop, 15);
            Utilidades.UIHelper.AplicarBordesRedondeados(pnlMiddle, 15);
            Utilidades.UIHelper.AplicarBordesRedondeados(pnlBottom, 15);
            Utilidades.UIHelper.AplicarBordesRedondeados(btnAgregar, 10);
            Utilidades.UIHelper.AplicarBordesRedondeados(btnFinalizarVenta, 10);
        }

        private void InicializarCarrito()
        {
            dtCarrito = new DataTable();
            dtCarrito.Columns.Add("IdProducto", typeof(int));
            dtCarrito.Columns.Add("Producto", typeof(string));
            dtCarrito.Columns.Add("PrecioUnitario", typeof(decimal));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal));
        }

        private void CargarClientes()
        {
            DataTable dtClientes = ventaDAO.ObtenerClientesParaCombo();
            cmbCliente.DataSource = dtClientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Id_Cliente";
            cmbCliente.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dtProductos = ventaDAO.ObtenerProductosParaCombo();
            cmbProducto.DataSource = dtProductos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id_Producto";
            cmbProducto.SelectedIndex = -1;
            
            lblPrecio.Text = "$0.00";
            lblStock.Text = "0";
            numCantidad.Value = 1;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex >= 0 && dtProductos != null)
            {
                DataRowView drv = (DataRowView)cmbProducto.SelectedItem;
                decimal precio = Convert.ToDecimal(drv["Precio_Venta"]);
                int stock = Convert.ToInt32(drv["Cantidad"]);

                lblPrecio.Text = precio.ToString("C2");
                lblStock.Text = stock.ToString();
                
                numCantidad.Maximum = stock > 0 ? stock : 1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = (DataRowView)cmbProducto.SelectedItem;
            int idProducto = Convert.ToInt32(drv["Id_Producto"]);
            string nombreProducto = drv["Nombre"].ToString();
            decimal precio = Convert.ToDecimal(drv["Precio_Venta"]);
            int stockDisponible = Convert.ToInt32(drv["Cantidad"]);
            int cantidadSolicitada = (int)numCantidad.Value;

            // Verificar si ya existe en el carrito
            int cantidadEnCarrito = 0;
            foreach (DataRow row in dtCarrito.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    cantidadEnCarrito += Convert.ToInt32(row["Cantidad"]);
                }
            }

            if (cantidadSolicitada + cantidadEnCarrito > stockDisponible)
            {
                MessageBox.Show($"No hay suficiente stock. Tienes {cantidadEnCarrito} en el carrito y el stock total es {stockDisponible}.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agregar o actualizar fila en carrito
            bool encontrado = false;
            foreach (DataRow row in dtCarrito.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    row["Cantidad"] = Convert.ToInt32(row["Cantidad"]) + cantidadSolicitada;
                    row["Subtotal"] = Convert.ToDecimal(row["Cantidad"]) * precio;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                dtCarrito.Rows.Add(idProducto, nombreProducto, precio, cantidadSolicitada, precio * cantidadSolicitada);
            }

            ActualizarGridTotal();
            numCantidad.Value = 1;
        }

        private void ActualizarGridTotal()
        {
            dgvCarrito.Rows.Clear();
            totalVenta = 0;

            foreach (DataRow row in dtCarrito.Rows)
            {
                decimal subtotal = Convert.ToDecimal(row["Subtotal"]);
                totalVenta += subtotal;

                dgvCarrito.Rows.Add(
                    row["IdProducto"],
                    row["Producto"],
                    Convert.ToDecimal(row["PrecioUnitario"]).ToString("C2"),
                    row["Cantidad"],
                    subtotal.ToString("C2")
                );
            }

            lblTotal.Text = totalVenta.ToString("C2");
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Columna de Eliminar es el index 5
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                int idProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["colIdProducto"].Value);

                for (int i = 0; i < dtCarrito.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtCarrito.Rows[i]["IdProducto"]) == idProducto)
                    {
                        dtCarrito.Rows.RemoveAt(i);
                        break;
                    }
                }
                
                ActualizarGridTotal();
            }
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                string origenPedido = cmbOrigen.SelectedItem.ToString();
                int idUsuarioTemp = 1; // ID temporal autorizado por el usuario

                bool exito = ventaDAO.RegistrarVenta(idCliente, origenPedido, idUsuarioTemp, totalVenta, dtCarrito);

                if (exito)
                {
                    MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    this.Close(); // Close the form after successful sale
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            cmbCliente.SelectedIndex = -1;
            cmbOrigen.SelectedIndex = 0;
            cmbProducto.SelectedIndex = -1;
            numCantidad.Value = 1;
            dtCarrito.Clear();
            ActualizarGridTotal();
        }
    }
}

