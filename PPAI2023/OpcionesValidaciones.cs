//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPAI2023
{
    using PPAI2023.Entidades;
    using System;
    using System.Collections.Generic;
    
    public partial class OpcionesValidaciones
    {
        public int id_opcion_validacion { get; set; }
        public int id_validacion { get; set; }
        public bool es_correcta { get; set; }
        public string nombre { get; set; }
    
        public virtual Validaciones Validaciones { get; set; }

        public OpcionValidacion fromDomain()
        {
            return new OpcionValidacion(this.es_correcta,this.nombre); ;
        }
    }
}
