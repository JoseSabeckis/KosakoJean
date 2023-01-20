using Servicios.Core.PrecioSegunTalle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.PrecioSegunTalle
{
    public interface IPrecioSegunTalleServicio
    {
        void Nuevo(PrecioSegunTalleDto Dto);
        void Eliminar(long id);
        void Modificar(PrecioSegunTalleDto Dto);
        PrecioSegunTalleDto ObtenerPorId(long precioSegunTalleId);
        IEnumerable<PrecioSegunTalleDto> BuscarTodos();
        bool VerificarSiEstaYaCreado(long productoId, long talleId);
        decimal ObtenerPrecio(long productoId, long talleId);
    }
}
