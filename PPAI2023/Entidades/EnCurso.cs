using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class EnCurso : EstadoLlamada
    {
        public EnCurso(string nombre):base (nombre) { }


        //Metodo polimorfico

        /*public override void finalizarLlamada(Llamada llamada, string descripcion, OpcionLlamada opcion, SubOpcionLlamada subopcion)
         {
             llamada.setDescripcionOperador(descripcion);
             llamada.setOpcion(opcion);
             llamada.setSubOpcion(subopcion);
         }*/

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado)
        {
            CambioEstado cambioEstadoActual = obtenerCambioEstadoActual(cambioEstado);
            cambioEstadoActual.setFechaHoraFin(fechaHoraActual);


            EstadoLlamada estadoFinal = this.crearEstado();

            CambioEstado nuevoCambioEstado = this.crearCambioEstado(estadoFinal, fechaHoraActual);

            llamada.agregarCambioEstado(nuevoCambioEstado);
            llamada.setEstado(estadoFinal);
        }

        private CambioEstado crearCambioEstado(EstadoLlamada estadoFinal, DateTime fechaHoraActual)
        {
            return new CambioEstado(fechaHoraActual,estadoFinal);
        }

        private EstadoLlamada crearEstado()
        {
           return new Finalizada("Finalizada");

        }

        private CambioEstado obtenerCambioEstadoActual(List<CambioEstado> cambiosEstadoLlamada)
        {
            foreach (CambioEstado cambio in cambiosEstadoLlamada)

            { if (cambio.esUltimo()) return cambio; }

            return null;
        }
    }
}
