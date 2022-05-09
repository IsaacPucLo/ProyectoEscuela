using System;

namespace CoreEscuela.Entidades
{
    public class Curso{

        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public TiposJornada Jornada { set; get; }

        public Curso() {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}