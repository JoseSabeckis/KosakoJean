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
    
    public partial class Caja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caja()
        {
            this.DetalleCaja = new HashSet<DetalleCaja>();
        }
    
        public long Id { get; set; }
        public double TotalCaja { get; set; }
        public double MontoApertura { get; set; }
        public double MontoCierre { get; set; }
        public System.DateTime FechaApertura { get; set; }
        public string FechaCierre { get; set; }
        public OpenClose OpenClose { get; set; }
        public bool EstaEliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCaja> DetalleCaja { get; set; }
    }
}
