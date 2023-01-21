using Servicios.Core.TalleSegunProductoPrecio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.TalleSegunProductoPrecio
{
    public interface ITalleSegunProductoServicio
    {
        void Nuevo(TalleSegunProductoPrecioDto Dto);
        void Eliminar(long id);
        void Modificar(TalleSegunProductoPrecioDto Dto);
        TalleSegunProductoPrecioDto ObtenerPorId(long Id);
        IEnumerable<TalleSegunProductoPrecioDto> ObtenerListaPorPrecioSegunTalleId(long precioSegunTalleId);
    }
}
