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
            EstadoLlamada estado1 = new Iniciada("Iniciada");
            EstadoLlamada estado2 = new EnCurso("EnCurso");
            EstadoLlamada estado3 = new Finalizada("Finalizada");

            //FechaHoraInicioLlamada 
            //Le resto 5 minutos que son en los que esta con el BOT
            DateTime fechaHoraInicio = DateTime.Now.AddMinutes(-5);

            //cambiosEstados
            CambioEstado cambioEstado1 = new CambioEstado(fechaHoraInicio, estado1);

            //Categorias
            CategoriaLlamada categoria1 = new CategoriaLlamada("Informar robo", 1);
            CategoriaLlamada categoria2 = new CategoriaLlamada("Tarjeta Bloqueada", 2);
            CategoriaLlamada categoria3 = new CategoriaLlamada("Finalizar llamada", 3);

            //OpcionesCategoria1
            OpcionLlamada opcion1Cat1 = new OpcionLlamada("Solicitar una nueva tarjeta", 1);
            OpcionLlamada opcion2Cat1 = new OpcionLlamada("Anular su Tarjeta", 2);
            OpcionLlamada opcion3Cat1 = new OpcionLlamada("Finalizar Llamada", 3);

            //OpcionesCategoria2
            OpcionLlamada opcion1Cat2 = new OpcionLlamada("Desbloquear Tarjeta", 1);
            OpcionLlamada opcion2Cat2 = new OpcionLlamada("Finalizar Llamada", 2);

            //OpcionHablarConOperador
            OpcionLlamada opcionOperador = new OpcionLlamada("Hablar con operador", 4);

            //SubOpcionesOpcion1
            SubOpcionLlamada subOpcion1Opcion1 = new SubOpcionLlamada("Cuenta con datos de la tarjeta", 1);
            SubOpcionLlamada subOpcion2Opcion1 = new SubOpcionLlamada("No cuenta con los datos de la tarjeta", 2);
            SubOpcionLlamada subOpcion3Opcion1 = new SubOpcionLlamada("Finalizar Llamada", 2);

            //SubOpcionHablarConOperador
            SubOpcionLlamada subOpcionOperador = new SubOpcionLlamada("Hablar con operador", 4);


            //Validaciones
            Validacion validacion1 = new Validacion("Fecha de nacimiento", "Fecha de nacimiento", 1);
            Validacion validacion2 = new Validacion("Cantidad de hijos", "Cantidad de hijos", 2);
            Validacion validacion3 = new Validacion("Codigo Postal", "Código Postal", 3 );

            //opcionesValidaciones
            OpcionValidacion opc1Val1 = new OpcionValidacion(false, "4 de Enero de 2000");
            OpcionValidacion opc2Val1 = new OpcionValidacion(true, "28 de julio de 1998");
            OpcionValidacion opc3Val1 = new OpcionValidacion(false, "8 de noviembre de 1999");

            OpcionValidacion opc1Val2 = new OpcionValidacion(true, "0");
            OpcionValidacion opc2Val2 = new OpcionValidacion(false, "2");
            OpcionValidacion opc3Val2 = new OpcionValidacion(false, "4");

            OpcionValidacion opc1Val3 = new OpcionValidacion(false, "5000");
            OpcionValidacion opc2Val3 = new OpcionValidacion(false, "2627");
            OpcionValidacion opc3Val3 = new OpcionValidacion(true, "3748");

            //Acciones
            Accion accion1 = new Accion("Comunicar saldo");
            Accion accion2 = new Accion("Dar de baja la tarjeta");
            Accion accion3 = new Accion("Denunciar robo");

            //Objetos traidos del CU1 y carga de datos

            //Cliente
            Cliente clienteLlamada = new Cliente(43881908, "Nicolás Ranalli", 543468548271);

            //Llamada del cliente
            Llamada llamadaActual = new Llamada(clienteLlamada, cambioEstado1);

            categoria1.agregarOpcion(opcion1Cat1);
            categoria1.agregarOpcion(opcion2Cat1);
            categoria1.agregarOpcion(opcion3Cat1);
            categoria1.agregarOpcion(opcionOperador);

            categoria2.agregarOpcion(opcion1Cat2);
            categoria2.agregarOpcion(opcion2Cat2);
            categoria2.agregarOpcion(opcionOperador);

            opcion1Cat1.agregarSubOpcion(subOpcion1Opcion1);
            opcion1Cat1.agregarSubOpcion(subOpcion2Opcion1);
            opcion1Cat1.agregarSubOpcion(subOpcion3Opcion1);
            opcion1Cat1.agregarSubOpcion(subOpcionOperador);

            validacion1.agregarOpcionValidacion(opc1Val1);
            validacion1.agregarOpcionValidacion(opc2Val1);
            validacion1.agregarOpcionValidacion(opc3Val1);

            validacion2.agregarOpcionValidacion(opc1Val2);
            validacion2.agregarOpcionValidacion(opc2Val2);
            validacion2.agregarOpcionValidacion(opc3Val2);

            validacion3.agregarOpcionValidacion(opc1Val3);
            validacion3.agregarOpcionValidacion(opc2Val3);
            validacion3.agregarOpcionValidacion(opc3Val3);

            subOpcionOperador.agregarValidacion(validacion1);
            subOpcionOperador.agregarValidacion(validacion2);
            subOpcionOperador.agregarValidacion(validacion3);


            //carga de datos al gestor

            gestor.agregarAcciones(accion1);
            gestor.agregarAcciones(accion2);
            gestor.agregarAcciones(accion3);

            gestor.agregarEstados(estado1);
            gestor.agregarEstados(estado2);
            gestor.agregarEstados(estado3);

            gestor.agregarCategoria(categoria1);
            gestor.agregarOpcion(opcion1Cat1);
            gestor.agregarSubOpcion(subOpcionOperador);

            gestor.opcionLlamadaOperador(llamadaActual);

        }


    }
}
