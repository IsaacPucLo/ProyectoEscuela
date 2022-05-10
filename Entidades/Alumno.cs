using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { private set; get; }

        public string Nombre { set; get; }

        public List<Evaluaciones> Evaluaciones { get; set; }

        public Alumno()
        {
            UniqueId = Guid.NewGuid().ToString();
            Evaluaciones = new List<Evaluaciones>();    //Inicializamos en el constructor para que no de errr cuando se quiera llenar en el metodo de cargarEvaluaciones
        }
    }
}