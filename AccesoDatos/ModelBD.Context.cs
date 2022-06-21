﻿//------------------------------------------------------------------------------
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
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CtaCte> CtasCtes { get; set; }
        public virtual DbSet<Talle> Talles { get; set; }
        public virtual DbSet<Producto_Dato> Producto_Datos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Negocio> Negocios { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Arreglo> Arreglos { get; set; }
        public virtual DbSet<DetalleProducto> DetalleProductos { get; set; }
    }
}
