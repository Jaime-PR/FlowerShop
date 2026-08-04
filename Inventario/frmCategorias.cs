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
using FlowerShop.Modelos;
using FlowerShop.Datos;

namespace FlowerShop.Inventario
{
    public partial class frmCategorias : Form
    {
        private ProductoDAO productoDAO = new ProductoDAO();
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";

        public frmCategorias()
        {
            InitializeComponent();
            FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvProductos);
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            List<string> categorias = productoDAO.ObtenerCategorias();
            categorias.Insert(0, "Todas");
            cmbCategorias.DataSource = categorias;
        }

        private void CargarProductos()
        {
            string categoriaSeleccionada = cmbCategorias.SelectedItem != null ? cmbCategorias.SelectedItem.ToString() : "Todas";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT Id_Producto AS 'ID', Nombre AS 'Nombre', Precio_Compra AS 'Precio Compra', Cantidad AS 'Cantidad', Precio_Venta AS 'Precio de Venta', Categoria AS 'Categoría', Id_Proveedor AS 'Id Proveedor' FROM PRODUCTO";
                    
                    if (categoriaSeleccionada != "Todas")
                    {
                        consulta += " WHERE Categoria = @categoria";
                    }

                    MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                    if (categoriaSeleccionada != "Todas")
                    {
                        cmd.Parameters.AddWithValue("@categoria", categoriaSeleccionada);
                    }

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvProductos.DataSource = dt;

                    if (dgvProductos.Columns.Contains("ID"))
                        dgvProductos.Columns["ID"].Visible = false;
                    if (dgvProductos.Columns.Contains("Precio Compra"))
                        dgvProductos.Columns["Precio Compra"].Visible = false;
                    if (dgvProductos.Columns.Contains("Id Proveedor"))
                        dgvProductos.Columns["Id Proveedor"].Visible = false;

                    dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvProductos.ReadOnly = true;
                    dgvProductos.AllowUserToAddRows = false;
                    dgvProductos.AllowUserToDeleteRows = false;
                    dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
                    dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}


