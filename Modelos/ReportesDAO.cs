using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class ReportesDAO
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerProductosBajoInventario(int umbral)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Nombre, Categoria, Cantidad, Precio_Venta AS 'Precio de Venta' FROM PRODUCTO WHERE Cantidad < @umbral ORDER BY Cantidad ASC";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@umbral", umbral);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en reporte bajo inventario: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public DataTable ObtenerVentasRecientes()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    // Assuming Venta has Fecha_Hora, Estado_Venta, Id_Cliente. We join with Cliente to get the name.
                    string query = @"SELECT V.Id_Venta AS 'Folio', V.Fecha_Hora AS 'Fecha', C.Nombre AS 'Cliente', V.Estado_Venta AS 'Estado', V.Origen_Pedido AS 'Origen'
                                     FROM VENTA V
                                     LEFT JOIN CLIENTE C ON V.Id_Cliente = C.Id_Cliente
                                     ORDER BY V.Fecha_Hora DESC LIMIT 50";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en reporte ventas recientes: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public DataTable ObtenerDistribucionClientes()
        {
            DataTable dt = new DataTable();
            MySqlConnection con = conexion.ObtenerConexionAbierta();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Origen, COUNT(Id_Cliente) AS 'Total de Clientes' FROM CLIENTE GROUP BY Origen ORDER BY COUNT(Id_Cliente) DESC";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en reporte distribucion clientes: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }
    }
}
