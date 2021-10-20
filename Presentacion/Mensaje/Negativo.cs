using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
