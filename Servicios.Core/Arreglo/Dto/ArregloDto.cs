using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Arreglo.Dto
{
    public class ArregloDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaPedido { get; set; }

        public DateTime FechaEntrega { get; set; }

        public DateTime? FechaRetirado { get; set; }

        public EstadoArreglo Estado { get; set; }

        public string Horario { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public decimal Total { get; set; }

        public decimal Adelanto { get; set; }

        public bool EstaEliminado { get; set; }

        public long ClienteId { get; set; }
    }
}
