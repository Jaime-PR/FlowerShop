using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlowerShop.Modelos
{
    public class ReporteDAO
    {
        private string cadenaConexion = "Server=localhost;Database=flowershop;Uid=root;Pwd=;Port=3306;SslMode=Disabled;";

        private DataTable EjecutarConsulta(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(cadenaConexion))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el reporte: " + ex.Message);
            }
            return dt;
        }

        public DataTable ObtenerTopProductos()
        {
            string query = @"
                SELECT p.Nombre, SUM(dv.Cantidad) AS 'Unidades Vendidas' 
                FROM PRODUCTO p 
                INNER JOIN DETALLE_VENTA dv ON p.Id_Producto = dv.Id_Producto 
                GROUP BY p.Id_Producto, p.Nombre 
                ORDER BY SUM(dv.Cantidad) DESC 
                LIMIT 15;";
            return EjecutarConsulta(query);
        }

        public DataTable ObtenerMejoresClientes()
        {
            string query = @"
                SELECT CONCAT(c.Nombre, ' ', c.Apellido_Paterno) AS Cliente, 
                       COUNT(DISTINCT v.Id_Venta) AS 'Total Compras', 
                       SUM(dv.Precio_Unitario * dv.Cantidad) AS 'Total Gastado' 
                FROM CLIENTE c 
                INNER JOIN VENTA v ON c.Id_Cliente = v.Id_Cliente 
                INNER JOIN DETALLE_VENTA dv ON v.Id_Venta = dv.Id_Venta 
                GROUP BY c.Id_Cliente, c.Nombre, c.Apellido_Paterno 
                ORDER BY SUM(dv.Precio_Unitario * dv.Cantidad) DESC 
                LIMIT 15;";
            return EjecutarConsulta(query);
        }

        public DataTable ObtenerResumenVentasPorDia()
        {
            string query = @"
                SELECT DATE(v.Fecha_Hora) AS 'Fecha', 
                       COUNT(DISTINCT v.Id_Venta) AS 'Número de Ventas', 
                       SUM(dv.Precio_Unitario * dv.Cantidad) AS 'Ingresos Totales' 
                FROM VENTA v 
                INNER JOIN DETALLE_VENTA dv ON v.Id_Venta = dv.Id_Venta 
                GROUP BY DATE(v.Fecha_Hora) 
                ORDER BY DATE(v.Fecha_Hora) DESC;";
            return EjecutarConsulta(query);
        }

        public DataTable ObtenerVentasPorVendedor()
        {
            string query = @"
                SELECT u.Nombre AS 'Vendedor', u.Rol, 
                       COUNT(DISTINCT v.Id_Venta) AS 'Ventas Realizadas', 
                       SUM(dv.Precio_Unitario * dv.Cantidad) AS 'Ingreso Generado' 
                FROM USUARIO u 
                INNER JOIN VENTA v ON u.Id_Usuario = v.Id_Usuario 
                INNER JOIN DETALLE_VENTA dv ON v.Id_Venta = dv.Id_Venta 
                GROUP BY u.Id_Usuario, u.Nombre, u.Rol 
                ORDER BY SUM(dv.Precio_Unitario * dv.Cantidad) DESC;";
            return EjecutarConsulta(query);
        }

        public DataTable ObtenerProductosPocoInventario()
        {
            string query = @"
                SELECT Nombre, Categoria, Cantidad AS 'Stock Actual', Precio_Venta AS 'Precio de Venta' 
                FROM PRODUCTO 
                WHERE Cantidad <= 10 
                ORDER BY Cantidad ASC;";
            return EjecutarConsulta(query);
        }
    }
}


