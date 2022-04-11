using System;
using System.Windows.Forms;

namespace Presentacion.Core.Mensaje
{
    public partial class Negativo : Form
    {
        public Negativo(string titulo, string parrafo)
        {
            InitializeComponent();

            lblTitulo.Text = titulo;
            txtParrafo.Text = parrafo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
