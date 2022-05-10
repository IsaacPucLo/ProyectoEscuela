using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class EscuelaEngine
    {

        //Atributos
        public Escuela Escuela { get; set; }


        //Constructor
        public EscuelaEngine()
        {
        }

        //Metodos
        public void Inicilizar()
        {
            Escuela = new Escuela("TecNM Campus Porgreso", 2008, TiposEscuela.Universidad, ciudad: "Progreso", pais: "México");

            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "301", Jornada = TiposJornada.Noche },
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana }
            };
        }
    }
}