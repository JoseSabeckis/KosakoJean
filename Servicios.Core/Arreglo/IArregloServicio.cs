using Servicios.Core.Arreglo.Dto;
using System;
using System.Collections.Generic;

namespace Servicios.Core.Arreglo
{
    public interface IArregloServicio
    {
        long Insertar(ArregloDto arregloDto);
        ArregloDto ObtenerPorId(long id);
        void CambiarAEnEsperaYFechaDeRetiro(long id);
        void GuardarDescripcion(long id, string descripcion);
        IEnumerable<ArregloDto> ListaArreglosEnEsperaBusqueda(string descripcion);
        IEnumerable<ArregloDto> ListaArreglosRetiradosBusqueda(string descripcion);
        IEnumerable<ArregloDto> ListaArreglos();
        IEnumerable<ArregloDto> ListaArreglosRetirados();
        IEnumerable<ArregloDto> ListaArreglosEnEspera();
        void ModificarDescripcion(long id, string descripcion);
        void CambiarARetiradoYFechaDeRetiro(long id, DateTime date);
        void Cobrar(long id, double dinero);
        void Eliminar(long id);
        void EliminarEnSerio(long id);
    }
}
