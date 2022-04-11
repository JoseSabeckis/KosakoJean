using Servicios.Core.Talle.Dto;
using System.Collections.Generic;

namespace Servicios.Core.Talle
{
    public interface ITalleServicio
    {
        void Nuevo(TalleDto talleDto);
        void Eliminar(long id);
        void Modificar(TalleDto talleDto);
        IEnumerable<TalleDto> Buscar(string cadenaBuscar);
        TalleDto ObtenerPorId(long talleId);
        long BuscarNombreDevuelveId(string cadenaBuscar);
    }
}
