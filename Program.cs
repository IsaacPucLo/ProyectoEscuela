﻿using System;
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
