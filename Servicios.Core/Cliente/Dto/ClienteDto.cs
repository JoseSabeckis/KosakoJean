namespace Servicios.Core.Cliente.Dto
{
    public class ClienteDto
    {
        public long Id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public bool EstaEliminado { get; set; }

        public byte[] Foto { get; set; }

        public bool Principal { get; set; }
    }
}
