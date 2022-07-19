namespace Servicios.Core.Producto.Dto
{
    public class ProductoDto
    {
        public long Id { get; set; }

        public long CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public bool EstaEliminado { get; set; }

        public string Extras { get; set; }

        public long ColegioId { get; set; }

        public string Colegio { get; set; }

        public long TipoProductoId { get; set; }

        public string TipoProducto { get; set; }

        public decimal Stock { get; set; }

        public decimal Precio { get; set; }

        public string PrecioString => Precio.ToString("00.00");

        public bool Creacion { get; set; }

        public byte[] Foto { get; set; }

        public byte[] ImagenCodBarra { get; set; }

        public string CodigoBarraVerdadero { get; set; }

        public bool CodCreado { get; set; }
    }
}
