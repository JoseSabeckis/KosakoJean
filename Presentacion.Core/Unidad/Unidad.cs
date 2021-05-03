﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Pedido;
using Presentacion.Core.Pedido;

namespace Presentacion.Core.Unidad
{
    public partial class Unidad : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;
        private readonly IPedidoServicio pedidoServicio;

        PedidoDto Pedido;

        long pedidoID;
        long PedidoID;

        AccesoDatos.EstadoPedido estado;

        public Unidad(PedidoDto pedidoDto)
        {
            InitializeComponent();

            pedido_Producto_Servicio = new Producto_Pedido_Servicio();
            producto = new ProductoServicio();
            pedidoServicio = new PedidoServicio();

            Pedido = pedidoDto;

            VerDatos();
        }

        private void VerDatos()
        {
            lblFecha.Text = $"{Pedido.FechaEntrega.ToString("dd/MM/yyyy")}";

            lblNombre.Text = $"{Pedido.Apellido} - {Pedido.Nombre}";

            lblId.Text = $"{Pedido.Id}";
            pedidoID = Pedido.Id;
            
            var respuesta = pedido_Producto_Servicio.BuscarId(Pedido.Id);
            
            foreach (var item in respuesta)
            {
                lblProducto2.Text += $"{respuesta.FirstOrDefault(x => x.Id == item.Id).Descripcion} | ";
                lblIdPedido.Text = $"{item.PedidoId}";
                PedidoID = item.PedidoId;
                estado = item.Estado;
            }
            
        }

        private void pasarAEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRealizado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta por cambiar al Producto a Terminado, Tiene que Retirar el Cliente, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedido_Producto_Servicio.CambiarEstado(pedidoID);
                pedidoServicio.CambiarProcesoRetiro(PedidoID);

                MessageBox.Show("Listo!, Vamos Paula!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var pedido = new PedidoInfo(PedidoID, estado);
            pedido.ShowDialog();
        }
    }
}
