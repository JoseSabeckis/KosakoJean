using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Image.Dto
{
    public class ImageDto
    {
        public long Id { get; set; }

        public byte[] Image_Pedidos_Terminados { get; set; }

        public byte[] Image_Pedidos_Pendientes { get; set; }

        public byte[] Image_Pedidos_Listos { get; set; }

        public byte[] Image_Pedido_Guardado { get; set; }

        public byte[] Image_Pedido_Entregado { get; set; }

        public byte[] Image_Para_Hacer { get; set; }

        public byte[] Image_Productos { get; set; }

        public byte[] Image_Clientes { get; set; }

        public byte[] Image_Cobrar { get; set; }

        public byte[] Image_CtaCte { get; set; }

        public byte[] Image_Caja { get; set; }

        public byte[] Image_Logo_Principal { get; set; }

        public byte[] Image_Arreglos { get; set; }

        public byte[] Image_Pedido_Venta { get; set; }

        public byte[] Image_Info { get; set; }

        public byte[] Image_Esperando { get; set; }

        public byte[] Image_Fabricar { get; set; }

    }
}
