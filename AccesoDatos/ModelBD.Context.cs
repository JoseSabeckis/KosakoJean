﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KosakoDBEntities : DbContext
    {
        public KosakoDBEntities()
            : base("name=KosakoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoProducto> TipoProductos { get; set; }
        public virtual DbSet<Colegio> Colegios { get; set; }
        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<DetalleCaja> DetalleCajas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto_Pedido> Producto_Pedidos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<Producto_Venta> Producto_Ventas { get; set; }
    }
}
