using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FlowerShop.Modelos;

namespace FlowerShop.Datos
{
    public class DetalleVentaDAO
    {
        public List<DetalleVenta> ObtenerTodosLosDetalles()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Detalle_Venta, Cantidad, Precio_Unitario, Id_Venta, Id_Producto FROM DETALLE_VENTA";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetalleVenta det = new DetalleVenta();
                            det.Id_Detalle_Venta = Convert.ToInt32(reader["Id_Detalle_Venta"]);
                            // En caso de que la cantidad en BD sea un valor que pueda ser null, Convert.ToInt32 maneja DBNull como 0
                            det.Cantidad = reader["Cantidad"] != DBNull.Value ? Convert.ToInt32(reader["Cantidad"]) : 0;
                            det.Precio_Unitario = reader["Precio_Unitario"] != DBNull.Value ? Convert.ToDecimal(reader["Precio_Unitario"]) : 0;
                            det.Id_Venta = reader["Id_Venta"] != DBNull.Value ? Convert.ToInt32(reader["Id_Venta"]) : 0;
                            det.Id_Producto = reader["Id_Producto"] != DBNull.Value ? Convert.ToInt32(reader["Id_Producto"]) : 0;
                            
                            lista.Add(det);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar detalles de venta: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return lista;
        }
    }
}
