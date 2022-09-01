using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.Talle;
using System;

namespace Servicios.Core.ParteVenta.Dto
{
    public class VentaDto2
    {
        private readonly IProductoServicio productoServicio = new ProductoServicio();
        private readonly IColegioServicio colegioServicio = new ColegioServicio();
        private readonly ITalleServicio talleServicio = new TalleServicio();

        public long Id { get; set; }

        public string Descripcion { get; set; }

        public long ProductoId { get; set; }

        public string Colegio => colegioServicio.ObtenerPorId(productoServicio.ObtenerPorId(ProductoId).ColegioId).Descripcion;

        public long ColegioId => productoServicio.ObtenerPorId(ProductoId).ColegioId;

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public string Talle { get; set; }

        public long? TalleId => talleServicio.BuscarNombreDevuelveId(Talle);

        public double Cantidad { get; set; }

        public double Precio { get; set; }

        public string PrecioString => Precio.ToString("00.00");

        //para imprimir
        public long DetalleCajaId { get; set; }
    }
}
