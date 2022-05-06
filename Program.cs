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
            escuela.TipoEscuela = TipoEscuela.Universidad;

            var escuela2 = new Escuela("UADY", 1990, TipoEscuela.Universidad, ciudad:"Merida"); //Para indicar que el parámetro 
                                                                                             //que le estoy mandando es de ciudad 
                                                                                             //y no de pais como está definido en 
                                                                                             //sus constructor, tengo que 
                                                                                             //escribir el nombre del parametro 
                                                                                              //seguido de ":"]*/


           Console.WriteLine(escuela);
           Console.WriteLine(escuela2);

        }
    }
}
