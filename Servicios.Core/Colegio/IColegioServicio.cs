using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
