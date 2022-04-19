using Presentacion.Clases;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.Image.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var cuadros = clienteServicio.Buscar(string.Empty);

            CrearControles(cuadros);

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgCliente.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Clientes);
        }

        public void CrearControles(IEnumerable<ClienteDto> list)
        {           
            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };

            foreach (var item in list)
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

                //CrearControles();
                return;
            }

            CrearControles(cuadros);

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
                btnBuscar.PerformClick();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var nuevo = new Cliente_Abm(Clases.TipoOperacion.Nuevo);
            nuevo.ShowDialog();

            pnlPrincipal.Controls.Clear();

            var cuadros = clienteServicio.Buscar(string.Empty);

            CrearControles(cuadros);

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
