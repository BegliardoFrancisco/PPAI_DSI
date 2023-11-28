using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class CategoriaLlamada
    {
        #region Atributos

        string nombre;
        int nroOrden;
        List<OpcionLlamada> opcionesCategoria;

        #endregion


        #region Getters/Setters
        public string getNombre() { return this.nombre; }
        public int getNroOrden() {  return this.nroOrden; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setNroOrden(int nroOrden) { this.nroOrden = nroOrden; }
        public List<OpcionLlamada> getOpcionesCategoria() { return opcionesCategoria;}

        #endregion


        #region Constructor
        public CategoriaLlamada(string nombre, int nroOrden)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.opcionesCategoria = new List<OpcionLlamada>();

        }
        #endregion


        #region Metodos

        public void agregarOpcion(OpcionLlamada opcion) { opcionesCategoria.Add(opcion); }
        #endregion

    }
}
