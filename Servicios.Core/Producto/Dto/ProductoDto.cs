using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto.Dto
{
    public class ProductoDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool EstaEliminado { get; set; }

        public string Extras { get; set; }

        public long ColegioId { get; set; }

        public string Colegio { get; set; }

        public long TipoProductoId { get; set; }

        public string TipoProducto { get; set; }

        public byte[] Foto { get; set; }
    }
}
