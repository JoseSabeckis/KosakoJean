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
    
    public partial class CtaCte
    {
        public long Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal Debe { get; set; }
        public string Descripcion { get; set; }
        public long ClienteId { get; set; }
        public CtaCteEstado Estado { get; set; }
        public long PedidoId { get; set; }
        public long NumeroOperacion { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
