using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleProducto
{
    public class DetalleProductoDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public string Colegio { get; set; }

        public string Talle { get; set; }

        public decimal Cantidad { get; set; }

        public double Precio { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public long DetalleCajaId { get; set; }

        public long ProductoId { get; set; }

    }
}
