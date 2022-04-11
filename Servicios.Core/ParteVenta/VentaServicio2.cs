using Servicios.Core.ParteVenta.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.ParteVenta
{
    public class VentaServicio2 : IVentaServicio2
    {
        public static List<VentaDto2> _detalleComprobantes;

        public static void InicializarDetallesDeFactura()
        {
            if (_detalleComprobantes == null)
            {
                _detalleComprobantes = new List<VentaDto2>();
            }

        }
        public void InsertarProducto(string descripcion, decimal precio, int cantidad)
        {

            if (_detalleComprobantes.Any(x => x.Descripcion == descripcion))
            {
                var detalle = _detalleComprobantes.FirstOrDefault(x => x.Descripcion == descripcion);

                detalle.Cantidad += cantidad;
            }
            else
            {

                var detalle = new VentaDto2
                {
                    Descripcion = descripcion,
                    Precio = precio,
                    Cantidad = cantidad,
                };

                _detalleComprobantes.Add(detalle);

            }
        }

        public List<VentaDto2> Obtener(string cadenaBuscar)
        {
            return _detalleComprobantes.Where(x => x.Descripcion.Contains(cadenaBuscar)).ToList();
        }

        public VentaDto2 ObtenerPorCodigo(string codigo)
        {
            return _detalleComprobantes.FirstOrDefault(x => x.Descripcion == codigo);
        }

        public void ReiniciarListaDeLaGrilla()
        {
            _detalleComprobantes = new List<VentaDto2>();

        }

    }
}
