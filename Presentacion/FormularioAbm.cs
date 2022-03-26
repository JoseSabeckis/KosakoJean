using Presentacion.Clases;
using Presentacion.Core.Mensaje;
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
    public partial class FormularioAbm : FormularioBase
    {
        protected TipoOperacion TipoOperacion;
        protected long? EntidadId;

        public bool RealizoAlgunaOperacion { get; set; }

        public FormularioAbm()
        {
            InitializeComponent();
        }

        public FormularioAbm(TipoOperacion tipoOperacion, long? entidadId)
            : this() // => Constructor Principal
        {
            TipoOperacion = tipoOperacion;
            EntidadId = entidadId;

            RealizoAlgunaOperacion = false;
            // Agregar
            //AsignarImagenBotones();
        }

        public virtual void EjecutarComando()
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    if (EjecutarComandoNuevo())
                    {
                        var nuevo = new Afirmacion("Atencion","Datos Guardados \nCorrectamente");
                        nuevo.ShowDialog();
                        Limpiar(this);
                        RealizoAlgunaOperacion = true;
                    }
                    break;
                case TipoOperacion.Eliminar:
                    if (EjecutarComandoEliminar())
                    {
                        var eliminar = new Negativo("Atencion","Datos Eliminados \nCorrectamente");
                        eliminar.ShowDialog();
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
                case TipoOperacion.Modificar:
                    if (EjecutarComandoModificar())
                    {
                        var nuevo = new Afirmacion("Atencion", "Los Datos Se Modificaron \nCorrectamente");
                        nuevo.ShowDialog();
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
            }
        }

        public virtual bool EjecutarComandoModificar()
        {
            return false;
        }

        public virtual bool EjecutarComandoEliminar()
        {
            return false;
        }

        public virtual bool EjecutarComandoNuevo()
        {
            return false;
        }

        public virtual void CargarDatos(long? entidadId)
        {

        }

        public virtual void Inicializador(long? entidadId)
        {

        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta seguro de Limpiar los Datos", @"Atención", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(this);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioAbm_Load(object sender, EventArgs e)
        {
            if (TipoOperacion == TipoOperacion.Eliminar
                || TipoOperacion == TipoOperacion.Modificar)
                CargarDatos(EntidadId);
        }
    }
}
