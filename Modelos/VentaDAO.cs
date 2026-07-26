using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class VentaDAO
    {
        public bool RegistrarVenta(int idCliente, string origenPedido, int idUsuario, decimal total, DataTable carrito)
        {
            bool exito = false;
            Conexion db = new Conexion();
            
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    MySqlTransaction transaccion = con.BeginTransaction();
                    try
                    {
                        // 1. Insertar VENTA
                        string queryVenta = @"INSERT INTO VENTA (Fecha_Hora, Estado_Venta, Origen_Pedido, Id_Usuario, Id_Cliente) 
                                              VALUES (NOW(), 'Completada', @origen, @idUsuario, @idCliente);
                                              SELECT LAST_INSERT_ID();";
                                              
                        long idVenta = 0;
                        using (MySqlCommand cmdVenta = new MySqlCommand(queryVenta, con, transaccion))
                        {
                            cmdVenta.Parameters.AddWithValue("@origen", origenPedido);
                            cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdVenta.Parameters.AddWithValue("@idCliente", idCliente);
                            
                            idVenta = Convert.ToInt64(cmdVenta.ExecuteScalar());
                        }

                        // 2. Insertar DETALLE_VENTA y descontar stock en PRODUCTO
                        string queryDetalle = @"INSERT INTO DETALLE_VENTA (Cantidad, Precio_Unitario, Id_Venta, Id_Producto) 
                                                VALUES (@cant, @precio, @idVenta, @idProd)";
                                                
                        string queryStock = @"UPDATE PRODUCTO SET Cantidad = Cantidad - @cant WHERE Id_Producto = @idProd";

                        foreach (DataRow row in carrito.Rows)
                        {
                            int idProducto = Convert.ToInt32(row["IdProducto"]);
                            int cantidad = Convert.ToInt32(row["Cantidad"]);
                            decimal precio = Convert.ToDecimal(row["PrecioUnitario"]);

                            // Detalle
                            using (MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, con, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@cant", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precio", precio);
                                cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                                cmdDetalle.Parameters.AddWithValue("@idProd", idProducto);
                                cmdDetalle.ExecuteNonQuery();
                            }

                            // Descontar Stock
                            using (MySqlCommand cmdStock = new MySqlCommand(queryStock, con, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue("@cant", cantidad);
                                cmdStock.Parameters.AddWithValue("@idProd", idProducto);
                                cmdStock.ExecuteNonQuery();
                            }
                        }

                        // Si todo sale bien, confirmar transacción
                        transaccion.Commit();
                        exito = true;
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla, deshacer todo
                        transaccion.Rollback();
                        throw new Exception("Error al registrar la venta: " + ex.Message);
                    }
                }
            }
            return exito;
        }

        public DataTable ObtenerClientesParaCombo()
        {
            DataTable dt = new DataTable();
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    string query = "SELECT Id_Cliente, CONCAT(Nombre, ' ', Apellido_Paterno) AS NombreCompleto FROM CLIENTE";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenerProductosParaCombo()
        {
            DataTable dt = new DataTable();
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == ConnectionState.Open)
                {
                    string query = "SELECT Id_Producto, Nombre, Precio_Venta, Cantidad FROM PRODUCTO WHERE Cantidad > 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            return dt;
        }
    }
}
