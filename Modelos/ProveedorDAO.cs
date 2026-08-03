using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class ProveedorDAO
    {
        private Conexion conexion = new Conexion();

        public bool InsertarProveedor(string nombreEmpresa, string nombre, string apellidoPaterno, string apellidoMaterno, string rfc, string telefono, string correo, string direccion, string ciudad, string estado, string codigoPostal, string categoria)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"INSERT INTO proveedor (Nombre_Empresa, Nombre, Apellido_Paterno, Apellido_Materno, RFC, Telefono, Correo, Direccion, Ciudad, Estado, Codigo_Postal, Categoria) 
                                     VALUES (@empresa, @nom, @apPat, @apMat, @rfc, @tel, @correo, @dir, @ciudad, @estado, @cp, @cat)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@empresa", nombreEmpresa);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apPat", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apMat", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@rfc", rfc);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@dir", direccion);
                    cmd.Parameters.AddWithValue("@ciudad", ciudad);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@cp", codigoPostal);
                    cmd.Parameters.AddWithValue("@cat", categoria);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar proveedor: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }

        public DataTable ObtenerTodosLosProveedores()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Proveedor AS ID, Nombre_Empresa AS Empresa, Nombre, Apellido_Paterno AS Apellido, Telefono, Correo, Ciudad, Categoria FROM proveedor";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener proveedores: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public List<string> ObtenerNombresEmpresas()
        {
            List<string> empresas = new List<string>();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Nombre_Empresa FROM proveedor ORDER BY Nombre_Empresa";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        empresas.Add(reader["Nombre_Empresa"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener nombres de empresas: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return empresas;
        }

        public List<string> ObtenerCategorias()
        {
            return new List<string> { "Arreglos", "Ramos", "Flores Sueltas", "Accesorios" };
        }

        public bool ActualizarProveedor(int idProveedor, string nombreEmpresa, string nombre, string apellidoPaterno, string apellidoMaterno, string rfc, string telefono, string correo, string direccion, string ciudad, string estado, string codigoPostal, string categoria)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"UPDATE proveedor SET Nombre_Empresa=@empresa, Nombre=@nom, Apellido_Paterno=@apPat, Apellido_Materno=@apMat, RFC=@rfc, Telefono=@tel, Correo=@correo, Direccion=@dir, Ciudad=@ciudad, Estado=@estado, Codigo_Postal=@cp, Categoria=@cat 
                                     WHERE Id_Proveedor=@id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    cmd.Parameters.AddWithValue("@empresa", nombreEmpresa);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apPat", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apMat", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@rfc", rfc);
                    cmd.Parameters.AddWithValue("@tel", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@dir", direccion);
                    cmd.Parameters.AddWithValue("@ciudad", ciudad);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@cp", codigoPostal);
                    cmd.Parameters.AddWithValue("@cat", categoria);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) exito = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar proveedor: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return exito;
        }

        public bool EliminarProveedor(int idProveedor)
        {
            bool exito = false;
            MySqlConnection con = conexion.ObtenerConexionAbierta();
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "DELETE FROM proveedor WHERE Id_Proveedor = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                        throw new Exception("No se puede eliminar el proveedor porque tiene productos asociados.");
                    throw new Exception("Error BD: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar proveedor: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return exito;
        }

        public DataRow ObtenerProveedorPorId(int idProveedor)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM proveedor WHERE Id_Proveedor = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0) return dt.Rows[0];
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener proveedor: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return null;
        }
    }
}
