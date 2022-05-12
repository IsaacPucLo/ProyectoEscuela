using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{

    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        //Atributos
        public int AñoDeCreacion { set; get; }

        public string Pais { set; get; }

        public string Ciudad { set; get; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { set; get; }

        public List<Curso> Cursos { set; get; }




        //Constructor
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);


        //En la declaración del siguente constructor estamos usando dos atributos "opcionales" al momento de crear y
        //esto se hace dandole un valor "default" a los atributos
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            Nombre = nombre;
            AñoDeCreacion = año;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {

            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPa�s: {Pais}, Ciudad: {Ciudad}"; //poner el signo de pesos para definir las variales dentro de la misma cadena
        }


        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"\n Escuela {Nombre} Limpia");
        }

    }
}