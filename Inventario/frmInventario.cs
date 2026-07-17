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
        private string cadenaConexion = "Server=localhost;Database=lowershop;Uid=root;Pwd=;";
        public frmInventario()
        {
            InitializeComponent();
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
        private void AbrirFormulario<TForm>() where TForm : Form, new()
        {
            
            using (TForm formulario = new TForm())
            {
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog();
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgbInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

        }

        private void bntAñadir_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmAgg_Producto>();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.frmAgg_Producto>();
        }
    }

}
