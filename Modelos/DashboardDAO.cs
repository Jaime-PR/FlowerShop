using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class DashboardDAO
    {
        public decimal ObtenerIngresosTotales()
        {
            decimal total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        // Calculating sum from detalle_venta as requested
                        string query = "SELECT IFNULL(SUM(Precio_Unitario), 0) FROM DETALLE_VENTA";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            total = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener ingresos totales: " + ex.Message);
                    }
                }
            }
            return total;
        }

        public int ObtenerVentasTotales()
        {
            int total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        string query = "SELECT COUNT(*) FROM VENTA";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            total = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener ventas totales: " + ex.Message);
                    }
                }
            }
            return total;
        }

        public int ObtenerClientesTotales()
        {
            int total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        string query = "SELECT COUNT(*) FROM CLIENTE";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            total = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener clientes totales: " + ex.Message);
                    }
                }
            }
            return total;
        }

        public DataTable ObtenerUsuariosVendedores()
        {
            DataTable dt = new DataTable();
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        // Explicitly omitting Id_Usuario per user request
                        string query = "SELECT Nombre, Apellido_Paterno, Apellido_Materno, Correo, Telefono, Rol FROM USUARIO WHERE Rol = 'Vendedor'";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener usuarios vendedores: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public DataTable ObtenerUltimasVentas()
        {
            DataTable dt = new DataTable();
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        string query = "SELECT CONCAT(C.Nombre, ' ', C.Apellido_Paterno) AS 'Cliente', V.Fecha_Hora AS 'Fecha', V.Estado_Venta AS 'Estado' FROM VENTA V LEFT JOIN CLIENTE C ON V.Id_Cliente = C.Id_Cliente ORDER BY V.Id_Venta DESC LIMIT 5";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener últimas ventas: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}

