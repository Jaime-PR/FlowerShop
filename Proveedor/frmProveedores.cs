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

namespace FlowerShop.Proveedor
{
    public partial class frmProveedores : Form
    {
        private int idProveedorSeleccionado = 0;
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        public frmProveedores()
        {
            InitializeComponent();
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void CargarProveedores()
        {
            
            string consulta = @"SELECT Id_Proveedor AS 'ID', 
                                       Nombre_Empresa AS 'Empresa', 
                                       Nombre AS 'Nombre', 
                                       Apellido_Paterno, 
                                       Apellido_Materno, 
                                       RFC, 
                                       Telefono, 
                                       Correo, 
                                       Direccion, 
                                       Ciudad, 
                                       Estado, 
                                       Codigo_Postal 
                                FROM PROVEEDOR";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProveedor.DataSource = dt;


                    dgvProveedor.Columns["Apellido_Paterno"].Visible = false;
                    dgvProveedor.Columns["Apellido_Materno"].Visible = false;
                    dgvProveedor.Columns["RFC"].Visible = false;
                    dgvProveedor.Columns["Telefono"].Visible = false;
                    dgvProveedor.Columns["Correo"].Visible = false;
                    dgvProveedor.Columns["Direccion"].Visible = false;
                    dgvProveedor.Columns["Ciudad"].Visible = false;
                    dgvProveedor.Columns["Estado"].Visible = false;
                    dgvProveedor.Columns["Codigo_Postal"].Visible = false;


                    dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvProveedor.RowHeadersVisible = false;
                    dgvProveedor.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedor.Rows[e.RowIndex];

                
                idProveedorSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);

                
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApPaterno.Text = fila.Cells["Apellido_Paterno"].Value.ToString();
                txtApMaterno.Text = fila.Cells["Apellido_Materno"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtRFC.Text = fila.Cells["RFC"].Value.ToString();

                
                txtEmpresa.Text = fila.Cells["Empresa"].Value.ToString();
                txtCiudad.Text = fila.Cells["Ciudad"].Value.ToString();
                txtEstado.Text = fila.Cells["Estado"].Value.ToString();
                txtCP.Text = fila.Cells["Codigo_Postal"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
            }
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
