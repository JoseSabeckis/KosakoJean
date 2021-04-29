using Servicios.Core.Producto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto
{
    public interface IProductoServicio
    {
        void Nuevo(ProductoDto dto);

        void Eliminar(long id);

        void Modificar(ProductoDto dto);

        IEnumerable<ProductoDto> Buscar(string cadenaBuscar);

        ProductoDto ObtenerPorId(long Id);
    }
}
