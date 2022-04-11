using System.Collections.Generic;

namespace Servicios.Core.Colegio
{
    public interface IColegioServicio
    {
        void Nuevo(ColegioDto colegioDto);
        void Eliminar(long id);
        void Modificar(ColegioDto colegioDto);
        IEnumerable<ColegioDto> Buscar(string cadenaBuscar);
        ColegioDto ObtenerPorId(long colegioId);
    }
}
