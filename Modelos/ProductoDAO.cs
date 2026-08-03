using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FlowerShop.Modelos;
using FlowerShop.Login;
using System.Collections.Generic;

namespace FlowerShop.Datos
{
    public class ProductoDAO
    {
        public bool AgregarProducto(Producto nuevoProducto)
        {
            bool exito = false;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    
                    string query = "INSERT INTO productos (Nombre, Precio_Compra, Cantidad, Precio_Venta, Categoria, Id_Proveedor) " +
                                   "VALUES (@nombre, @precioCompra, @cantidad, @precioVenta, @categoria, @idProveedor)";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    
                    cmd.Parameters.AddWithValue("@nombre", nuevoProducto.Nombre);
                    cmd.Parameters.AddWithValue("@precioCompra", nuevoProducto.Precio_Compra);
                    cmd.Parameters.AddWithValue("@cantidad", nuevoProducto.Cantidad);
                    cmd.Parameters.AddWithValue("@precioVenta", nuevoProducto.Precio_Venta);
                    cmd.Parameters.AddWithValue("@categoria", nuevoProducto.Categoria);
                    cmd.Parameters.AddWithValue("@idProveedor", nuevoProducto.Id_Proveedor);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        exito = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar en la base de datos: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }
        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    
                    string query = "SELECT Id_Producto, Nombre, Precio_Compra, Cantidad, Precio_Venta, Categoria, Id_Proveedor FROM PRODUCTO";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            Producto prod = new Producto();

                            prod.Id_Producto = Convert.ToInt32(reader["Id_Producto"]);
                            prod.Nombre = reader["Nombre"].ToString();
                            prod.Precio_Compra = Convert.ToDecimal(reader["Precio_Compra"]);
                            prod.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            prod.Precio_Venta = Convert.ToDecimal(reader["Precio_Venta"]);
                            prod.Categoria = reader["Categoria"].ToString();
                            prod.Id_Proveedor = Convert.ToInt32(reader["Id_Proveedor"]);

                            
                            listaProductos.Add(prod);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar el inventario: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return listaProductos;
        }
        
        public bool ActualizarProducto(Producto productoModificado)
        {
            bool exito = false;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "UPDATE PRODUCTO SET Nombre = @nombre, Precio_Compra = @precioCompra, " +
                                   "Cantidad = @cantidad, Precio_Venta = @precioVenta, Categoria = @categoria, " +
                                   "Id_Proveedor = @idProveedor WHERE Id_Producto = @id";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@nombre", productoModificado.Nombre);
                    cmd.Parameters.AddWithValue("@precioCompra", productoModificado.Precio_Compra);
                    cmd.Parameters.AddWithValue("@cantidad", productoModificado.Cantidad);
                    cmd.Parameters.AddWithValue("@precioVenta", productoModificado.Precio_Venta);
                    cmd.Parameters.AddWithValue("@categoria", productoModificado.Categoria);
                    cmd.Parameters.AddWithValue("@idProveedor", productoModificado.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@id", productoModificado.Id_Producto); // El ID es clave para saber cuál actualizar

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return exito;
        }

        
        public bool EliminarProducto(int idProducto)
        {
            bool exito = false;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    
                    string query = "DELETE FROM PRODUCTO WHERE Id_Producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return exito;
        }

        public int ObtenerTotalProductosEnInventario()
        {
            int total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT SUM(Cantidad) FROM PRODUCTO";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = Convert.ToInt32(result);
                    }
                }
            }
            return total;
        }

        public int ObtenerProductosBajoStock(int umbral = 10)
        {
            int total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT COUNT(*) FROM PRODUCTO WHERE Cantidad > 0 AND Cantidad <= @umbral";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@umbral", umbral);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = Convert.ToInt32(result);
                    }
                }
            }
            return total;
        }

        public int ObtenerProductosSinStock()
        {
            int total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT COUNT(*) FROM PRODUCTO WHERE Cantidad = 0";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = Convert.ToInt32(result);
                    }
                }
            }
            return total;
        }

        public decimal ObtenerValorTotalInventario()
        {
            decimal total = 0;
            Conexion db = new Conexion();
            using (MySqlConnection con = db.ObtenerConexionAbierta())
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT SUM(Cantidad * Precio_Compra) FROM PRODUCTO";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
            }
            return total;
        }
    }
}
