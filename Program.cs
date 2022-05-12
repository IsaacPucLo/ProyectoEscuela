using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;  //Esribiendo esta linea podemos imprimir en pantalla usando unicamente WriteLine

namespace ProyectoEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicilizar();

            ImprimirCursosEscuela(engine.Escuela);


            Printer.DibujarLinea(20);
            Printer.DibujarLinea(20);
            Printer.DibujarLinea(20);
            Printer.ImprimirTitulo("Pruebas de Polimorfismo");

            var listaObjetos = engine.ObtenerObjetosEscuela();

            var listaILugar = from obj in listaObjetos
                              where obj is ILugar //Implementar el where para estar seguros de que unicamente traerá ese tipo de objeto
                              select (ILugar)obj;   //Ya implementado el where se puede hacer el casteo sin problemas cuidando que sean el mismo objeto

            //engine.Escuela.LimpiarLugar();

        }


        //METODOS DE LA CLASE
        private static void ImprimirCursosEscuela(Escuela escuela)
        {

            Printer.ImprimirTitulo($"Cursos de {escuela.Nombre}");

            //Si la primera es null entonces ya no hace la siguiente comparación, se llama CORTOCIRCUITO DE EXPRESIÓN DE EVALUACIONES
            if (escuela?.Cursos != null)
            {    //El operador interrogación nos ayuda a evaluar escuela, entonces no va a evaluar cursos a menos que la escuela sea diferente de null
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }
    }
}
