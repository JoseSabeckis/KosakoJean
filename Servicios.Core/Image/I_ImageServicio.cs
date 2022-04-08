using Servicios.Core.Image.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Image
{
    public interface I_ImageServicio
    {
        void Insertar(ImageDto imageDto);//se usa una sola vez
        AccesoDatos.Image ObtenerPorId(long id);
        ImageDto ObtenerPorIdDto(long id);
        void CargarImagenes();

        void Modificar(ImageDto imageDto);
    }
}
