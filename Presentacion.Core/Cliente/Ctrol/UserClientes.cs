using Presentacion.Clases;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente.Ctrol
{
    public partial class UserClientes : UserControl
    {
        private readonly IClienteServicio clienteServicio;

        private long Id;

        public UserClientes(long idCliente)
        {
            InitializeComponent();

            clienteServicio = new ClienteServicio();

            Datos(clienteServicio.ObtenerPorId(idCliente));

            Id = idCliente;

        }

        public void Datos(ClienteDto cliente)
        {

            lblApellido.Text = cliente.Apellido;
            lblNombre.Text = cliente.Nombre;
            lblDni.Text = $"Dni: { cliente.Dni}";

            nudId.Value = cliente.Id;

            ckbPrincipal.Checked = cliente.Principal;

            if (ckbPrincipal.Checked == false)
            {
                ckbPrincipal.Visible = false;
            }

            if (cliente.Foto != null)
            {
                pictureBox1.Image = ImagenDb.Convertir_Bytes_Imagen(cliente.Foto);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente_Abm(Clases.TipoOperacion.Modificar, Id);
            cliente.ShowDialog();

            //here
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var historial = new HistorialClientes(Id);
            historial.ShowDialog();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            var cuenta = new CtaCte.CtaCte(Id);
            cuenta.ShowDialog();
        }
    }
}
