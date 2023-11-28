using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class Cliente
    {
        #region Atributos
        int dni;
        string nombreCompleto;
        long nroCelular;

        #endregion


        #region Getters/Setters

        public int getDni (){ return this.dni; }
        public string getNombreCompleto() { return this.nombreCompleto; }
        public long getNroCelular() {  return this.nroCelular; }
        public void setDni(int dni) {  this.dni = dni; }
        public void setNombreCompleto(string nombre) { this.nombreCompleto = nombre;}
        public void setNroCelular(int nro) { this.nroCelular = nro;}

        #endregion


        #region Constructor
        public Cliente(int dni, string nombreCompleto, long nroCelular)
        {
            this.dni = dni;
            this.nombreCompleto= nombreCompleto;
            this.nroCelular= nroCelular;
        }

        #endregion


        #region Metodos
        #endregion

    }
}
