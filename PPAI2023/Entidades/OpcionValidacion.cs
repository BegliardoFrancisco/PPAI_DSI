using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class OpcionValidacion
    {
        #region Atributos
        bool correcta;
        string descripcion;

        #endregion


        #region Getters/Setters

        public bool getCorrecta() { return this.correcta; }
        public void setCorrecta(bool correcta) {  this.correcta = correcta; }
        public string getDescripcion() {  return this.descripcion; }
        public void setDescrpicion(string descripcion) { this.descripcion = descripcion; }

        #endregion


        #region Constructor
        public OpcionValidacion(bool correcta, string descripcion)
        {
            this.correcta = correcta;   
            this.descripcion= descripcion;
        }
        #endregion


        #region Metodos

        //Método que pregunta a la opcion si es la descripción pasada por parametro
        public bool esSuDescripcion(string descripcionRespuesta)
        {
            return this.descripcion == descripcionRespuesta;
        }

        //Método que pregunta a la opción si es correcta.
        public bool esCorrecta()
        {
            return this.correcta;
        }

        #endregion

    }
}
