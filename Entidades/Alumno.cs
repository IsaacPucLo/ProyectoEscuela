using System;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public Alumno()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}