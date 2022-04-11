using Servicios.Core.Producto.Dto;
using System.Collections.Generic;

namespace Servicios.Core.Producto
{
    public interface IProductoServicio
    {
        void Nuevo(ProductoDto dto);

        void Eliminar(long id);

        void Modificar(ProductoDto dto);

        void BajarStock(long id, decimal stock);

        IEnumerable<ProductoDto> Buscar(string cadenaBuscar);

        ProductoDto ObtenerPorId(long Id);
    }
}
