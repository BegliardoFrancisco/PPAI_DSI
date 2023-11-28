using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class SubOpcionLlamada
    {
        #region Atributos


        string nombre;
        int nroOrden;
        List<Validacion> validacionesRequeridas;

        #endregion

        #region Getters/Setters
        public string getNombre() { return this.nombre; }
        public int getNroOrden() { return this.nroOrden; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setNroOrden(int nroOrden) { this.nroOrden = nroOrden; }
        public List<Validacion> getValidaciones() { return this.validacionesRequeridas; }

        #endregion


        #region Constructor
        public SubOpcionLlamada(string nombre, int nroOrden)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.validacionesRequeridas = new List<Validacion>();

        }
        #endregion


        #region Metodos

        //Método que agrega una validacìón a la subopción
        public void agregarValidacion(Validacion validacionRequerida) { validacionesRequeridas.Add(validacionRequerida); }

        #endregion

    }
}
