using AccesoDatos;
using Servicios.Core.Image.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Image
{
    public class ImageServicio : I_ImageServicio
    {
        public void Insertar(ImageDto imageDto)
        {
            using(var context = new KosakoDBEntities())
            {
                var image = new AccesoDatos.Image
                {
                    Image_Caja = imageDto.Image_Caja,
                    Image_Clientes = imageDto.Image_Clientes,
                    Image_Cobrar = imageDto.Image_Cobrar,
                    Image_CtaCte = imageDto.Image_CtaCte,
                    Image_Para_Hacer = imageDto.Image_Para_Hacer,
                    Image_Pedidos_Listos = imageDto.Image_Pedidos_Listos,
                    Image_Pedidos_Pendientes = imageDto.Image_Pedidos_Pendientes,
                    Image_Pedidos_Terminados = imageDto.Image_Pedidos_Terminados,
                    Image_Pedido_Entregado = imageDto.Image_Pedido_Entregado,
                    Image_Pedido_Guardado = imageDto.Image_Pedido_Guardado,
                    Image_Productos = imageDto.Image_Productos,
                    Image_Logo_Principal = imageDto.Image_Logo_Principal,
                    Image_Arreglos = imageDto.Image_Arreglos,
                    Image_Info = imageDto.Image_Info,
                    Image_Esperando = imageDto.Image_Esperando,
                    Image_Pedido_Venta = imageDto.Image_Pedido_Venta
                };

                context.Images.Add(image);

                context.SaveChanges();
            }
        }

        public AccesoDatos.Image ObtenerPorId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Images.FirstOrDefault(x => x.Id == id);
            }
        }

        public void CargarImagenes()
        {
            var img = ObtenerPorId(1);

            ImageLogueado.Id = img.Id;
            ImageLogueado.Image_Caja = img.Image_Caja;
            ImageLogueado.Image_Clientes = img.Image_Clientes;
            ImageLogueado.Image_Cobrar = img.Image_Cobrar;
            ImageLogueado.Image_CtaCte = img.Image_CtaCte;
            ImageLogueado.Image_Logo_Principal = img.Image_Logo_Principal;
            ImageLogueado.Image_Para_Hacer = img.Image_Para_Hacer;
            ImageLogueado.Image_Pedidos_Listos = img.Image_Pedidos_Listos;
            ImageLogueado.Image_Pedidos_Pendientes = img.Image_Pedidos_Pendientes;
            ImageLogueado.Image_Pedidos_Terminados = img.Image_Pedidos_Terminados;
            ImageLogueado.Image_Pedido_Entregado = img.Image_Pedido_Entregado;
            ImageLogueado.Image_Pedido_Guardado = img.Image_Pedido_Guardado;
            ImageLogueado.Image_Productos = img.Image_Productos;
            ImageLogueado.Image_Arreglos = img.Image_Arreglos;
            ImageLogueado.Image_Info = img.Image_Info;
            ImageLogueado.Image_Pedido_Venta = img.Image_Pedido_Venta;
            ImageLogueado.Image_Esperando = img.Image_Esperando;

        }

        public void Modificar(ImageDto imageDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var img = ObtenerPorId(1);

                img.Image_Caja = imageDto.Image_Caja;
                img.Image_Clientes = imageDto.Image_Clientes;
                img.Image_Cobrar = imageDto.Image_Cobrar;
                img.Image_CtaCte = imageDto.Image_CtaCte;
                img.Image_Para_Hacer = imageDto.Image_Para_Hacer;
                img.Image_Pedidos_Listos = imageDto.Image_Pedidos_Listos;
                img.Image_Pedidos_Pendientes = imageDto.Image_Pedidos_Pendientes;
                img.Image_Pedidos_Terminados = imageDto.Image_Pedidos_Terminados;
                img.Image_Pedido_Entregado = imageDto.Image_Pedido_Entregado;
                img.Image_Pedido_Guardado = imageDto.Image_Pedido_Guardado;
                img.Image_Productos = imageDto.Image_Productos;
                img.Image_Logo_Principal = imageDto.Image_Logo_Principal;
                img.Image_Arreglos = imageDto.Image_Arreglos;
                img.Image_Info = imageDto.Image_Info;
                img.Image_Esperando = imageDto.Image_Esperando;
                img.Image_Pedido_Venta = imageDto.Image_Pedido_Venta;

                context.SaveChanges();
            }
        }

    }
}
