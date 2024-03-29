﻿using AccesoDatos;
using System;

namespace Servicios.Core.Pedido.Dto
{
    public class PedidoDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaPedido { get; set; }

        public DateTime FechaEntrega { get; set; }

        public double Adelanto { get; set; }

        public double Total { get; set; }

        public Proceso Proceso { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaIniciado { get; set; }

        public string FechaRetiro { get; set; }

        public string Horario { get; set; }

        public string DiasHastaRetiro { get; set; }

        public long ClienteId { get; set; }

        public bool EstaEliminado { get; set; }

    }
}
