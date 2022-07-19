using AccesoDatos;
using System;

namespace Servicios.Core.Arreglo.Dto
{
    public class ArregloDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaPedido { get; set; }

        public string FechaPedidoString => FechaPedido.ToLongDateString();

        public DateTime FechaEntrega { get; set; }

        public string FechaEntregaString => FechaEntrega.ToLongDateString();

        public DateTime? FechaRetirado { get; set; }

        //DateTime FechaRetiradoNotNull => (DateTime)FechaRetirado;

        public string FechaRetiradoString { get; set; }

        public EstadoArreglo Estado { get; set; }

        public string Horario { get; set; }

        public decimal Cantidad { get; set; }

        public string Descripcion { get; set; }

        public string ApyNom => Apellido + " " + Nombre;

        public double Total { get; set; }

        public string TotalString => Total.ToString("00.00");

        public double Adelanto { get; set; }

        public bool EstaEliminado { get; set; }

        public long ClienteId { get; set; }

        public long NumeroOperacion { get; set; }
    }
}
