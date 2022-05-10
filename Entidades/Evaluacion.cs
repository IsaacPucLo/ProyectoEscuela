using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {

        public Alumno Alumno { set; get; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluacion()
        {

        }
    }
}