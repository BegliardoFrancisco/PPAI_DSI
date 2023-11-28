using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class Estado
    {
        #region Atributos
        string nombre;
        #endregion


        #region Getters/Setters
        public string getNombre() { return nombre; }
        public void setNombre(string nombreEstado) { nombre = nombreEstado; }

        #endregion


        #region Constructor

        public Estado(string nombre) { this.nombre = nombre; }
        #endregion


        #region Metodos

        public bool esEnCurso()
        {
            return this.nombre == "En Curso";
        }

        /*public bool esFinalizada()
        {
            return this.nombre == "En Curso";
        }*/
        #endregion

    }
}
