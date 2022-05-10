using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso{

        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public TiposJornada Jornada { set; get; }

        public List<Asignatura> Asignaturas { set; get; }
        public List<Alumno> Alumnos { set; get; }

        public Curso() {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}