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
    public partial class frmRproveedor : Form
    {
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";

        public frmRproveedor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;


            this.btnCancelar.Click += btnCancelar_Click;
        }




        private void frmRproveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNEmpresa.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRFC.Text))
            {
                MessageBox.Show("Por favor, completa el formulario con los campos obligatorios.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            
            string query = @"INSERT INTO proveedor (Nombre_Empresa, Nombre, Apellido_Paterno, Apellido_Materno, RFC, Telefono, Correo, Direccion, Ciudad, Estado, Codigo_Postal) 
                     VALUES (@Nombre_Empresa, @Nombre, @Apellido_Paterno, @Apellido_Materno, @RFC, @Telefono, @Correo, @Direccion, @Ciudad, @Estado, @Codigo_Postal)";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        
                        comando.Parameters.AddWithValue("@Nombre_Empresa", txtNEmpresa.Text.Trim());
                        comando.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        comando.Parameters.AddWithValue("@Apellido_Paterno", txtAPaterno.Text.Trim());
                        comando.Parameters.AddWithValue("@Apellido_Materno", txtAMaterno.Text.Trim());
                        comando.Parameters.AddWithValue("@RFC", txtRFC.Text.Trim());
                        comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                        comando.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                        comando.Parameters.AddWithValue("@Ciudad", txtCiudad.Text.Trim());
                        comando.Parameters.AddWithValue("@Estado", txtEstado.Text.Trim());
                        comando.Parameters.AddWithValue("@Codigo_Postal", txtCP.Text.Trim());

                        
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("El proveedor se ha registrado exitosamente.",
                                            "Registro Completo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el proveedor.",
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

          this.Close(); 
            
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtRFC.Clear();
            txtNEmpresa.Clear();
            txtCiudad.Clear();
            txtEstado.Clear();
            txtCP.Clear();
            txtDireccion.Clear();
            txtNombre.Focus(); 
        }
    }
}
