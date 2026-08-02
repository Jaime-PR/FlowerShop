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
    }
}
