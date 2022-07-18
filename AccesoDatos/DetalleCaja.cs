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
    
    public partial class DetalleCaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetalleCaja()
        {
            this.DetalleProducto = new HashSet<DetalleProducto>();
        }
    
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public long CajaId { get; set; }
        public string Fecha { get; set; }
        public TipoPago TipoPago { get; set; }
        public long NumeroOperacion { get; set; }
        public bool EstaEliminado { get; set; }
    
        public virtual Caja Caja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
    }
}
