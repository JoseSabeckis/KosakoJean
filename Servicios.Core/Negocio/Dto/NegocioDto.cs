using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Negocio.Dto
{
    public class NegocioDto
    {
        public long Id { get; set; }

        public string RazonSocial { get; set; }

        public string Cuit { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public byte[] Imagen { get; set; }

    }
}
