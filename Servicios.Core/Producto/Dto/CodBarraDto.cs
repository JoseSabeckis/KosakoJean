using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Servicios.Core.Producto.Dto
{
    public class CodBarraDto
    {
        public long Id { get; set; }

        public long CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public string Colegio { get; set; }

        public string Extra { get; set; }

        public double Precio { get; set; }

        public byte[] Imagen { get; set; }

    }
}
