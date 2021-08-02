using Servicios.Core.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class VerClientes : Form
    {
        private readonly IClienteServicio clienteServicio;

        public VerClientes()
        {
            InitializeComponent();

            clienteServicio = new ClienteServicio();

            CrearControles();

        }

        private void CrearControles()
        {
            var cuadros = clienteServicio.Buscar(string.Empty);

            foreach (var item in cuadros)
            {
                var cuadro = item;

                var control = new Ctrol.UserClientes(cuadro.Id);

                pnlPrincipal.Controls.Add(control);

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                MessageBox.Show("Complete el Campo de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            pnlPrincipal.Controls.Clear();

            var cuadros = clienteServicio.Buscar(txtBusqueda.Text);

            if (cuadros.Count() == 0)
            {
                MessageBox.Show("No Se Encontraron Resultados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CrearControles();
                return;
            }

            foreach (var item in cuadros)
            {
                var cuadro = item;

                var control = new Ctrol.UserClientes(cuadro.Id);

                pnlPrincipal.Controls.Add(control);

            }

        }

        public void Flow()
        {
            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBusqueda.Text))
                {
                    btnBuscar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Complete el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
    }
}
