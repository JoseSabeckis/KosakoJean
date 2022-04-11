using Servicios.Core.Image.Dto;

namespace Servicios.Core.Image
{
    public interface I_ImageServicio
    {
        void Insertar(ImageDto imageDto);//se usa una sola vez
        AccesoDatos.Image ObtenerPorId(long id);
        ImageDto ObtenerPorIdDto(long id);
        void ModificarPorUno(string descripcion, ImageDto imageDto);
        void CargarImagenes();

        void Modificar(ImageDto imageDto);
    }
}
