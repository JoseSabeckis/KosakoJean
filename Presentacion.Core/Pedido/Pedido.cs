using Presentacion.Core.Cobro;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Pedido
{
    public partial class Pedido : Form
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProductoServicio productoServicio;

        public bool semaforo = false;

        List<VentaDto2> ListaVentas;

        public Pedido(List<VentaDto2> Lista)
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            productoServicio = new ProductoServicio();

            ListaVentas = Lista;
        }

        public bool AsignarControles()
        {
            if (txtApellido.Text == string.Empty)
            {
                return false;
            }

            if (txtNombre.Text == string.Empty)
            {
                return false;
            }

            return true;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (AsignarControles())
            {
                if (MessageBox.Show("Esta Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = new PedidoDto
                    {
                        Adelanto = nudAdelanto.Value,
                        Apellido = txtApellido.Text,
                        FechaPedido = DateTime.Now,
                        Nombre = txtNombre.Text,
                        Proceso = AccesoDatos.Proceso.InicioPedido,
                        FechaEntrega = dtpFechaEntrega.Value,
                        Total = ListaVentas.Sum(x => x.Precio)
                    };

                    var pedidoId = pedidoServicio.NuevoPedido(pedido);

                    foreach (var item in ListaVentas)
                    {

                        var aux = new Producto_Pedido_Dto
                        {
                            Cantidad = item.Cantidad,
                            ProductoId = productoServicio.ObtenerPorId(item.Id).Id,
                            Estado = AccesoDatos.EstadoPedido.Esperando,
                            Talle = item.Talle,
                            PedidoId = pedidoId
                        };

                    }

                    MessageBox.Show("Listo Pedido Creado!", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    semaforo = true;

                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("El Campo Apellido y Nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
