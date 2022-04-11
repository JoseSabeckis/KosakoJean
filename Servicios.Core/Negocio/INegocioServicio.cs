using Servicios.Core.Negocio.Dto;

namespace Servicios.Core.Negocio
{
    public interface INegocioServicio
    {
        void Insertar(NegocioDto negocioDto);

        void Modificar(NegocioDto negocioDto);

        NegocioDto ObtenerPorId(long id);
    }
}
