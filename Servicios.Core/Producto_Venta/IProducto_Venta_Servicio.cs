using Servicios.Core.Producto_Venta.Dto;
using Servicios.Core.Venta.Dto;
using System.Collections.Generic;

namespace Servicios.Core.Producto_Venta
{
    public interface IProducto_Venta_Servicio
    {
        void Eliminar();

        bool VerVentas(string descripcion);

        void NuevoProductoVenta(Producto_Venta_Dto producto);

        VentaDto ObtenerDescripcion(long id);

        void CambiarCant(string descripcion, decimal cantidad);

        void PonerPorEjemplo(Producto_Venta_Dto producto);

        void CambiarEstado(long id);

        Producto_Venta_Dto ObtenerDescripcionPedido(long id);

        Producto_Venta_Dto ObtenerId(long id);

        IEnumerable<Producto_Venta_Dto> Obtener();
    }
}
