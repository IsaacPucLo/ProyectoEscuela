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



            Console.WriteLine(escuela.Nombre);
        }
    }
}
