﻿using System;
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
    public partial class Afirmacion : Form
    {
        public Afirmacion(string titulo, string parrafo)
        {
            InitializeComponent();

            lblTitulo.Text = titulo;
            lblParrafo.Text = parrafo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}