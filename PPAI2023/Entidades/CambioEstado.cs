using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI2023.Entidades
{
    public class CambioEstado
    {
        #region Atributos
        public int id { get; set; }
        DateTime fechaHoraInicio;
        DateTime? fechaHoraFin;
        EstadoLlamada estado;

        #endregion

        #region Getters/Setters

        public DateTime getFechaHoraInicio() {  return fechaHoraInicio; }
        public void setFechaHoraInicio(DateTime fechaHora) { this.fechaHoraInicio = fechaHora; }
        public DateTime? getFechaHoraFin() { return fechaHoraFin; }
        public void setFechaHoraFin(DateTime fechaHora) { this.fechaHoraFin = fechaHora; }
        public EstadoLlamada getEstado() {  return estado; }
        public void setEstado(EstadoLlamada estado) { this.estado = estado; }

        #endregion


        #region Constructor
        public CambioEstado(int id ,DateTime fechaHoraInicio, EstadoLlamada estado)
        {
            this.id = id;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = null;
            this.estado = estado;
        }
        public CambioEstado(DateTime fechaHoraInicio, EstadoLlamada estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = null;
            this.estado = estado;
        }

        public CambioEstado(DateTime fechaHoraInicio, DateTime fechaHoraFin, EstadoLlamada estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.estado = estado;
        }


        #endregion


        #region Metodos

        //Método que pregunta al cambio de estado si es el último de la llamada.
        public bool esUltimo() { return (this.fechaHoraFin == null);}

        #endregion              

    }
}
