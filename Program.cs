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

            Printer.ImprimirTitulo("Ejemplo de diccionario");

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            //Para agregar pares al diccionario se puede hacer de esta manera:
            diccionario.Add(17, "Isaac");
            diccionario.Add(26, "Karol");

            //Una forma de recorrer un diccionario es el foreach
            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Valor: {keyValPair.Value}");
            }

            Printer.DibujarLinea();
            diccionario[35] = "Mariana";     //Esta es otra opcion de agregar valores al diccionario
            WriteLine(diccionario[35]);       //En caso de querer imprimir un valor que el diccionario no tenga almacenado, ejemplo [0], este mandará una excepcion

            Printer.DibujarLinea();
            Printer.DibujarLinea();
            Printer.ImprimirTitulo("Implementación al programa");
            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira al rededor del planeta tierra";
            WriteLine(dic["Luna"]);

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
