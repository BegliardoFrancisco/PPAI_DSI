using PPAI2023.Entidades;
using System;
using System.Collections.Generic;

namespace PPAI2023.Entidades
{
    internal class Finalizada : EstadoLlamada
    {
        public Finalizada(string nombre) : base(nombre)
        {
        }

        public override EstadoLlamada crearEstado()
        {
            throw new NotImplementedException();
        }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado)
        {
            throw new NotImplementedException();
        }
    }
}