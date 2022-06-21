using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using System;

namespace Servicios.Core.ParteVenta.Dto
{
    public class VentaDto2
    {
        private readonly IProductoServicio productoServicio = new ProductoServicio();
        private readonly IColegioServicio colegioServicio = new ColegioServicio();

        public long Id { get; set; }

        public string Descripcion { get; set; }

        public long ProductoId { get; set; }

        public string Colegio => colegioServicio.ObtenerPorId(productoServicio.ObtenerPorId(ProductoId).ColegioId).Descripcion;

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public string Talle { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        //para imprimir
        public long DetalleCajaId { get; set; }
    }
}
