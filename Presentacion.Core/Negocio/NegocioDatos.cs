﻿using Presentacion.Clases;
using Servicios.Core.Negocio.Dto;
using System;

namespace Presentacion.Core.Negocio
{
    public partial class NegocioDatos : FormularioBase
    {
        public NegocioDatos()
        {
            InitializeComponent();

            VerDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var negocio = new Negocio_Abm(Clases.TipoOperacion.Modificar, NegocioLogeado.Id);
            negocio.ShowDialog();

            VerDatos();
        }

        private void VerDatos()
        {
            txtRazonSocial.Text = NegocioLogeado.RazonSocial;
            txtCuit.Text = NegocioLogeado.Cuit;
            txtCelular.Text = NegocioLogeado.Celular;
            txtDireccion.Text = NegocioLogeado.Direccion;
            txtEmail.Text = NegocioLogeado.Email;
            pictureImagen.Image = ImagenDb.Convertir_Bytes_Imagen(NegocioLogeado.Imagen);
        }
    }
}
