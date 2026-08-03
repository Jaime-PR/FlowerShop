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
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            
            AplicarBordesRedondeados(pnlKpi1, 15);
            AplicarBordesRedondeados(pnlKpi2, 15);
            AplicarBordesRedondeados(pnlKpi3, 15);
            AplicarBordesRedondeados(pnlKpi4, 15);
            AplicarBordesRedondeados(pnlContenedorPrincipal, 15);
            AplicarBordesRedondeados(pnlDatosP, 15);
        }
        // Variable para controlar que no se reduzca más allá del tamaño original
        private float nivelZoomActual = 1.0f;

        // Factor de aumento: 1.1f significa que crecerá un 10% por cada clic
        private const float factorZoom = 1.1f;

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarDatosInventario();
        }

        private void AplicarBordesRedondeados(Panel panel, int radio)
        {
            if (panel == null) return;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            int d = radio * 2;

            if (panel.Width > 0 && panel.Height > 0)
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                panel.Region = new Region(path);
            }

            panel.Resize += (s, ev) =>
            {
                if (panel.Width <= 0 || panel.Height <= 0) return;
                System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
                Rectangle r = new Rectangle(0, 0, panel.Width, panel.Height);
                int dd = radio * 2;
                p.AddArc(r.X, r.Y, dd, dd, 180, 90);
                p.AddArc(r.Right - dd, r.Y, dd, dd, 270, 90);
                p.AddArc(r.Right - dd, r.Bottom - dd, dd, dd, 0, 90);
                p.AddArc(r.X, r.Bottom - dd, dd, dd, 90, 90);
                p.CloseFigure();
                panel.Region = new Region(p);
            };
        }

        

        private void CargarDatosInventario()
        {
            try
            {
                ProductoDAO dao = new ProductoDAO();
                dgvProductos.DataSource = dao.ObtenerTodosLosProductos();
                FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvProductos);
                if (dgvProductos.Columns.Contains("Id_Producto"))
                    dgvProductos.Columns["Id_Producto"].Visible = false;
                if (dgvProductos.Columns.Contains("Id_Proveedor"))
                    dgvProductos.Columns["Id_Proveedor"].Visible = false;

                if (!dgvProductos.Columns.Contains("btnEditar"))
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.Name = "btnEditar";
                    btnEditar.HeaderText = "Editar";
                    btnEditar.Text = "Editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    btnEditar.FlatStyle = FlatStyle.Flat;
                    dgvProductos.Columns.Add(btnEditar);
                }

                if (!dgvProductos.Columns.Contains("btnEliminar"))
                {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "btnEliminar";
                    btnEliminar.HeaderText = "Eliminar";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    btnEliminar.FlatStyle = FlatStyle.Flat;
                    dgvProductos.Columns.Add(btnEliminar);
                }

                // Cargar KPIs
                lblKpi1Valor.Text = dao.ObtenerTotalProductosEnInventario().ToString();
                lblKpi2Valor.Text = dao.ObtenerProductosBajoStock(10).ToString();
                
                lblKpi3Titulo.Text = "Sin Stock";
                lblKpi3Valor.Text = dao.ObtenerProductosSinStock().ToString();
                
                lblKpi4Valor.Text = dao.ObtenerValorTotalInventario().ToString("C2");
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

                if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    pnlDatosP.Width = 500;
                    pnlDatosP.Controls.Clear();
                    frmAñadir_Producto frmEditar = new frmAñadir_Producto(idProductoSeleccionado);
                    frmEditar.TopLevel = false;
                    frmEditar.Dock = DockStyle.Fill;
                    pnlDatosP.Controls.Add(frmEditar);
                    pnlDatosP.Visible = true;
                    pnlDatosP.BringToFront();
                    frmEditar.OperacionCompletada += Frm_OperacionCompletada;
                    frmEditar.Show();
                }
                else if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
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
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("Â¿EstÃ¡s seguro de que deseas actualizar la informaciÃ³n de este producto?", "Confirmar actualizaciÃ³n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {

                    Producto prod = new Producto();
                    prod.Id_Producto = idProductoSeleccionado; // Le damos el ID que tenÃ­amos guardado
                    prod.Nombre = txtNombre.Text;
                    prod.Categoria = txtCategoria.Text;
                    prod.Id_Proveedor = Convert.ToInt32(txtProveedor.Text);
                    prod.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    prod.Precio_Compra = Convert.ToDecimal(txtPrecioCompra.Text);
                    prod.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text);


                    ProductoDAO dao = new ProductoDAO();
                    if (dao.ActualizarProducto(prod))
                    {
                        MessageBox.Show("Producto actualizado exitosamente.", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            DialogResult confirmacion = MessageBox.Show("Â¿EstÃ¡s seguro de eliminar este producto por completo? Esta acciÃ³n no se puede deshacer.", "Advertencia CrÃ­tica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    ProductoDAO dao = new ProductoDAO();

                    if (dao.EliminarProducto(idProductoSeleccionado))
                    {
                        MessageBox.Show("Producto eliminado correctamente.", "Ã‰xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        
        private void Frm_OperacionCompletada(object sender, EventArgs e)
        {
            pnlDatosP.Controls.Clear();
            pnlDatosP.Visible = false;
            CargarDatosInventario();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            pnlDatosP.Width = 500;
            pnlDatosP.Controls.Clear();
            frmAñadir_Producto frm = new frmAñadir_Producto();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlDatosP.Controls.Add(frm);
            pnlDatosP.Visible = true;
            pnlDatosP.BringToFront();
            frm.OperacionCompletada += Frm_OperacionCompletada;
            frm.Show();
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

        private void btnAcercar_Click(object sender, EventArgs e)
        {
            // Limitar el zoom máximo (opcional, aquí lo limitamos a 2 veces su tamaño)
            if (nivelZoomActual < 2.0f)
            {
                // Scale(SizeF) redimensiona el ancho y el alto
                this.Scale(new SizeF(factorZoom, factorZoom));

                // Actualizamos nuestro registro
                nivelZoomActual *= factorZoom;
            }
        }

        private void btnAlejar_Click(object sender, EventArgs e)
        {
            // Evitamos que el usuario haga la ventana más pequeña que el diseño original
            if (nivelZoomActual > 1.05f)
            {
                // Calculamos la reducción (la inversa del factor de zoom)
                float reduccion = 1.0f / factorZoom;

                this.Scale(new SizeF(reduccion, reduccion));

                // Actualizamos nuestro registro
                nivelZoomActual *= reduccion;
            }
            else if (nivelZoomActual > 1.0f)
            {
                // Si está muy cerca del original, lo forzamos a regresar exactamente a 1.0
                float ajusteFinal = 1.0f / nivelZoomActual;
                this.Scale(new SizeF(ajusteFinal, ajusteFinal));
                nivelZoomActual = 1.0f;
            }
        }
    }
}



