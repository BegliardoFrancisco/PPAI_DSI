using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.Entidades
{
    public class Iniciada: EstadoLlamada
    {
        public Iniciada (string nombre) : base(nombre) { }

        public override void finalizarLlamada(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado)
        {
            throw new NotImplementedException();
        }
    }
}
