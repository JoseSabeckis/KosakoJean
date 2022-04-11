using Servicios.Core.TipoProducto.Dto;
using System.Collections.Generic;

namespace Servicios.Core.TipoProducto
{
    public interface ITipoProducto
    {
        void Nuevo(TipoProductoDto colegioDto);

        void Eliminar(long id);

        void Modificar(TipoProductoDto colegioDto);

        IEnumerable<TipoProductoDto> Buscar(string cadenaBuscar);

        TipoProductoDto ObtenerPorId(long colegioId);
    }
}
