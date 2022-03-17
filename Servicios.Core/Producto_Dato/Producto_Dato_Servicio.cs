using AccesoDatos;
using Servicios.Core.Producto_Dato.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Dato
{
    public class Producto_Dato_Servicio : IProducto_Dato_Servicio
    {
        public void Insertar(Producto_Dato_Dto _Dto)
        {
            using(var context = new KosakoDBEntities())
            {
                var dato = new AccesoDatos.Producto_Dato
                {
                    Producto_PedidoId = _Dto.Producto_PedidoId,
                    EstadoPorPedido = _Dto.EstadoPorPedido,
                };

                context.Producto_Datos.Add(dato);

                context.SaveChanges();
            }
        }

        public void CambiarEstadoTerminado(long id)
        {
            using(var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Producto_PedidoId == id);

                dato.EstadoPorPedido = EstadoPorPedido.Terminado;

                context.SaveChanges();
            }
        }

        public void CambiarEstadoEnEspera(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Producto_PedidoId == id);

                dato.EstadoPorPedido = EstadoPorPedido.EnEspera;

                context.SaveChanges();
            }
        }

        public void CambiarEstadoCancelado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Producto_PedidoId == id);

                dato.EstadoPorPedido = EstadoPorPedido.Cancelado;

                context.SaveChanges();
            }
        }

    }
}
