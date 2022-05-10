using System;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public Asignatura()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}