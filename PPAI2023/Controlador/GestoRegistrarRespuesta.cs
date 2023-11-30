using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI2023.Entidades;
using PPAI2023.Pantalla;

namespace PPAI2023.Controlador  
{
    public class GestorRegistrarRespuesta
    {
        #region Atributos
        public DateTime fechaHora;
        public string descripcionRespuesta;
        public string descripcionAccionSeleccionada;
        public List<EstadoLlamada> estados;
        public List<Accion> acciones;
        public Llamada llamadaActual;
        public CategoriaLlamada categoriaSeleccionada;
        public OpcionLlamada opcionSeleccionada;
        public SubOpcionLlamada subOpcionSeleccionada;
        public List<Validacion> validacionesSubOpcion;
        public Validacion validacionActual;
        public EstadoLlamada estado;
        public int nroValidacion = 0;
        PantallaLlamada pantallaLlamada;

        #endregion

        #region Constructor
        public GestorRegistrarRespuesta(PantallaLlamada pantallaLlamada) {
            estados = new List<EstadoLlamada>();
            acciones = new List<Accion>();
            validacionesSubOpcion = new List<Validacion>();
            this.pantallaLlamada = pantallaLlamada;
        }
        #endregion

        #region Metodos
        //Metodos de carga de datos
        public void setEstado(EstadoLlamada estado) { this.estado = estado; }
        public void obtenerLlamada(Llamada llamada) { this.llamadaActual = llamada; }
        public void agregarAcciones( Accion accion) { this.acciones.Add(accion); }
        public void agregarEstados(EstadoLlamada estado) { this.estados.Add(estado); }
        public void agregarCategoria(CategoriaLlamada categoria) { this.categoriaSeleccionada =  categoria; }
        public void agregarOpcion(OpcionLlamada opcion) { this.opcionSeleccionada = opcion; }
        public void agregarSubOpcion(SubOpcionLlamada subOpcion) { this.subOpcionSeleccionada = subOpcion;  }


        //Método que dispara la opcion de la llamada operador
        public void opcionLlamadaOperador(Llamada llamada) {obtenerLlamada(llamada); pantallaLlamada.mostrarDatosLlamada(); corroborarDatosCliente(); }

        //Método que busca el estado en curso.
        private void buscarEstadoEnCurso()

        {   foreach (EstadoLlamada estado in estados)
            {
                if (estado.esEnCurso()) {
                    setEstado(estado)  ;
                }
            }
        }
        //Método que obtiene la fecha y hora actual
        private void obtenerFechaHoraActual() { fechaHora = DateTime.Now; }

        //Metodo que cambia el estado de la llamada a En Curso
        private void llamadaAEnCurso()
        {
            obtenerFechaHoraActual();
            llamadaActual.cambiarEstado(estado, fechaHora);
        }

        //Método que busca el estado finalizada.
        /*private void buscarEstadoFinalizada()
        {
            foreach (Estado estado in estados)
            {
                if (estado.esFinalizada()) { setEstado(estado); }
            }
        }*/

        //Método que cambia el estado de la llamada a finalizada.
        /*private void cambiarLlamadaAFinalizada()
        {
            llamadaActual.cambiarEstado(estado, fechaHora);
        }*/

        //Método que obtiene los datos de la llamada iniciada.
        public List<string> obtenerDatosLlamada()
        {
            buscarEstadoEnCurso();
            llamadaAEnCurso();
            buscarValidacionesSubOpcion();
            List<string> datosLlamada = new List<string>();

            datosLlamada.Add(llamadaActual.getNombreClienteLlamada());
            datosLlamada.Add(categoriaSeleccionada.getNombre());
            datosLlamada.Add(opcionSeleccionada.getNombre());
            datosLlamada.Add(subOpcionSeleccionada.getNombre());



            return datosLlamada;

        }

        //Método que obtiene las validaciones de la subopción de la llamada iniciada
        private void buscarValidacionesSubOpcion()
        {
            validacionesSubOpcion = subOpcionSeleccionada.getValidaciones();
        }

        //Método que muestra las validaciones y dispara la validacion del cliente
        public void corroborarDatosCliente()
        {
            if (nroValidacion < validacionesSubOpcion.Count()) { pantallaLlamada.mostrarValidacion(validacionesSubOpcion[nroValidacion].getMensajeValidacion(), validacionesSubOpcion[nroValidacion].mostrarOpciones()); }
            else { 
                pantallaLlamada.habilitarValidacionExitosa(); 
                pantallaLlamada.solicitarDescripcionRespuesta(); }
        }

        //Método que obtiene las descripciones de las acciones.
        public List<string> buscarAcciones()
        {
            List<string> descripcionAcciones = new List<string>();
            foreach(Accion accion in acciones) { descripcionAcciones.Add(accion.getDescripcion()); }
            return descripcionAcciones;
        }

        //Método que toma la respuesta del cliente, y la valida
        public void tomarRespuestaCliente(string opcionClienteSeleccionada)
        {
            if (validacionesSubOpcion[nroValidacion].validarRespuesta(opcionClienteSeleccionada)) 
            {
                nroValidacion += 1;

            }else
            {
                pantallaLlamada.finalizarLlamadaInvalida();
            }
        }

        //Método que guarda la descripción de la respuesta del operador.
        public void tomarDescripcionRespuesta(string descripcionRespuesta)
        {
            this.descripcionRespuesta = descripcionRespuesta;
            pantallaLlamada.solicitarAccionARealizar();
        }

        //Método que guarda la selección de la acción a realizar.
        public void tomarSeleccionAccion(string descripcionAccion)
        {
            this.descripcionAccionSeleccionada = descripcionAccion;
            pantallaLlamada.solicitarConfirmacionOperacion();
           
        }

        //Método que realiza la acción solicitada, llamando al caso de uso nº28
        private void realizarAccionSolicitada()
        {
            Random rnd = new Random();
            double nro = Math.Round(rnd.NextDouble(), 2);
            pantallaLlamada.informarSituacion(nro);
        }

        //Método que finaliza la llamada registrando todos sus datos.
        public void finalizarLlamada()
        {
            llamadaActual.setDescripcionOperador(descripcionRespuesta);
            llamadaActual.setOpcion(opcionSeleccionada);
            llamadaActual.setSubOpcion(subOpcionSeleccionada);
            obtenerFechaHoraActual();
            calcularDuracionLlamada(fechaHora);



            llamadaActual.FinalizarLlamada(fechaHora);

            //Actualiza llamada datos 
            Llamadas.Update(llamadaActual);

            //buscarEstadoFinalizada();
            //cambiarLlamadaAFinalizada();
        }

        //Método que calcula la duracion de la llamada y la setea.
        private void calcularDuracionLlamada(DateTime fechaHoraFinalizada)
        {
            double duracion =  llamadaActual.calcularDuracion(fechaHoraFinalizada);
            llamadaActual.setDuracion(duracion);
        }

        //Método que toma la confirmación de la operación.
        public void tomarConfirmacionOperacion() {realizarAccionSolicitada();}
        #endregion
    }
}
