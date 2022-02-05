using Servicios.Core.Talle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Talle
{
    public interface ITalleServicio
    {
        void Nuevo(TalleDto talleDto);
        void Eliminar(long id);
        void Modificar(TalleDto talleDto);
        IEnumerable<TalleDto> Buscar(string cadenaBuscar);
        TalleDto ObtenerPorId(long talleId);
    }
}
