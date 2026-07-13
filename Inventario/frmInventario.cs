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
        // Tu cadena de conexión (pon tu contraseña real)
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;";

        public frmInventario()
        {
            InitializeComponent();
        }

        // Este es el evento que se dispara al abrir la ventana
        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
            DarFormatoVisual();
        }

        private void CargarProductos()
        {
            // Hacemos un SELECT sencillo a tu tabla. 
            // Usamos AS para que los encabezados de la tabla digan exactamente lo que quieres.
            string consulta = @"SELECT 
                                Id_Producto AS 'Id_producto',  
                                Nombre AS 'Nombre_del_producto',
                                Cantidad AS 'stock',
                                Precio_Venta AS 'precio_venta', 
                                Precio_Compra AS 'precio_compra',
                                Categoria AS 'categoria',
                                Id_Proveedor AS 'Id_Proveedor'
                                FROM PRODUCTO";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Asignamos los datos (Cambia dataGridView1 si el tuyo se llama distinto)
                    dgvProductos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DarFormatoVisual()
        {
            
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
            dgvProductos.RowHeadersVisible = false;

            
            dgvProductos.AllowUserToAddRows = false;

            
            dgvProductos.ReadOnly = true;

            
            dgvProductos.BackgroundColor = System.Drawing.Color.DarkGray;
            dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
