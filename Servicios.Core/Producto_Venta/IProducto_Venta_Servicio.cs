using Servicios.Core.Producto_Venta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Venta
{
    public interface IProducto_Venta_Servicio
    {
        void NuevoProductoVenta(Producto_Venta_Dto producto);

        void CambiarEstado(long id);
    }
}
