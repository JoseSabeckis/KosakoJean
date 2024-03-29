﻿using Presentacion.Core.Mensaje;
using Presentacion.Core.Pedido;
using Servicios.Core.Caja;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Unidad
{
    public partial class Unidad : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;
        private readonly IPedidoServicio pedidoServicio;
        private readonly ICajaServicio cajaServicio;

        PedidoDto Pedido;

        AccesoDatos.EstadoPedido estado;

        public Unidad(PedidoDto pedidoDto)
        {
            InitializeComponent();

            pedido_Producto_Servicio = new Producto_Pedido_Servicio();
            producto = new ProductoServicio();
            pedidoServicio = new PedidoServicio();
            cajaServicio = new CajaServicio();

            Pedido = pedidoDto;

            VerDatos();
        }

        private void VerDatos()
        {
            lblFecha.Text = $"{Pedido.FechaEntrega.ToString("dddd \ndd/MM/yyyy")}";

            lblNombre.Text = $"{Pedido.Apellido} {Pedido.Nombre}";

            var dia = DateTime.Now.Date - Pedido.FechaIniciado.Date;

            lblFechaHastaRetiro.Text = $"Dias Esperando al Cliente: {dia.Days}";

            lblId.Text = $"{Pedido.Id}";

            var respuesta = pedido_Producto_Servicio.BuscarId(Pedido.Id);

            foreach (var item in respuesta)
            {
                var product = producto.ObtenerPorId(item.ProductoId);

                txtProductos.Text = $"{product.Descripcion} {product.Colegio} | ";
                lblIdPedido.Text = $"{item.PedidoId}";
                estado = item.Estado;
            }

        }

        private void pasarAEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRealizado_Click(object sender, EventArgs e)
        {
            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (MessageBox.Show("Esta por cambiar al Producto a Terminado, Tiene que Retirar el Cliente, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pedido_Producto_Servicio.CambiarEstado(Pedido.Id);
                    pedidoServicio.CambiarProcesoRetiro(Pedido.Id);

                    btnRealizado.Visible = false;

                    VerDatos();

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var completado = new Afirmacion(" |- Listo -|", "Pedido Fabricado.");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    completado.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("La Caja se encuentra Cerrada", "Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var pedido = new PedidoInfo(Pedido.Id, estado);
            pedido.ShowDialog();

            if (pedido.Eliminado)
            {
                btnRealizado.Visible = false;
            }
        }
    }
}
