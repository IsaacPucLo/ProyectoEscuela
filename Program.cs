using System;
using CoreEscuela.Entidades;

namespace ProyectoEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var escuela = new Escuela("TecNM Campus Porgreso", 2010);

            escuela.Pais = "México";
            escuela.Ciudad = "Porgreso";
            escuela.TipoEscuela = TiposEscuela.Universidad;

            var escuela2 = new Escuela("UADY", 1990, TiposEscuela.Universidad, ciudad:"Merida"); //Para indicar que el parámetro 

            var curso1 = new Curso(){ Nombre = "101" };
            var curso2 = new Curso(){ Nombre = "201" };
            var curso3 = new Curso(){ Nombre = "301" };

           Console.WriteLine(escuela);
           Console.WriteLine(escuela2);
           System.Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
           System.Console.WriteLine(curso2.Nombre + ", " + curso2.UniqueId);
           System.Console.WriteLine($"{curso3.Nombre} ,  {curso3.UniqueId}");

        }
    }
}
