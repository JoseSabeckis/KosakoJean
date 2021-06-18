using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Clases
{
    public static class ImagenDb
    {
        /// <summary>
        /// Metodo para convertir una imagen en byte
        /// </summary>
        /// <param name="img">Imagen</param>
        /// <returns></returns>
        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        /// <summary>
        /// Metodo para convertir byte en Imagen
        /// </summary>
        /// <param name="bytes">Byte</param>
        /// <returns></returns>
        public static Image Convertir_Bytes_Imagen(byte[] bytes)
        {
            if (bytes == null) return null;

            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }
    }
}
