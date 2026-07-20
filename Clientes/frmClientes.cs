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

namespace FlowerShop.Clientes
{
    public partial class frmClientes : Form
    {
        private int idClienteSeleccionado = 0;
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        public frmClientes()
        {
            InitializeComponent();
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            
            string consulta = @"SELECT Id_Cliente AS 'ID', 
                                       Nombre AS 'Nombre', 
                                       Apellido_Paterno AS 'Apellido Paterno', 
                                       Apellido_Materno AS 'Apellido Materno', 
                                       Telefono AS 'Teléfono',
                                       Red_Social AS 'Red Social' 
                                FROM CLIENTE";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvClientes.DataSource = dt;

                    
                    dgvClientes.Columns["Apellido Materno"].Visible = false;
                    dgvClientes.Columns["Teléfono"].Visible = false;
                    dgvClientes.Columns["Red Social"].Visible = false;

                    
                    dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                idClienteSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);

                
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApPaterno.Text = fila.Cells["Apellido Paterno"].Value.ToString();
                txtApMaterno.Text = fila.Cells["Apellido Materno"].Value.ToString();
                txtTelefono.Text = fila.Cells["Teléfono"].Value.ToString();

                
                txtRedSocial.Text = fila.Cells["Red Social"].Value.ToString();

               
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAñadirCliente_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<Clientes.frmRegistro_Clientes>();
            CargarClientes();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
