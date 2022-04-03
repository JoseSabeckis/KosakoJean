using Presentacion.Clases;
using Servicios.Core.Cliente;
using Servicios.Core.Image.Dto;
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

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgCliente.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Clientes);
        }

        public void CrearControles()
        {
            var cuadros = clienteServicio.Buscar(string.Empty);

            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };

            foreach (var item in cuadros)
            {
                var cuadro = item;

                var control = new Ctrol.UserClientes(cuadro.Id);

                flowPanel.Controls.Add(control);

            }

            pnlPrincipal.Controls.Add(flowPanel);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            pnlPrincipal.Controls.Clear();

            var cuadros = clienteServicio.Buscar(txtBusqueda.Text);

            if (cuadros.Count() == 0)
            {
                MessageBox.Show("No Se Encontraron Resultados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CrearControles();
                return;
            }

            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };

            foreach (var item in cuadros)
            {
                var cuadro = item;

                var control = new Ctrol.UserClientes(cuadro.Id);

                flowPanel.Controls.Add(control);

            }

            pnlPrincipal.Controls.Add(flowPanel);

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var nuevo = new Cliente_Abm(Clases.TipoOperacion.Nuevo);
            nuevo.ShowDialog();
          
            pnlPrincipal.Controls.Clear();

            CrearControles();
           
        }

        public void LimpiarPanel()
        {
            pnlPrincipal.Controls.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
