﻿using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente.Ctrol
{
    public partial class UserClientes : UserControl
    {
        private readonly IClienteServicio clienteServicio;

        public UserClientes(long idCliente)
        {
            InitializeComponent();

            clienteServicio = new ClienteServicio();

            Datos(clienteServicio.ObtenerPorId(idCliente));

        }

        public void Datos(ClienteDto cliente)
        {

            lblApellido.Text = cliente.Apellido;
            lblNombre.Text = cliente.Nombre;

            nudId.Value = cliente.Id;

        }


    }
}