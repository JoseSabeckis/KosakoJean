using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Image.Dto
{
    public static class ImageLogueado
    {
        public static long Id { get; set; }

        public static byte[] Image_Pedidos_Terminados { get; set; }
        public static byte[] Image_Pedidos_Pendientes { get; set; }
        public static byte[] Image_Pedidos_Listos { get; set; }
        public static byte[] Image_Pedido_Guardado { get; set; }
        public static byte[] Image_Pedido_Entregado { get; set; }
        public static byte[] Image_Para_Hacer { get; set; }
        public static byte[] Image_Productos { get; set; }
        public static byte[] Image_Clientes { get; set; }
        public static byte[] Image_Cobrar { get; set; }
        public static byte[] Image_CtaCte { get; set; }
        public static byte[] Image_Caja { get; set; }
        public static byte[] Image_Logo_Principal { get; set; }
        public static byte[] Image_Arreglos { get; set; }
        public static byte[] Image_Pedido_Venta { get; set; }
        public static byte[] Image_Esperando { get; set; }
        public static byte[] Image_Info { get; set; }
    }
}
