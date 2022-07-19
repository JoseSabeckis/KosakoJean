using AccesoDatos;
using System;

namespace Servicios.Core.CtaCte.Dto
{
    public class CtaCteDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public double Total { get; set; }

        public double Debe { get; set; }

        public DateTime Fecha { get; set; }

        public CtaCteEstado Estado { get; set; }

        public long ClienteId { get; set; }

        public long PedidoId { get; set; }

        public long NumeroOperacion { get; set; }


    }
}
