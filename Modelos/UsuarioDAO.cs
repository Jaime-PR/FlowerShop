using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class UsuarioDAO
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerTodosLosUsuarios()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Usuario as ID, Nombre, Apellido_Paterno as Apellido, Correo, Telefono, Rol, Estatus FROM usuario";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public int ObtenerTotalUsuarios()
        {
            int total = 0;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM usuario";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener total de usuarios: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return total;
        }

        public int ObtenerUsuariosActivos()
        {
            int total = 0;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM usuario WHERE Estatus = 'Activo' OR Estatus = '1'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios activos: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return total;
        }

        public int ObtenerUsuariosInactivos()
        {
            int total = 0;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM usuario WHERE Estatus = 'Inactivo' OR Estatus = '0'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios inactivos: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return total;
        }

        private string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool InsertarUsuario(string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string telefono, string rol, string username, string contrasena)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"INSERT INTO usuario (Nombre, Apellido_Paterno, Apellido_Materno, Correo, Telefono, Rol, username, contrasena, estatus) 
                                     VALUES (@nom, @apPat, @apMat, @correo, @tel, @rol, @usr, @pass, 'Activo')";
                    
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apPat", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apMat", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.Parameters.AddWithValue("@usr", username);
                    cmd.Parameters.AddWithValue("@pass", HashPassword(contrasena)); // Contraseña encriptada

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar usuario: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }

        public bool ActualizarContrasena(int idUsuario, string nuevaContrasena)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "UPDATE usuario SET contrasena = @pass WHERE Id_Usuario = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pass", HashPassword(nuevaContrasena));
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar contraseña: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }
    }
}
