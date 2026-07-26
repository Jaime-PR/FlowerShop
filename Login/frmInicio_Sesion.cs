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
using TuProyectoFloreria.Utilidades;

namespace FlowerShop.Login
{
    public partial class frmInicio_Sesion : Form
    {
        public frmInicio_Sesion()
        {
            InitializeComponent();
        }
        // Variable para controlar que no se reduzca más allá del tamaño original
        private float nivelZoomActual = 1.0f;

        // Factor de aumento: 1.1f significa que crecerá un 10% por cada clic
        private const float factorZoom = 1.1f;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingresa un usuario y una contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            
             string passwordCifrada = Seguridad.EncriptarSHA256(txtPassword.Text);

            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    
                    string query = "SELECT nombre, Rol FROM usuario WHERE username = @user AND contrasena = @cont";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@user", txtUser.Text);
                    cmd.Parameters.AddWithValue("@cont", passwordCifrada); // Cambiar a passwordCifrada cuando actives el Hashing

                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            string nombreUsuario = reader["nombre"].ToString();
                            string rolUsuario = reader["Rol"].ToString(); // Extraemos el Rol

                            MessageBox.Show("Bienvenido, " + nombreUsuario, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            
                            frmPantalla_Inicio mainForm = new frmPantalla_Inicio(rolUsuario);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void bntAlejar_Click(object sender, EventArgs e)
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

        private void btnAcercar_Click_1(object sender, EventArgs e)
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
    }
}