using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class Validacion
    {
        #region Atributos

        string nombre;
        string mensajeValidacion;
        int nroOrden;
        List<OpcionValidacion> opcionesValidacion;

        #endregion

        /*Faltarian agregar los seters de las listas pero como no tenemos bd ya fue despues lo hacemos*/
        #region Getters/Setters
        public string getNombre() { return this.nombre; }
        public int getNroOrden() { return this.nroOrden; }
        public string getMensajeValidacion() { return this.mensajeValidacion; }
        public List<OpcionValidacion> getOpcionesValidacion() { return this.opcionesValidacion; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setNroOrden(int nroOrden) { this.nroOrden = nroOrden; }
        public void setMensajeValidacio(string mensajeValidacion) { this.mensajeValidacion = mensajeValidacion; }

        #endregion

        #region Constructor
        public Validacion(string nombre, string mensajeValidacion, int nroOrden)
        {
            this.nombre = nombre;
            this.mensajeValidacion = mensajeValidacion;
            this.nroOrden= nroOrden;
            opcionesValidacion = new List<OpcionValidacion>();
        }
        #endregion


        #region Metodos

        //Método que agrega una opción a la validacion.
        public void agregarOpcionValidacion(OpcionValidacion opcionValidacion) { opcionesValidacion.Add(opcionValidacion); }

        //Método que muestra las opciones de la validación.
        public List<string> mostrarOpciones()
        {
            List<string> opciones = new List<string>();
            foreach(OpcionValidacion opcion in opcionesValidacion) { opciones.Add(opcion.getDescripcion()); }
            return opciones;
        }

        //Método que valida una respuesta con las opciones de la validación
        public bool validarRespuesta(string respuestaCliente)
        {
            foreach(OpcionValidacion opcion in opcionesValidacion) { if (opcion.esSuDescripcion(respuestaCliente)) { return opcion.esCorrecta(); } }
            return false;
        }

        #endregion



    }
}
