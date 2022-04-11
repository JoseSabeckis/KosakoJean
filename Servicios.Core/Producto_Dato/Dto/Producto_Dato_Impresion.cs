using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Dato.Dto
{
    public class Producto_Dato_Impresion
    {
        public long Id { get; set; }

        public EstadoPorPedido EstadoPorPedido { get; set; }

        public long Producto_PedidoId { get; set; }

        public string ProductoDescripcion { get; set; }

        public string Colegio { get; set; }

        public string ProductoTalle { get; set; }

        public string Cliente { get; set; }

        public bool EstaEliminado { get; set; }
    }
}
