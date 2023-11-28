using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class Accion
    {
        #region Atributos

        string descripcion;

        #endregion


        #region Getters/Setters

        public string getDescripcion() { return descripcion; }
        public void setDescripcion(string descripcion) { this.descripcion = descripcion; }

        #endregion


        #region Constructor
        public Accion(string descripcion) 
        {
            this.descripcion = descripcion;
        }
        #endregion


        #region Metodos
        #endregion

    }
}
