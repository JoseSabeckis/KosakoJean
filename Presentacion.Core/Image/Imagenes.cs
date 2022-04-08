using Presentacion.Clases;
using Servicios.Core.Image;
using Servicios.Core.Image.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
