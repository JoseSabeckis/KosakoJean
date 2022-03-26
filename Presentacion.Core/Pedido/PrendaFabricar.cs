using Servicios.Core.Producto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
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
    public partial class PrendaFabricar : Form
    {
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProductoServicio productoServicio;

        protected long EntidadId;

        List<Producto_Dato_Dto> ListaRealizada;

        public PrendaFabricar()
        {
            InitializeComponent();

            producto_Dato_Servicio = new Producto_Dato_Servicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            productoServicio = new ProductoServicio();

            ListaRealizada = new List<Producto_Dato_Dto>();

            dgvGrillaRealizados.DataSource = ListaRealizada.ToList();
            FormatearGrilla(dgvGrillaRealizados);

            CargarGrilla();

        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = producto_Dato_Servicio.ObtenerProductosParaHacer().ToList();
            FormatearGrilla(dgvGrilla);
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

            grilla.Columns["Colegio"].Visible = true;
            grilla.Columns["Colegio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Colegio"].HeaderText = @"Colegio";
            grilla.Columns["Colegio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Colegio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ProductoTalle"].Visible = true;
            grilla.Columns["ProductoTalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ProductoTalle"].HeaderText = @"Talle";
            grilla.Columns["ProductoTalle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["ProductoTalle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoPorPedido"].Visible = true;
            grilla.Columns["EstadoPorPedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoPorPedido"].HeaderText = @"Estado";
            grilla.Columns["EstadoPorPedido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstadoPorPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            grilla.Columns["Cliente"].Visible = true;
            grilla.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Cliente"].HeaderText = @"Cliente";
            grilla.Columns["Cliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
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

        private void btnEnEspera_Click(object sender, EventArgs e)
        {
        }

        private void btnTerminado_Click(object sender, EventArgs e)
        {
            if (EntidadId != 0)
            {
                if (producto_Dato_Servicio.ObtenerPorId(EntidadId).EstadoPorPedido != AccesoDatos.EstadoPorPedido.Terminado)
                {
                    if (MessageBox.Show("Esta Por Cambiar El Estado Del Producto, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        producto_Dato_Servicio.CambiarEstadoTerminado(EntidadId);

                        ListaRealizada.Add(producto_Dato_Servicio.ObtenerPorId(EntidadId));
                        dgvGrillaRealizados.DataSource = ListaRealizada.ToList();

                        CargarGrilla();

                        EntidadId = 0;
                    }
                }
            }           
        }

        private void btnCancelado_Click(object sender, EventArgs e)
        {
            if (EntidadId != 0)
            {
                if (producto_Dato_Servicio.ObtenerPorId(EntidadId).EstadoPorPedido != AccesoDatos.EstadoPorPedido.Cancelado)
                {
                    if (MessageBox.Show("Esta Por Cambiar El Estado Del Producto, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        producto_Dato_Servicio.CambiarEstadoCancelado(EntidadId);

                        ListaRealizada.Add(producto_Dato_Servicio.ObtenerPorId(EntidadId));
                        dgvGrillaRealizados.DataSource = ListaRealizada.ToList();

                        CargarGrilla();

                        EntidadId = 0;
                    }
                }
            }            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
        }
    }
}
