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
    
    public partial class Acciones
    {
        public Acciones()
        {
            this.Llamadas = new HashSet<Llamadas>();
        }
    
        public int id_accion { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<Llamadas> Llamadas { get; set; }

        public Accion fromDomain()
        {
            return new Accion(this.descripcion);
        }
    }
}