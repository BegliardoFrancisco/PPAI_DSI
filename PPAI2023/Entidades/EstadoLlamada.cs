using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public abstract class EstadoLlamada
    {
        #region Atributos
        string nombre;
        #endregion


        #region Getters/Setters
        public string getNombre() { return nombre; }
        public void setNombre(string nombreEstado) { nombre = nombreEstado; }

        #endregion


        #region Constructor

        public EstadoLlamada(string nombre) { this.nombre = nombre; }
        #endregion


        #region Metodos

        //Metodo polimorfico// CORRECCION! No es polimórfico 
        public abstract void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado);
  
        public bool esEnCurso()
        {
            return this.nombre == "EnCurso";
        }

        public bool esFinalizada()
        {
            return this.nombre == "EsFinalizada";
        }
        #endregion
    }
}
