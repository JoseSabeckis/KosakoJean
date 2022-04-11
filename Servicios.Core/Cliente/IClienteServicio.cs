using Servicios.Core.Cliente.Dto;
using System.Collections.Generic;

namespace Servicios.Core.Cliente
{
    public interface IClienteServicio
    {
        ClienteDto ObtenerPorId(long colegioId);

        IEnumerable<ClienteDto> Buscar(string cadenaBuscar);

        bool VerificarDni(string _dni);

        void PasarPrincipal(long clienteId);

        void Modificar(ClienteDto Dto);

        void Eliminar(long id);

        void Nuevo(ClienteDto Dto);
    }
}
