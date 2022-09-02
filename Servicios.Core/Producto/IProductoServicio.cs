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

        void CambiarStock(long id, decimal stock);

        IEnumerable<ProductoDto> BuscarConBajoStock(decimal stock);

        IEnumerable<ProductoDto> BuscarConMayorStock(decimal stock);

        IEnumerable<ProductoDto> Buscar(string cadenaBuscar);

        ProductoDto ObtenerPorId(long Id);

        bool VerificarCodigoDeBarra(long cod, long id);

        long TraerNuevoCodBarra();

        ProductoDto ObtenerPorCodigoBarra(string codigo);

        bool VerificarCodigoDeBarraVerdadero(string cod, long id);
    }
}
