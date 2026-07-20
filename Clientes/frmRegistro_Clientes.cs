using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FlowerShop.Clientes
{
    public partial class frmRegistro_Clientes : Form
    {
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";
        public frmRegistro_Clientes()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;


            this.btnCancelar.Click += btnCancelar_Click;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, completa todos los datos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Cliente (Nombre, Apellido_Paterno, Apellido_Materno, Telefono, Red_Social, Direccion) 
                     VALUES (@Nombre, @Apellido_Paterno, @Apellido_Materno, @Telefono, @Red_Social, @Direccion)";

            try
            {
                
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        comando.Parameters.AddWithValue("@Apellido_Paterno", txtApellidoPaterno.Text.Trim());
                        comando.Parameters.AddWithValue("@Apellido_Materno", txtApellidoMaterno.Text.Trim());
                        comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                        comando.Parameters.AddWithValue("@Red_Social", txtRedSocial.Text.Trim());
                        comando.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());

                        
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("El cliente se ha registrado exitosamente.",
                                            "Registro Completo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            LimpiarCampos();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el cliente.",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar: " + ex.Message,
                                "Error de Excepción",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas cancelar el registro? Se perderán los datos no guardados.",
                                                     "Confirmar Cancelación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close(); 
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtTelefono.Clear();
            txtRedSocial.Clear();
            txtDireccion.Clear();
            txtNombre.Focus(); 
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidoPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidoMC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
