using System;
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

namespace Presentacion.Core.Unidad
{
    public partial class Unidad : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;

        PedidoDto Pedido;

        public Unidad(PedidoDto pedidoDto)
        {
            InitializeComponent();

            pedido_Producto_Servicio = new Producto_Pedido_Servicio();
            producto = new ProductoServicio();

            Pedido = pedidoDto;

            VerDatos();
        }

        private void VerDatos()
        {
            lblFecha.Text = $"{Pedido.FechaEntrega.Date}";

            lblNombre.Text = $"{Pedido.Apellido} - {Pedido.Nombre}";

            var respuesta = pedido_Producto_Servicio.BuscarId(Pedido.Id);
            
            foreach (var item in respuesta)
            {
                lblProducto.Text += $"{respuesta.FirstOrDefault(x=>x.Id == item.Id).Descripcion} | ";
            }
            
        }
    }
}
