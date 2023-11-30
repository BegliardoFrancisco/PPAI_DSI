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
    using System.Data.Metadata.Edm;
    using System.Linq;

    public partial class CambiosEstado
    {
        public int id_cambio_estado { get; set; }
        public int id_estado { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public int id_llamada { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual Llamadas Llamadas { get; set; }

       
        public virtual int Id_cambio_estado
        {
            get;
            set;
        }

        public CambioEstado fromDomain()
        {
            EstadoLlamada estado;

            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
               
                estado = db.Estados.Single(b => b.id_estado == this.id_estado).fromDomain();
            }

            return new CambioEstado(this.id_cambio_estado,this.fecha_inicio,estado);
        }



        static public void Update(CambioEstado cambio)
        {
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                var cambioEstado = db.CambiosEstado.Single(ce => ce.id_cambio_estado == cambio.id);

                cambioEstado.fecha_fin = cambio.getFechaHoraFin();

                db.SaveChanges();
            }
        }

        static public int getIdCambioactual()
        {
            using(PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                return db.CambiosEstado.Single(ce => ce.fecha_fin == null).id_cambio_estado;
            }
        }

        static public void Insert(CambioEstado cambio, int id_llamada)
        {
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {

                CambiosEstado nuevocambioEstado = new CambiosEstado();
                nuevocambioEstado.fecha_inicio = cambio.getFechaHoraInicio();
                nuevocambioEstado.id_estado = Estados.getEstadoDB(cambio.getEstado()).id_estado;
                nuevocambioEstado.fecha_fin = cambio.getFechaHoraFin();
                nuevocambioEstado.id_cambio_estado = cambio.id;
                nuevocambioEstado.id_llamada = id_llamada;

               

                db.CambiosEstado.Add(nuevocambioEstado);
                db.SaveChanges();
            }
        }
    }
}