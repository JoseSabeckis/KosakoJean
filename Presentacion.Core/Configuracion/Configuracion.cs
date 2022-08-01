using Servicios.Core.Configuracion;
using Servicios.Core.Configuracion.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Configuracion
{
    public partial class Configuracion : FormularioBase
    {
        private readonly IConfiguracionServicio configuracionServicio;

        long ConfigId;

        public Configuracion()
        {
            InitializeComponent();

            configuracionServicio = new ConfiguracionServicio();

            VerDatos();
        }

        private void VerDatos()
        {
            var config = configuracionServicio.ObtenerPorId(1);

            ConfigId = config.Id;

            ckbUsarLogin.Checked = config.UsarLogin;

            ckbUsarDatos.Checked = config.MostrarDatos;

            ckbUsarTIketera.Checked = config.UsarTicketera;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var config = new ConfiguracionDto
            {
                Id = ConfigId,
                MostrarDatos = ckbUsarDatos.Checked,
                UsarLogin = ckbUsarLogin.Checked,
                UsarTicketera = ckbUsarTIketera.Checked
            };

            configuracionServicio.Modificar(config);

            var mensaje = new Mensaje.Afirmacion("Datos Guardados", "Listo!");
            mensaje.ShowDialog();

            Close();
        }
    }
}
