using AccesoDatos;
using Servicios.Core.Caja;
using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class AbrirCaja : Form
    {
        private readonly ICajaServicio _cajaServicio;

        public AbrirCaja()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta por abrir la caja, Seguro?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var caja = new CajaDto
                {
                    FechaApertura = DateTime.Now,
                    MontoApertura = nudDinero.Value,
                    OpenClose = OpenClose.Abierto,
                    MontoCierre = 0,
                    FechaCierre = DateTime.Now,
                    TotalCaja = nudDinero.Value
                };

                _cajaServicio.AbrirCaja(caja);

                this.Close();
            }
        }
    }
}
