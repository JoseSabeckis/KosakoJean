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

namespace Presentacion.Core.CtaCte
{
    public partial class CtaCte : Form
    {
        private readonly IClienteServicio _clienteServicio;

        long _ClienteId;

        public CtaCte(long clienteId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();

            _ClienteId = clienteId;

        }



    }
}
