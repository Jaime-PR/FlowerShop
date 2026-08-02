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

        private void frmInicio_Sesion_Load(object sender, EventArgs e)
        {
            // Centrar controles manualmente en la carga
            pnlLeft_Resize(this, EventArgs.Empty);
            pnlRight_Resize(this, EventArgs.Empty);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlCard, 15);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlUser, 10);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(pnlPassword, 10);
            FlowerShop.Utilidades.UIHelper.AplicarBordesRedondeados(btnLogin, 10);
        }

        private void pnlLeft_Resize(object sender, EventArgs e)
        {
            if (pnlLeft != null)
            {
                pnlLeft.Width = this.Width / 2;
                
                // Centrar título principal
                lblTituloPrincipal.Left = (pnlLeft.Width - lblTituloPrincipal.Width) / 2;
                lblTituloPrincipal.Top = (pnlLeft.Height / 2) - lblTituloPrincipal.Height;
                
                // Centrar subtítulo
                lblSubtitulo.Left = (pnlLeft.Width - lblSubtitulo.Width) / 2;
                lblSubtitulo.Top = lblTituloPrincipal.Bottom + 10;
            }
        }

        private void pnlRight_Resize(object sender, EventArgs e)
        {
            if (pnlRight != null && pnlCard != null)
            {
                pnlCard.Left = (pnlRight.Width - pnlCard.Width) / 2;
                pnlCard.Top = (pnlRight.Height - pnlCard.Height) / 2;
            }
        }

        private void lklblCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCrear_Cuenta crearCuentaForm = new frmCrear_Cuenta();
            crearCuentaForm.Show();
            this.Hide();
        }
    }
}