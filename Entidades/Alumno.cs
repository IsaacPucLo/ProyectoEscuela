using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>(); //Inicializamos en el constructor para que no de errr cuando se quiera llenar en el metodo de cargarEvaluaciones

        public Alumno()
        {
        }
    }
}