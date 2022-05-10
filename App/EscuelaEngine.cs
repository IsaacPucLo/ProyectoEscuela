using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine //Permite crear objetos de esta clase pero no permite que otras clases hereden de esta
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
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            
           foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            Evaluacion ev = new Evaluacion(){
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i+1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);  //Debe estar inicializado, sino da error
                        }

                    }
                }
            } 

        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> litaAsignaturas = new List<Asignatura>(){ //dejamos la creacion de las materias dentro del ciclo porque así cada materia tendrá un unico id segun el curso al que estpe asignado
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Español"},
                    new Asignatura{Nombre = "Inglés"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = litaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return ListaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "301", Jornada = TiposJornada.Noche },
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana }
            };

            Random rdn = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom = rdn.Next(10, 30);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        public List<ObjetoEscuelaBase> ObtenerObjetosEscuela(){
            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);
            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listaObj;
        }


    }
}