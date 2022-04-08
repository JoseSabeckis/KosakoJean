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
    public partial class ImageDatos : Form
    {
        private readonly I_ImageServicio imageServicio;

        string _Palabra;

        public ImageDatos(string palabra)
        {
            InitializeComponent();

            imageServicio = new ImageServicio();

            _Palabra = palabra;
            ImageDescripcion(palabra);
        }

        public void ImageDescripcion(string descripcion)
        {
            switch (descripcion)
            {
                case "Image_Logo_Principal":
                    lblImage.Text = "Image_Logo_Principal";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Logo_Principal);
                    break;
                case "Image_Caja":
                    lblImage.Text = "Image_Caja";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Caja);
                    break;
                case "Image_CtaCte":
                    lblImage.Text = "Image_CtaCte";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_CtaCte);
                    break;
                case "Image_Productos":
                    lblImage.Text = "Image_Productos";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Productos);
                    break;
                case "Image_Clientes":
                    lblImage.Text = "Image_Clientes";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Clientes);
                    break;
                case "Image_Pedido_Guardado":
                    lblImage.Text = "Image_Pedido_Guardado";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedido_Guardado);
                    break;
                case "Image_Para_Hacer":
                    lblImage.Text = "Image_Para_Hacer";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Para_Hacer);
                    break;
                case "Image_Pedidos_Pendientes":
                    lblImage.Text = "Image_Pedidos_Pendientes";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedidos_Pendientes);
                    break;
                case "Image_Cobrar":
                    lblImage.Text = "Image_Cobrar";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Cobrar);
                    break;
                case "Image_Pedido_Venta":
                    lblImage.Text = "Image_Pedido_Venta";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedido_Venta);
                    break;
                case "Image_Info":
                    lblImage.Text = "Image_Info";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Info);
                    break;
                case "Image_Pedidos_Listos":
                    lblImage.Text = "Image_Pedidos_Listos";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedidos_Listos);
                    break;
                case "Image_Esperando":
                    lblImage.Text = "Image_Esperando";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Esperando);
                    break;
                case "Image_Pedidos_Terminados":
                    lblImage.Text = "Image_Pedidos_Terminados";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedidos_Terminados);
                    break;
                case "Image_Fabricar":
                    lblImage.Text = "Image_Fabricar";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Fabricar);
                    break;
                case "Image_Arreglos":
                    lblImage.Text = "Image_Arreglos";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Arreglos);
                    break;
                case "Image_Pedido_Entregado":
                    lblImage.Text = "Image_Pedido_Entregado";
                    imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedido_Entregado);
                    break;
                default:
                    break;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Guardar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var imageDto = new ImageDto
                {
                    Image_Modificada = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image)
                };

                imageServicio.ModificarPorUno(_Palabra, imageDto);

                Close();

            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si se Selecciono un Archivo
                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    imgFotoEmpleado.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
            }

        }
    }
}
