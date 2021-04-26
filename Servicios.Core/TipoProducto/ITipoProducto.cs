using Servicios.Core.TipoProducto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
