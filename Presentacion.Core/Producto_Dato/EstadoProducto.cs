using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Producto_Dato
{
    public partial class EstadoProducto : FormularioBase
    {
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProductoServicio productoServicio;
        private readonly IColegioServicio colegioServicio;

        List<Producto_Dato_Dto> ListaDatos;

        protected long EntidadId;

        public long _Producto_Pedido_Id;

        public EstadoProducto(long producto_pedido_Id)
        {
            InitializeComponent();

            producto_Dato_Servicio = new Producto_Dato_Servicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            productoServicio = new ProductoServicio();
            colegioServicio = new ColegioServicio();

            ListaDatos = new List<Producto_Dato_Dto>();

            _Producto_Pedido_Id = producto_pedido_Id;

            Descripcion(producto_pedido_Id);

            CargarGrilla(producto_pedido_Id);
        }

        public void CargarGrilla(long id)
        {
            ListaDatos = producto_Dato_Servicio.ObtenerProductosPorPedidoId(id);

            dgvGrilla.DataSource = ListaDatos.ToList();
            FormatearGrilla(dgvGrilla);
        }

        public void Descripcion(long producto_pedido_Id)
        {
            var Datos = producto_Dato_Servicio.ObtenerProductoPedidoPorId(producto_pedido_Id);

            lblNombre.Text = $"{Datos.ProductoDescripcion}";
            lblColegio.Text = colegioServicio.ObtenerPorId(productoServicio.ObtenerPorId(Datos.ProductoId).ColegioId).Descripcion;
            lblTalle.Text = $"Talle: {Datos.Talle}";

        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["ProductoDescripcion"].Visible = true;
            grilla.Columns["ProductoDescripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ProductoDescripcion"].HeaderText = @"Descripcion";
            grilla.Columns["ProductoDescripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["ProductoDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoPorPedido"].Visible = true;
            grilla.Columns["EstadoPorPedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoPorPedido"].HeaderText = @"Estado";
            grilla.Columns["EstadoPorPedido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstadoPorPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                EntidadId = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                EntidadId = 0;
            }
        }

        public void VerEstado(long id)
        {
            var dato = producto_Dato_Servicio.ObtenerPorId(id);

            if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.EnEspera)
            {
                btnEnEspera.Enabled = false;

                btnCancelado.Enabled = true;
                btnTerminado.Enabled = true;
            }

            if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.Terminado)
            {
                btnTerminado.Enabled = false;

                btnCancelado.Enabled = true;
                btnEnEspera.Enabled = true;
            }

            if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.Cancelado)
            {
                btnCancelado.Enabled = false;

                btnTerminado.Enabled = true;
                btnEnEspera.Enabled = true;
            }

        }

        private void btnEnEspera_Click(object sender, EventArgs e)
        {
            if (producto_Dato_Servicio.ObtenerPorId(EntidadId).EstadoPorPedido != AccesoDatos.EstadoPorPedido.EnEspera)
            {
                if (MessageBox.Show("Esta Por Cambiar El Estado Del Producto, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    producto_Dato_Servicio.CambiarEstadoEnEspera(EntidadId);

                    CargarGrilla(_Producto_Pedido_Id);
                }
            }
        }

        private void btnTerminado_Click(object sender, EventArgs e)
        {
            if (producto_Dato_Servicio.ObtenerPorId(EntidadId).EstadoPorPedido != AccesoDatos.EstadoPorPedido.Terminado)
            {
                if (MessageBox.Show("Esta Por Cambiar El Estado Del Producto, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    producto_Dato_Servicio.CambiarEstadoTerminado(EntidadId);

                    CargarGrilla(_Producto_Pedido_Id);
                }
            }
        }

        private void btnCancelado_Click(object sender, EventArgs e)
        {
            if (producto_Dato_Servicio.ObtenerPorId(EntidadId).EstadoPorPedido != AccesoDatos.EstadoPorPedido.Cancelado)
            {
                if (MessageBox.Show("Esta Por Cambiar El Estado Del Producto, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    producto_Dato_Servicio.CambiarEstadoCancelado(EntidadId);

                    CargarGrilla(_Producto_Pedido_Id);
                }
            }
        }
    }
}
