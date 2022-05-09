using System;
using CoreEscuela.Entidades;

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

            var escuela2 = new Escuela("UADY", 1990, TiposEscuela.Universidad, ciudad:"Merida"); //Para indicar que el parámetro 

            //Creacion de cursos
            Curso[] arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso(){ Nombre = "101" };
            arregloCursos[1] = new Curso(){ Nombre = "201" };
            arregloCursos[2] = new Curso(){ Nombre = "301" };

           Console.WriteLine(escuela);
           Console.WriteLine(escuela2);

           ImprimirCursos(arregloCursos);

        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                System.Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }
    }
}
