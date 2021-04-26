using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected long? EntidadId;
        protected bool PuedeEjecutarComando;
        protected object EntidadSeleccionada;

        public FormularioConsulta()
        {
            InitializeComponent();

            txtBuscar.Enter += Control_Enter;
            txtBuscar.Leave += Control_Leave;

            EntidadId = null;
            PuedeEjecutarComando = false;

            AsignarEventoEnterLeave(this);

            dgvGrilla.Font = new Font("Century Gothic", 10);
        }

        private bool HayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }


        public virtual void EjecutarNuevo()
        {

        }

        public virtual void EjecutarEliminar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"Por favor seleccione un registro.");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show(@"No hay Datos cargados");
            }
        }


        public virtual void EjecutarModificar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"Por favor seleccione un registro.");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show(@"No hay Datos cargados");
            }
        }

        public virtual void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {

        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatosCargados())
            {

                EntidadId = (int)(long?)dgvGrilla["Id", e.RowIndex].Value;
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadId = null;
                EntidadSeleccionada = null;
            }
        }

        public virtual void EjecutarLoadFormulario()
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        // =========================================================== //

        public virtual void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarNuevo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EjecutarEliminar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EjecutarModificar();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }

        private void FormularioConsulta_Load(object sender, EventArgs e)
        {
            EjecutarLoadFormulario();
            FormatearGrilla(dgvGrilla);
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }
    }
}
