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
                    
                    string query = "SELECT P.Id_Producto, P.Nombre, P.Precio_Compra, P.Cantidad, P.Precio_Venta, P.Categoria, P.Id_Proveedor, PR.Nombre_Empresa AS Proveedor FROM PRODUCTO P LEFT JOIN PROVEEDOR PR ON P.Id_Proveedor = PR.Id_Proveedor";
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
                            prod.Id_Proveedor = reader["Id_Proveedor"] != DBNull.Value ? Convert.ToInt32(reader["Id_Proveedor"]) : 0;
                            prod.Proveedor = reader["Proveedor"] != DBNull.Value ? reader["Proveedor"].ToString() : "";

                            
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
                    cmd.Parameters.AddWithValue("@id", productoModificado.Id_Producto); 

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

        public Producto ObtenerProductoPorId(int idProducto)
        {
            Producto prod = null;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Producto, Nombre, Precio_Compra, Cantidad, Precio_Venta, Categoria, Id_Proveedor FROM PRODUCTO WHERE Id_Producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prod = new Producto();
                            prod.Id_Producto = Convert.ToInt32(reader["Id_Producto"]);
                            prod.Nombre = reader["Nombre"].ToString();
                            prod.Precio_Compra = Convert.ToDecimal(reader["Precio_Compra"]);
                            prod.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            prod.Precio_Venta = Convert.ToDecimal(reader["Precio_Venta"]);
                            prod.Categoria = reader["Categoria"].ToString();
                            prod.Id_Proveedor = reader["Id_Proveedor"] != DBNull.Value ? Convert.ToInt32(reader["Id_Proveedor"]) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el producto: " + ex.Message);
                }
                finally { con.Close(); }
            }
            return prod;
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

        public List<string> ObtenerCategorias()
        {
            return new List<string> { "Arreglos", "Ramos", "Flores Sueltas", "Accesorios" };
        }

        public System.Data.DataTable ObtenerProductosInsumo()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Producto, Nombre, Categoria FROM producto WHERE Categoria NOT IN ('Ramos', 'Arreglos') ORDER BY Nombre";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener productos insumo: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }

        public Dictionary<int, string> ObtenerProveedoresParaCombo()
        {
            Dictionary<int, string> proveedores = new Dictionary<int, string>();
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Id_Proveedor, Nombre_Empresa FROM proveedor ORDER BY Nombre_Empresa";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        proveedores.Add(Convert.ToInt32(reader["Id_Proveedor"]), reader["Nombre_Empresa"].ToString());
                    }
                    reader.Close();
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
            return proveedores;
        }

        public bool InsertarProductoConReceta(string nombre, decimal precioCompra, int cantidad, decimal precioVenta, string categoria, int idProveedor, string receta)
        {
            bool exito = false;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();

            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"INSERT INTO producto (Nombre, Precio_Compra, Cantidad, Precio_Venta, Categoria, Id_Proveedor, Receta) 
                                     VALUES (@nombre, @precioCompra, @cantidad, @precioVenta, @categoria, @idProveedor, @receta)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@receta", string.IsNullOrEmpty(receta) ? (object)DBNull.Value : receta);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar producto: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return exito;
        }

        public bool ActualizarProductoConReceta(int idProducto, string nombre, decimal precioCompra, int cantidad, decimal precioVenta, string categoria, int idProveedor, string receta)
        {
            bool exito = false;
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"UPDATE PRODUCTO SET Nombre=@nombre, Precio_Compra=@precioCompra, Cantidad=@cantidad, Precio_Venta=@precioVenta, Categoria=@categoria, Id_Proveedor=@idProveedor, Receta=@receta 
                                     WHERE Id_Producto=@id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@receta", string.IsNullOrEmpty(receta) ? (object)DBNull.Value : receta);

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
                catch (Exception ex) { throw new Exception("Error al actualizar producto: " + ex.Message); }
                finally { con.Close(); }
            }
            return exito;
        }

        public string ObtenerReceta(int idProducto)
        {
            string receta = "";
            Conexion db = new Conexion();
            MySqlConnection con = db.ObtenerConexionAbierta();
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT Receta FROM PRODUCTO WHERE Id_Producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) receta = result.ToString();
                }
                catch (Exception ex) { throw new Exception("Error al obtener receta: " + ex.Message); }
                finally { con.Close(); }
            }
            return receta;
        }
    }
}


