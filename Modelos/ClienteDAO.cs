using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class ClienteDAO
    {
        private Conexion conexion = new Conexion();

        public bool InsertarCliente(string nombre, string apellidoPaterno, string apellidoMaterno, string telefono, string origen, string direccion, string correo)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"INSERT INTO cliente (Nombre, Apellido_Paterno, Apellido_Materno, Telefono, Origen, Direccion, Correo) 
                                     VALUES (@nom, @apPat, @apMat, @tel, @origen, @dir, @correo)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apPat", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apMat", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@origen", origen);
                    cmd.Parameters.AddWithValue("@dir", direccion);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar cliente: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }

        public DataTable ObtenerTodosLosClientes()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Cliente AS ID, Nombre, Apellido_Paterno AS Apellido, Telefono, Origen, Correo FROM cliente";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener clientes: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public List<string> ObtenerOrigenes()
        {
            return new List<string> { "Facebook", "Instagram", "WhatsApp", "Ninguna", "mostrador", "Tienda Física", "Teléfono" };
        }

        public bool ActualizarCliente(int idCliente, string nombre, string apellidoPaterno, string apellidoMaterno, string telefono, string origen, string direccion, string correo)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"UPDATE cliente SET Nombre=@nom, Apellido_Paterno=@apPat, Apellido_Materno=@apMat, Telefono=@tel, Origen=@origen, Direccion=@dir, Correo=@correo 
                                     WHERE Id_Cliente=@id";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apPat", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apMat", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@origen", origen);
                    cmd.Parameters.AddWithValue("@dir", direccion);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) exito = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar cliente: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }

        public bool EliminarCliente(int idCliente)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "DELETE FROM cliente WHERE Id_Cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                        throw new Exception("No se puede eliminar el cliente porque tiene ventas u otros registros asociados.");
                    throw new Exception("Error BD: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar cliente: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return exito;
        }

        public DataRow ObtenerClientePorId(int idCliente)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM cliente WHERE Id_Cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0) return dt.Rows[0];
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener cliente: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return null;
        }
    }
}

