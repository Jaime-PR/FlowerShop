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
            AplicarBordesRedondeados(pnlListaClientes, 15);
            AplicarBordesRedondeados(pnlDatosP, 15);
            FlowerShop.Utilidades.UIHelper.FormatoDataGrid(dgvClientes);
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
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

        private void CargarClientes()
        {
            
            string consulta = @"SELECT Id_Cliente AS 'ID', 
                                       Nombre AS 'Nombre', 
                                       Apellido_Paterno AS 'Apellido Paterno', 
                                       Apellido_Materno AS 'Apellido Materno', 
                                       Telefono AS 'Teléfono',
                                       Origen AS 'Origen',
                                       Direccion AS 'Dirección',
                                       Correo AS 'Correo'
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

                    
                    if (dgvClientes.Columns.Contains("ID"))
                        dgvClientes.Columns["ID"].Visible = false;

                    if (!dgvClientes.Columns.Contains("btnEditar"))
                    {
                        DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                        btnEditar.Name = "btnEditar";
                        btnEditar.HeaderText = "Editar";
                        btnEditar.Text = "Editar";
                        btnEditar.UseColumnTextForButtonValue = true;
                        btnEditar.FlatStyle = FlatStyle.Flat;
                        dgvClientes.Columns.Add(btnEditar);
                    }

                    if (!dgvClientes.Columns.Contains("btnEliminar"))
                    {
                        DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                        btnEliminar.Name = "btnEliminar";
                        btnEliminar.HeaderText = "Eliminar";
                        btnEliminar.Text = "Eliminar";
                        btnEliminar.UseColumnTextForButtonValue = true;
                        btnEliminar.FlatStyle = FlatStyle.Flat;
                        dgvClientes.Columns.Add(btnEliminar);
                    }

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
                txtRedSocial.Text = fila.Cells["Origen"].Value.ToString();

                if (dgvClientes.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    pnlSidebarDerecho.Controls.Clear();
                    var frm = new FlowerShop.Clientes.frmAñadir_Cliente(idClienteSeleccionado);
                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    pnlSidebarDerecho.Controls.Add(frm);
                    pnlSidebarDerecho.Visible = true; pnlSidebarDerecho.BringToFront();
                    frm.OperacionCompletada += Frm_OperacionCompletada;
                    frm.Show();
                }
                else if (dgvClientes.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            FlowerShop.Modelos.ClienteDAO dao = new FlowerShop.Modelos.ClienteDAO();
                            if (dao.EliminarCliente(idClienteSeleccionado))
                            {
                                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarClientes();
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
                        pnlSidebarDerecho.Controls.Clear();
            var frm = new FlowerShop.Clientes.frmAñadir_Cliente();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlSidebarDerecho.Controls.Add(frm);
            pnlSidebarDerecho.Visible = true; pnlSidebarDerecho.BringToFront();
            frm.OperacionCompletada += Frm_OperacionCompletada;
            frm.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

                private void Frm_OperacionCompletada(object sender, EventArgs e)
        {
            pnlSidebarDerecho.Controls.Clear();
            pnlSidebarDerecho.Visible = false;
            CargarClientes();
        }
    }
}





