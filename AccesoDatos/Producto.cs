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
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Producto_Pedido = new HashSet<Producto_Pedido>();
            this.Producto_Venta = new HashSet<Producto_Venta>();
        }
    
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool EstaEliminado { get; set; }
        public string Extras { get; set; }
        public long TipoProductoId { get; set; }
        public long ColegioId { get; set; }
        public byte[] Foto { get; set; }
        public decimal Stock { get; set; }
        public bool Creacion { get; set; }
        public long CodigoBarra { get; set; }
        public byte[] ImagenCodBarra { get; set; }
        public string CodBarraVerdadero { get; set; }
        public bool CodCreado { get; set; }
    
        public virtual TipoProducto TipoProducto { get; set; }
        public virtual Colegio Colegio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto_Pedido> Producto_Pedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto_Venta> Producto_Venta { get; set; }
    }
}
