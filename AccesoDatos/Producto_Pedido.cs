//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto_Pedido
    {
        public long Id { get; set; }
        public long ProductoId { get; set; }
        public long PedidoId { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Cantidad { get; set; }
        public string Talle { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
