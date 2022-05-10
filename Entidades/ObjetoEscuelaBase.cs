using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase     //El abstract permite unicamente que hereden de la clase, no para crear objetos (instanciarlo)
    {
        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}