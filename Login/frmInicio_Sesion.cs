using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FlowerShop.Login
{
    public partial class frmInicio_Sesion : Form
    {
        public frmInicio_Sesion()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingresa un usuario y una contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT nombre FROM usuario WHERE username = @user AND contrasena = @cont";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@user", txtUser.Text);
                    cmd.Parameters.AddWithValue("@cont", txtPassword.Text);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        string nombreUsuario = resultado.ToString();
                        MessageBox.Show("Bienvenido, " + nombreUsuario, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        frmPantalla_Inicio mainForm = new frmPantalla_Inicio();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la autenticación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void frmInicio_Sesion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lklblCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCrear_Cuenta crearCuentaForm = new frmCrear_Cuenta();
            crearCuentaForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPantalla_Inicio mainForm = new frmPantalla_Inicio();
            mainForm.Show();
            this.Hide();
        }
    }
}
