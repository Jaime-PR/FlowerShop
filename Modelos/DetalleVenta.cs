using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Modelos
{
    public class DetalleVenta
    {
        public int Id_Detalle_Venta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public int Id_Venta { get; set; }
        public int Id_Producto { get; set; }
    }
}

