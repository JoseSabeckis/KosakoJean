//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arreglo
    {
        public long Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public EstadoArreglo Estado { get; set; }
        public string Horario { get; set; }
        public string Descripcion { get; set; }
        public long ClienteId { get; set; }
        public bool EstaEliminado { get; set; }
        public decimal Total { get; set; }
        public decimal Adelanto { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
