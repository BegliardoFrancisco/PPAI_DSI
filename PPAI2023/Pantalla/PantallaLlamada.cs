using PPAI2023.Controlador;
using PPAI2023.RepositorioDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI2023.Pantalla
{
    public partial class PantallaLlamada : Form
    {
        #region Atributos
        ValidacionCorrecta pantallaValidacionCorrecta = new ValidacionCorrecta();
        GestorRegistrarRespuesta gestor;
        BaseDatos baseDeDatos;
        #endregion

        #region Constructor
        public PantallaLlamada()
        {
            InitializeComponent();

            //Inicializamos el gestor
            gestor = new GestorRegistrarRespuesta(this);

            //Inicializamos la base de datos para poder inicializar los datos
            baseDeDatos = new BaseDatos(gestor);


        }
        #endregion

        #region Eventos
        private void btnValidar_Click(object sender, EventArgs e) { if (validarComboValidaciones()) { tomarRespuestaCliente(); } else { MessageBox.Show("Elija una opción para validar..."); }  }

        private void btnEnviarDescripcion_Click(object sender, EventArgs e) { if (validarDescripcionRespuesta()) { tomarDescripcionRespuesta(); } else { MessageBox.Show("Rellene el campo antes de continuar"); } ; }


        private void btnAceptarAccion_Click(object sender, EventArgs e) { if (MessageBox.Show("¿Estas seguro de la elección?", "Confimar elección", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { tomarSeleccionAccion(); } }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirmar acción a realizar?", "Confimar operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { tomarConfirmacionOperacion(); }
        }

        private void cmbAcciones_MouseClick(object sender, MouseEventArgs e)
        {
            btnAceptarAccion.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToString("T");
        }

        private void btnFinalizarLlamada_Click(object sender, EventArgs e)
        {
            gestor.finalizarLlamada();
            this.Close();
        }

        private void PantallaLlamada_Load(object sender, EventArgs e)
        {
            gpDescripcionRespuesta.Visible = false;
            gbAccion.Visible = false;
            btnConfirmar.Visible = false;
            baseDeDatos.inicializarDatos();
            timer1.Enabled = true;
        }

        #endregion

        #region Métodos

        //Método que muestra los datos de la llamada en pantalla
        public void mostrarDatosLlamada()
        {
            List<string> datos = gestor.obtenerDatosLlamada();
            txtNombreCliente.Text = datos[0].ToString();
            txtCategoria.Text = datos[1].ToString();
            txtOpcion.Text = datos[2].ToString();
            txtSubOpcion.Text = datos[3].ToString();
        }

        //Método que abre una ventana de validación correta
        public void habilitarValidacionExitosa()
        {
            pantallaValidacionCorrecta.ShowDialog();
        }

        //Método que muestra la validación y sus opciones
        public void mostrarValidacion(string mensajeValidacion, List<string> opcionesValidacion)
        {
            lblMensajeValidacion.Text = mensajeValidacion.ToString();
            cmbOpcionesValidacion.Items.Clear();
            foreach (string opcion in opcionesValidacion)
            {
                cmbOpcionesValidacion.Items.Add(opcion);
            }

        }

        //Método que valida la selección del  combo de las opciones de validacion
        public bool validarComboValidaciones()
        {
            if (cmbOpcionesValidacion.SelectedIndex == -1) { return false; } return true; 
        }

        //Método que valida el textbox de la descripción de la respuesta
        public bool validarDescripcionRespuesta()
        {
            if (txtBoxDescripcionRespuesta.Text == "") { return false; }
            return true;
        }

        //Método que toma la opción de la validacion seleccionada por el operador
        public void tomarRespuestaCliente()
        {
            string opcionSeleccionada = cmbOpcionesValidacion.SelectedItem.ToString();
            gestor.tomarRespuestaCliente(opcionSeleccionada);
            gestor.corroborarDatosCliente();

        }

        //Método que habilita el textbox de la descripción de la respuesta
        public void solicitarDescripcionRespuesta()
        {
            gbDatosLlamada.Visible = false;
            gbValidaciones.Visible = false;
            gpDescripcionRespuesta.Visible = true;
            gbAccion.Visible = true;
            gbAccion.Enabled = false;
            btnConfirmar.Visible = true;
            btnConfirmar.Enabled = false;

        }

        //Método que solicita la selección de la acción al operdor
        public void solicitarAccionARealizar()
        {
            gpDescripcionRespuesta.Enabled = false;
            gbAccion.Enabled = true;
            List<string> acciones = gestor.buscarAcciones();
            foreach(string accion in acciones)
            {
                cmbAcciones.Items.Add(accion);
            }
        }

        //Método que toma la selección de la acción
        private void tomarSeleccionAccion()
        {
            string descripcionAccion = cmbAcciones.SelectedItem.ToString();
            gestor.tomarSeleccionAccion(descripcionAccion);
        }

        //Método que toma la descripción de la respuesta
        private void tomarDescripcionRespuesta()
        {
            string descripcionRespuesta = txtBoxDescripcionRespuesta.Text;
            gestor.tomarDescripcionRespuesta(descripcionRespuesta);
        }

        //Método que advierte la opción incorrecta y finaliza la llamada
        public void finalizarLlamadaInvalida()
        {
            MessageBox.Show("Validación incorrecta. Finalizando llamada...", "Opción incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            this.Close();
        }

        //Método que habilita el boton de confirmacion y solicita la misma
        public void solicitarConfirmacionOperacion()
        {
            cmbAcciones.Enabled = false;
            btnAceptarAccion.Enabled = false;
            btnConfirmar.Visible = true;
            btnConfirmar.Enabled = true;
        }

        //Método que toma la confirmación de la respuesta
        public void tomarConfirmacionOperacion()
        {
            btnConfirmar.Enabled = false;
            gestor.tomarConfirmacionOperacion();
        }

        //Método que informa la situación del CU28 y lo muestra en ventana
        public void informarSituacion(double nro)
        {
            frmSituacionAccion frmAccion = new frmSituacionAccion(nro);
            frmAccion.ShowDialog();

        }
        #endregion
    }
}
