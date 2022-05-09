using System;
using CoreEscuela.Entidades;
using static System.Console;  //Esribiendo esta linea podemos imprimir en pantalla usando unicamente WriteLine

namespace ProyectoEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crearcion de objetos escuela
            var escuela = new Escuela("TecNM Campus Porgreso", 2010);
            escuela.Pais = "México";
            escuela.Ciudad = "Porgreso";
            escuela.TipoEscuela = TiposEscuela.Universidad;

            var escuela2 = new Escuela("UADY", 1990, TiposEscuela.Universidad, ciudad: "Merida"); //Para indicar que el parámetro 

            //Creacion de cursos Optimizado para una lectura mas sencilla y añadido a la escuela seleccionada
            escuela.Cursos = new Curso[] {
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };

                ImprimirCursosEscuela(escuela);

        }


        //METODOS DE LA CLASE
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("--------------------------");
            WriteLine($"Cursos de {escuela.Nombre}");
            WriteLine("--------------------------");

            //Si la primera es null entonces ya no hace la siguiente comparación, se llama CORTOCIRCUITO DE EXPRESIÓN DE EVALUACIONES
            if(escuela?.Cursos != null){    //El operador interrogación nos ayuda a evaluar escuela, entonces no va a evaluar cursos a menos que la escuela sea diferente de null
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }       
        }


        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                System.Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");

            }

        }
    }
}
