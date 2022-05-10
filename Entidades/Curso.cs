using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase
    {

        public TiposJornada Jornada { set; get; }

        public List<Asignatura> Asignaturas { set; get; }
        public List<Alumno> Alumnos { set; get; }

        public Curso()
        {

        }
    }
}