using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public Alumno Alumno { set; get; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluaciones()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}