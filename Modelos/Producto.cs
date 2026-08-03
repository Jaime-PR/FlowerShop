using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Modelos
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio_Compra { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Venta { get; set; }
        public string Categoria { get; set; }
        public int Id_Proveedor { get; set; }
        public string Proveedor { get; set; }
    }
}
