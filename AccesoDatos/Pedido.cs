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
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Producto_Pedido = new HashSet<Producto_Pedido>();
        }
    
        public long Id { get; set; }
        public decimal Total { get; set; }
        public decimal Adelanto { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Proceso Proceso { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public long ClienteId { get; set; }
        public string ApyNom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto_Pedido> Producto_Pedido { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
