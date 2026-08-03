using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlowerShop.Datos;
using FlowerShop.Modelos;
using FlowerShop.Utilidades;

namespace FlowerShop.Inventario
{
    public partial class frmAñadir_Producto : Form
    {
        public event EventHandler OperacionCompletada;
        private ProductoDAO dao = new ProductoDAO();
        private Dictionary<int, string> proveedores;
        private int _idProductoEdicion = 0;

        public frmAñadir_Producto()
        {
            InitializeComponent();
        }

        public frmAñadir_Producto(int idProducto)
        {
            InitializeComponent();
            _idProductoEdicion = idProducto;
        }

        private void frmAñadir_Producto_Load(object sender, EventArgs e)
        {
            UIHelper.AplicarBordesRedondeados(btnGuardar, 15);
            UIHelper.AplicarBordesRedondeados(btnCancelar, 15);
            UIHelper.AplicarBordesRedondeados(btnAñadir, 15);

            CargarProveedores();
            CargarCategorias();
            HookValidations();

            cmbProducto.Enabled = false;
            txtCantidadInsumo.Enabled = false;
            btnAñadir.Enabled = false;
            
            if (dgvReceta.Columns.Count == 0)
            {
                dgvReceta.Columns.Add("Producto", "Producto");
                dgvReceta.Columns.Add("Cantidad", "Cantidad");
            }

            if (_idProductoEdicion > 0)
            {
                lblTitulo.Text = "Actualizar producto";
                btnGuardar.Text = "Actualizar producto";
                CargarDatosEdicion();
            }
        }

        private void CargarDatosEdicion()
        {
            try
            {
                Producto prod = dao.ObtenerProductoPorId(_idProductoEdicion);
                if (prod != null)
                {
                    txtNombreProducto.Text = prod.Nombre;
                    txtPrecioCompra.Text = prod.Precio_Compra.ToString();
                    txtCantidad.Text = prod.Cantidad.ToString();
                    txtPrecioVenta.Text = prod.Precio_Venta.ToString();
                    
                    if (cmbCategoria.Items.Contains(prod.Categoria))
                        cmbCategoria.SelectedItem = prod.Categoria;

                    if (proveedores != null && proveedores.ContainsKey(prod.Id_Proveedor))
                    {
                        cmbProveedor.SelectedItem = proveedores[prod.Id_Proveedor];
                    }

                    // Cargar receta
                    string receta = dao.ObtenerReceta(_idProductoEdicion);
                    if (!string.IsNullOrEmpty(receta))
                    {
                        var items = receta.Split(',');
                        foreach (var item in items)
                        {
                            var partes = item.Split(new string[] { " x " }, StringSplitOptions.None);
                            if (partes.Length == 2)
                            {
                                dgvReceta.Rows.Add(partes[0].Trim(), partes[1].Trim());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            proveedores = dao.ObtenerProveedoresParaCombo();
            cmbProveedor.Items.Clear();
            if (proveedores != null)
            {
                foreach (var prov in proveedores.Values)
                {
                    cmbProveedor.Items.Add(prov);
                }
            }
        }

        private void CargarCategorias()
        {
            var categorias = dao.ObtenerCategorias();
            cmbCategoria.Items.Clear();
            if (categorias != null)
            {
                foreach (var cat in categorias)
                {
                    cmbCategoria.Items.Add(cat);
                }
            }
        }

                private bool ValidarNombre()
        {
            string texto = txtNombreProducto.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto) || texto.Length < 3 || texto.Length > 100 || !System.Text.RegularExpressions.Regex.IsMatch(texto, "^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\\s]+$"))
            {
                ValidationUtils.MostrarError(txtNombreProducto, "Nombre inválido (3-100 caracteres, letras y números).");
                return false;
            }
            ValidationUtils.LimpiarError(txtNombreProducto);
            return true;
        }

        private bool ValidarCantidad()
        {
            if (!int.TryParse(txtCantidad.Text, out int cant) || cant < 1 || cant > 100000)
            {
                ValidationUtils.MostrarError(txtCantidad, "Debe ser un número entre 1 y 100,000.");
                return false;
            }
            ValidationUtils.LimpiarError(txtCantidad);
            return true;
        }

        private bool ValidarPrecios()
        {
            bool compraOk = decimal.TryParse(txtPrecioCompra.Text, out decimal compra) && compra > 0;
            bool ventaOk = decimal.TryParse(txtPrecioVenta.Text, out decimal venta) && venta > 0;
            
            if (!compraOk) ValidationUtils.MostrarError(txtPrecioCompra, "Precio de compra inválido (> 0).");
            else ValidationUtils.LimpiarError(txtPrecioCompra);

            if (!ventaOk) ValidationUtils.MostrarError(txtPrecioVenta, "Precio de venta inválido (> 0).");
            else if (compraOk && venta < compra)
            {
                ValidationUtils.MostrarError(txtPrecioVenta, "El precio de venta debe ser mayor o igual al de compra.");
                ventaOk = false;
            }
            else ValidationUtils.LimpiarError(txtPrecioVenta);

            if (compraOk && ventaOk && compra == venta)
            {
                // Warning only
                ValidationUtils.MostrarError(txtPrecioVenta, "Advertencia: Precio venta igual a precio compra.");
            }
            return compraOk && (venta >= compra);
        }

        private void HookValidations()
        {
            txtNombreProducto.Validating += (s, e) => ValidarNombre();
            txtCantidad.Validating += (s, e) => ValidarCantidad();
            txtPrecioCompra.Validating += (s, e) => ValidarPrecios();
            txtPrecioVenta.Validating += (s, e) => ValidarPrecios();

            txtCantidad.KeyPress += Numeros_KeyPress;
            txtCantidadInsumo.KeyPress += Numeros_KeyPress;
            txtPrecioCompra.KeyPress += Decimales_KeyPress;
            txtPrecioVenta.KeyPress += Decimales_KeyPress;
        }

        private void Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void Decimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarNombre() || !ValidarCantidad() || !ValidarPrecios() || cmbProveedor.SelectedItem == null || cmbCategoria.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = txtNombreProducto.Text.Trim();
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                string categoria = cmbCategoria.SelectedItem.ToString();
                
                string proveedorNombre = cmbProveedor.SelectedItem.ToString();
                int idProveedor = -1;
                foreach (var kvp in proveedores)
                {
                    if (kvp.Value == proveedorNombre)
                    {
                        idProveedor = kvp.Key;
                        break;
                    }
                }

                if (idProveedor == -1)
                {
                    MessageBox.Show("Proveedor no vÃ¡lido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder recetaBuilder = new StringBuilder();
                foreach (DataGridViewRow row in dgvReceta.Rows)
                {
                    if (row.Cells["Producto"].Value != null && row.Cells["Cantidad"].Value != null)
                    {
                        string prod = row.Cells["Producto"].Value.ToString();
                        string cant = row.Cells["Cantidad"].Value.ToString();
                        if (recetaBuilder.Length > 0) recetaBuilder.Append(", ");
                        recetaBuilder.Append($"{prod} x {cant}");
                    }
                }

                if (_idProductoEdicion > 0)
                {
                    dao.ActualizarProductoConReceta(_idProductoEdicion, nombre, precioCompra, cantidad, precioVenta, categoria, idProveedor, recetaBuilder.ToString());
                    MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.InsertarProductoConReceta(nombre, precioCompra, cantidad, precioVenta, categoria, idProveedor, recetaBuilder.ToString());
                    MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                OperacionCompletada?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem != null)
            {
                string sel = cmbCategoria.SelectedItem.ToString();
                if (sel == "Ramos" || sel == "Arreglos")
                {
                    cmbProducto.Enabled = true;
                    txtCantidadInsumo.Enabled = true;
                    btnAñadir.Enabled = true;

                    DataTable dtInsumos = dao.ObtenerProductosInsumo();
                    cmbProducto.Items.Clear();
                    if (dtInsumos != null)
                    {
                        foreach (DataRow row in dtInsumos.Rows)
                        {
                            cmbProducto.Items.Add(row["Nombre"].ToString());
                        }
                    }
                }
                else
                {
                    cmbProducto.Enabled = false;
                    txtCantidadInsumo.Enabled = false;
                    btnAñadir.Enabled = false;
                    dgvReceta.Rows.Clear();
                }
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null && !string.IsNullOrWhiteSpace(txtCantidadInsumo.Text))
            {
                dgvReceta.Rows.Add(cmbProducto.SelectedItem.ToString(), txtCantidadInsumo.Text);
                txtCantidadInsumo.Clear();
            }
        }
    }
}




