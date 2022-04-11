using AccesoDatos;
using System;

namespace Servicios.Core.CtaCte.Dto
{
    public class CtaCteDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Total { get; set; }

        public decimal Debe { get; set; }

        public DateTime Fecha { get; set; }

        public CtaCteEstado Estado { get; set; }

        public long ClienteId { get; set; }

        public long PedidoId { get; set; }


    }
}
