using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI2023.Entidades;
using PPAI2023.Controlador;

namespace PPAI2023.RepositorioDatos
{
    public class BaseDatos
    {
        #region Atributos

        GestorRegistrarRespuesta gestor;

        #endregion 



        //Constructor
        public BaseDatos(GestorRegistrarRespuesta gestor) {

            this.gestor = gestor;       
        }

        public void inicializarDatos()
        {

            //estados
            //EstadoLlamada estado1 = new Iniciada("Iniciada");
            //EstadoLlamada estado2 = new EnCurso("EnCurso");
            //EstadoLlamada estado3 = new Finalizada("Finalizada");
            EstadoLlamada estado1;
            EstadoLlamada estado2;
            EstadoLlamada estado3;

            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                estado1 = db.Estados.Single(b => b.nombre_estado == "Iniciada").fromDomain();
                estado2 = db.Estados.Single(b => b.nombre_estado == "EnCurso").fromDomain();
                estado3 = db.Estados.Single(b => b.nombre_estado == "Finalizada").fromDomain();
            }

            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                Llamadas llamada = new Llamadas();

                Random r = new Random();
                int minutes = r.Next(-10, 0);

                llamada.id_cliente = 1;
                llamada.fecha_hora_inicio = DateTime.Now.AddMinutes(-minutes);

                db.Llamadas.Add(llamada);
                db.SaveChanges();

                CambiosEstado cambiosEstado = new CambiosEstado();

                cambiosEstado.fecha_inicio = DateTime.Now;
                cambiosEstado.id_estado = 9;

                Llamadas llamadaCreada = db.Llamadas
                                    .OrderByDescending(l => l.id_llamada)
                                    .FirstOrDefault();
    
                cambiosEstado.id_llamada = llamadaCreada.id_llamada;

                db.CambiosEstado.Add(cambiosEstado);
                db.SaveChanges();
            }




            ////Categorias
            //CategoriaLlamada categoria1 = new CategoriaLlamada("Informar robo", 1);
            //CategoriaLlamada categoria2 = new CategoriaLlamada("Tarjeta Bloqueada", 2);
            //CategoriaLlamada categoria3 = new CategoriaLlamada("Finalizar llamada", 3);

            List<CategoriaLlamada> categorias;

            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                categorias = db.Categorias.ToList().Select(a => a.fromDomain()).ToList();
            }
            //Objetos 
            //OpcionesCategoria1
            //OpcionLlamada opcion1Cat1 = new OpcionLlamada("Solicitar una nueva tarjeta", 1);
            //OpcionLlamada opcion2Cat1 = new OpcionLlamada("Anular su Tarjeta", 2);
            //OpcionLlamada opcion3Cat1 = new OpcionLlamada("Finalizar Llamada", 3);

            //OpcionesCategoria2
            //OpcionLlamada opcion1Cat2 = new OpcionLlamada("Desbloquear Tarjeta", 1);
            //OpcionLlamada opcion2Cat2 = new OpcionLlamada("Finalizar Llamada", 2);

            //OpcionHablarConOperador
            //OpcionLlamada opcionOperador = new OpcionLlamada("Hablar con operador", 4);

            List<OpcionLlamada> opcionesLLamadas1;
            List<OpcionLlamada> opcionesLLamadas2;
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                List<Categorias> categoriasBD = db.Categorias.ToList();

                opcionesLLamadas1 = db.OpcionesLlamada
                    .ToList()
                    .FindAll(op => op.id_categoria == categoriasBD[1].id_categoria)
                    .Select(op => op.fromDomain()).ToList();

                opcionesLLamadas2 = db.OpcionesLlamada
                    .ToList()
                    .FindAll(op => op.id_categoria == categoriasBD[2].id_categoria)
                    .Select(op => op.fromDomain()).ToList();
            }

            //SubOpcionesOpcion1
            //SubOpcionLlamada subOpcion1Opcion1 = new SubOpcionLlamada("Cuenta con datos de la tarjeta", 1);
            //SubOpcionLlamada subOpcion2Opcion1 = new SubOpcionLlamada("No cuenta con los datos de la tarjeta", 2);
            //SubOpcionLlamada subOpcion3Opcion1 = new SubOpcionLlamada("Finalizar Llamada", 2);

            //SubOpcionHablarConOperador
            //SubOpcionLlamada subOpcionOperador = new SubOpcionLlamada("Hablar con operador", 4);

            List<SubOpcionLlamada> subOpcionesLlamadas;
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                subOpcionesLlamadas = db.SubOpcionesLlamada
                    .ToList()
                    .Select(subop => subop.fromDomain()).ToList();
            }

            //Validaciones
            //Validacion validacion1 = new Validacion("Fecha de nacimiento", "Fecha de nacimiento", 1);
            //Validacion validacion2 = new Validacion("Cantidad de hijos", "Cantidad de hijos", 2);
            //Validacion validacion3 = new Validacion("Codigo Postal", "Código Postal", 3 );

            List<Validacion> validaciones;
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                validaciones = db.Validaciones.ToList().Select(va => va.fromDomain()).ToList();
            }



            //opcionesValidaciones
            //OpcionValidacion opc1Val1 = new OpcionValidacion(false, "4 de Enero de 2000");
            //OpcionValidacion opc2Val1 = new OpcionValidacion(true, "28 de julio de 1998");
            //OpcionValidacion opc3Val1 = new OpcionValidacion(false, "8 de noviembre de 1999");

            //OpcionValidacion opc1Val2 = new OpcionValidacion(true, "0");
            //OpcionValidacion opc2Val2 = new OpcionValidacion(false, "2");
            //OpcionValidacion opc3Val2 = new OpcionValidacion(false, "4");

            //OpcionValidacion opc1Val3 = new OpcionValidacion(false, "5000");
            //OpcionValidacion opc2Val3 = new OpcionValidacion(false, "2627");
            //OpcionValidacion opc3Val3 = new OpcionValidacion(true, "3748");

            List<OpcionValidacion> opcionValidaciones;

            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                opcionValidaciones = db.OpcionesValidaciones
                    .ToList()
                    .Select(opV => opV.fromDomain())
                    .ToList();
            }


            //Cliente
            Cliente clienteLlamada;

            //Acciones
            List<Accion> acciones;
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                acciones = db.Acciones.ToList().Select(a => a.fromDomain()).ToList();
                clienteLlamada = db.Clientes
                    .Single(c => c.nombre == "Nicólas Ranalli")
                    .fromDomain();
            }

            //Objetos traidos del CU1 y carga de datos

            //FechaHoraInicioLlamada 
            //Le resto 5 minutos que son en los que esta con el BOT
            DateTime fechaHoraInicio = DateTime.Now.AddMinutes(-5);

         
            //Llamada del cliente
            Llamada llamadaActual;
            
            using (PPAI_DSIEntities db = new PPAI_DSIEntities())
            {
                CambiosEstado cambioActual = db.CambiosEstado.Single(cbE => cbE.fecha_fin == null);

                llamadaActual = db.Llamadas
                    .Single(l => l.id_llamada == cambioActual.id_llamada).fromDomain();
                    }



            categorias[0].agregarOpcion(opcionesLLamadas2[0]);
            categorias[0].agregarOpcion(opcionesLLamadas2[1]);
            categorias[0].agregarOpcion(opcionesLLamadas2[2]);
            categorias[0].agregarOpcion(opcionesLLamadas2[3]);

            categorias[1].agregarOpcion(opcionesLLamadas1[0]);
            categorias[1].agregarOpcion(opcionesLLamadas1[1]);
            categorias[1].agregarOpcion(opcionesLLamadas1[2]);

            opcionesLLamadas2[0].agregarSubOpcion(subOpcionesLlamadas[0]);
            opcionesLLamadas2[0].agregarSubOpcion(subOpcionesLlamadas[1]);
            opcionesLLamadas2[0].agregarSubOpcion(subOpcionesLlamadas[2]);
            opcionesLLamadas2[0].agregarSubOpcion(subOpcionesLlamadas[3]);

            validaciones[0].agregarOpcionValidacion(opcionValidaciones[0]);
            validaciones[0].agregarOpcionValidacion(opcionValidaciones[1]);
            validaciones[0].agregarOpcionValidacion(opcionValidaciones[2]);

            validaciones[1].agregarOpcionValidacion(opcionValidaciones[3]);
            validaciones[1].agregarOpcionValidacion(opcionValidaciones[4]);
            validaciones[1].agregarOpcionValidacion(opcionValidaciones[5]);

            validaciones[2].agregarOpcionValidacion(opcionValidaciones[6]);
            validaciones[2].agregarOpcionValidacion(opcionValidaciones[7]);
            validaciones[2].agregarOpcionValidacion(opcionValidaciones[8]);

            subOpcionesLlamadas[3].agregarValidacion(validaciones[0]);
            subOpcionesLlamadas[3].agregarValidacion(validaciones[1]);
            subOpcionesLlamadas[3].agregarValidacion(validaciones[2]);


            //carga de datos al gestor

            gestor.agregarAcciones(acciones[0]);
            gestor.agregarAcciones(acciones[1]);
            gestor.agregarAcciones(acciones[2]);

            gestor.agregarEstados(estado1);
            gestor.agregarEstados(estado2);
            gestor.agregarEstados(estado3);

            gestor.agregarCategoria(categorias[0]);
            gestor.agregarOpcion(opcionesLLamadas1[0]);
            gestor.agregarSubOpcion(subOpcionesLlamadas[3]);

            gestor.opcionLlamadaOperador(llamadaActual);

        }


    }
}
