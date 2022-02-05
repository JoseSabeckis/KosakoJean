﻿using Presentacion.Clases;
using Servicios.Core.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Producto.Ctrl
{
    public partial class ProductoCtrol : UserControl
    {
        private readonly IProductoServicio productoServicio;

        long _ProductoId;

        public ProductoCtrol(long productoId)
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();

            _ProductoId = productoId;

            Datos();
        }

        public void Datos()
        {
            var producto = productoServicio.ObtenerPorId(_ProductoId);

            lblDescripcion.Text = producto.Descripcion;
            lblPrecio.Text = $"$ {producto.Precio}"; 
            ptbImagen.Image = ImagenDb.Convertir_Bytes_Imagen(producto.Foto);
        }

        private void ptbImagen_Click(object sender, EventArgs e)
        {
            var producto = new Producto_Abm(TipoOperacion.Modificar, _ProductoId);
            producto.ShowDialog();
        }
    }
}
