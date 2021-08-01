using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Pedido.Dto
{
    public class PedidoDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaPedido { get; set; }

        public DateTime FechaEntrega { get; set; }

        public decimal Adelanto { get; set; }

        public decimal Total { get; set; }

        public Proceso Proceso { get; set; }

        public long ClienteId { get; set; }

    }
}
