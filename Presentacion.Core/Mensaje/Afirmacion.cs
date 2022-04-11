using System;
using System.Windows.Forms;

namespace Presentacion.Core.Mensaje
{
    public partial class Afirmacion : Form
    {
        public Afirmacion(string titulo, string parrafo)
        {
            InitializeComponent();

            lblTitulo.Text = titulo;
            txtParrafo.Text = parrafo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
