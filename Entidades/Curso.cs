using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {

        public TiposJornada Jornada { set; get; }

        public List<Asignatura> Asignaturas { set; get; }
        public List<Alumno> Alumnos { set; get; }
        public string Direccion { get; set; }

        public Curso()
        {

        }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
    }
}