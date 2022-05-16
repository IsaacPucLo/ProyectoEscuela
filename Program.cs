using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;  //Esribiendo esta linea podemos imprimir en pantalla usando unicamente WriteLine

namespace ProyectoEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se ejecuta al finalizar la ejecucion del programa
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicilizar();

            var reporteador = new Reporteador(engine.ObtenerDiccionarioObjetos());
            var evalList = reporteador.ObtenerListaEvaluaciones();
            var listaAsg = reporteador.ObtenerListaAsignaturas();
            var listaEvalXAsig = reporteador.ObtenerDicEvalXAsignatura();
            var listaPromXAsig = reporteador.ObtenerPromedioAlumnoXAsignatura();

            Printer.ImprimirTitulo("Captura de una Evaluación por consola");
            var newEval = new Evaluacion();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluacion");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                WriteLine("El valor del nombre no puede estar vacio");
                WriteLine("Saliendo...");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido creado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluacion");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(notaString))
            {
                WriteLine("El valor de la nota no puede estar vacio");
                WriteLine("Saliendo...");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido creado correctamente");
                }
                catch (ArgumentOutOfRangeException arge)    //Primero se ejecuta este catch sino es el error entonces continua al siguiente
                {
                    WriteLine(arge.Message);
                    WriteLine("Saliendo...");
                }
                catch (Exception)       //Se coloca este error al final en los catch por si es un error no controlado se ejecute este al final, si nada coincide antes estee se ejecuta
                {
                    WriteLine("El valor de la nota no es un número válido");
                    WriteLine("Saliendo...");
                }
            }

        }

        private static void AccionDelEvento(Object sender, EventArgs e)
        {
            Printer.ImprimirTitulo("Saliendo");
            Printer.Beep(2000, 1000, 3);
            Printer.ImprimirTitulo("Salió");
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
