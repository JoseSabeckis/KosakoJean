using Presentacion.Clases;
using Servicios.Core.Image;
using Servicios.Core.Image.Dto;
using System;

namespace Presentacion.Core.Image
{
    public partial class Imagenes : FormularioBase
    {
        private readonly I_ImageServicio imagenServicio;

        ImageDto _ImageDto;

        public Imagenes()
        {
            InitializeComponent();

            imagenServicio = new ImageServicio();

            CargarImagenDto();
        }

        public void CargarImagenDto()
        {
            _ImageDto = imagenServicio.ObtenerPorIdDto(1);

            MostrarImagenes();
        }

        private void MostrarImagenes()
        {
            imgCaja.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Caja);
            imgClientes.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Clientes);
            imgCobro.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Cobrar);
            imgCtaCte.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_CtaCte);
            imgFabricar.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Fabricar);
            imgGuardado.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedido_Guardado);
            imgParaHacer.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Para_Hacer);
            imgPendientes.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedidos_Pendientes);
            imgPrincipal.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Logo_Principal);
            imgProductos.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Productos);
            imgVentaPedido.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedido_Venta);
            imgInfo.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Info);
            imgEntregados.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedido_Entregado);
            imgArreglos.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Arreglos);
            imgTerminados.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedidos_Terminados);
            imgEsperandoClientes.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Esperando);
            imgListos.Image = ImagenDb.Convertir_Bytes_Imagen(_ImageDto.Image_Pedidos_Listos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Image_Logo_Principal_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Logo_Principal");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Caja_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Caja");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_CtaCte_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_CtaCte");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Productos_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Productos");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Clientes_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Clientes");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedido_Guardado_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedido_Guardado");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Para_Hacer_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Para_Hacer");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedidos_Pendientes_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedidos_Pendientes");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Cobrar_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Cobrar");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedido_Venta_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedido_Venta");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Info_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Info");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedidos_Listos_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedidos_Listos");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Esperando_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Esperando");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedidos_Terminados_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedidos_Terminados");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Fabricar_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Fabricar");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Arreglos_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Arreglos");
            img.ShowDialog();

            CargarImagenDto();
        }

        private void Image_Pedido_Entregado_Click(object sender, EventArgs e)
        {
            var img = new ImageDatos("Image_Pedido_Entregado");
            img.ShowDialog();

            CargarImagenDto();
        }
    }
}
