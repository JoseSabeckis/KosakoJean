using Servicios.Core.Arreglo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Arreglo
{
    public interface IArregloServicio
    {
        void Insertar(ArregloDto arregloDto);
        ArregloDto ObtenerPorId(long id);
        void CambiarAEnEsperaYFechaDeRetiro(long id);
        void GuardarDescripcion(long id, string descripcion);
        IEnumerable<ArregloDto> ListaArreglos();
        IEnumerable<ArregloDto> ListaArreglosRetirados();
        IEnumerable<ArregloDto> ListaArreglosEnEspera();
        void ModificarDescripcion(long id, string descripcion);
        void CambiarARetiradoYFechaDeRetiro(long id, DateTime date);
        void Cobrar(long id, decimal dinero);
        void Eliminar(long id);
        void EliminarEnSerio(long id);
    }
}
