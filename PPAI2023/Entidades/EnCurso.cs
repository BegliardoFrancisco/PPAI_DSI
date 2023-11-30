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

            // UPDATE BDD DEL CAMBIO ESTADO
            CambiosEstado.Update(cambioEstadoActual);

            EstadoLlamada estadoFinal = this.crearEstado();

            CambioEstado nuevoCambioEstado = this.crearCambioEstado(estadoFinal, fechaHoraActual);

            // Insertamos en la BDD el cambio estado
            CambiosEstado.Insert(nuevoCambioEstado,llamada.id);

            llamada.agregarCambioEstado(nuevoCambioEstado);
            llamada.setEstado(estadoFinal);
        }

        private CambioEstado crearCambioEstado(EstadoLlamada estadoFinal, DateTime fechaHoraActual)
        {
            CambioEstado cb = new CambioEstado(fechaHoraActual, fechaHoraActual, estadoFinal);

            return cb;
        }

 

        private CambioEstado obtenerCambioEstadoActual(List<CambioEstado> cambiosEstadoLlamada)
        {
            foreach (CambioEstado cambio in cambiosEstadoLlamada)

            { if (cambio.esUltimo()) return cambio; }

            return null;
        }

        public override EstadoLlamada crearEstado()
        {
            return new Finalizada("Finalizada");
        }
    }
}
