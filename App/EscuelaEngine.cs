using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

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

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic){
            foreach (var obj in dic)
            {
                Printer.ImprimirTitulo(obj.Key.ToString());

                foreach (var val in obj.Value)
                {
                    System.Console.WriteLine(val);
                }
            }

        }

        //CAMBIAMOS EL TIPO DE LLAVE QUE RECIBE EL DICCIONARIO A UN TIPO "llave diccionario" para que
        //unicamente puedan utilizar los tipos que ya definimos en ese enum
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> ObtenerDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Cursos, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            var listaEvaluaciontmp = new List<Evaluacion>();
            var listaAsignaturatmp = new List<Asignatura>();
            var listaAlumnotmp = new List<Alumno>();
            foreach (var curso in Escuela.Cursos)
            {
                listaAsignaturatmp.AddRange(curso.Asignaturas);
                listaAlumnotmp.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaEvaluaciontmp.AddRange(alumno.Evaluaciones); //No podemos poner aquí el diccionario.add ya que en cada vuelta se estaría duplicando la creacion de esa llave, lo que da un error
                }
            }
            diccionario.Add(LlaveDiccionario.Evaluaciones, listaEvaluaciontmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignaturas, listaAsignaturatmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumnos, listaAlumnotmp.Cast<ObjetoEscuelaBase>());


            return diccionario;
        }

        #region Metodos de carga
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
                            Evaluacion ev = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
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

        public List<ObjetoEscuelaBase> ObtenerObjetosEscuela()
        {
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

        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjetosEscuela(out int conteoEvaluaciones,
                                                             out int conteoAlumnos,
                                                             out int conteoAsignaturas,
                                                             out int conteoCursos,
                                                             bool traeEvaluaciones = true,
                                                             bool traeAlumnos = true,
                                                             bool traeAsignaturas = true,
                                                             bool traeCursos = true)
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            conteoCursos = conteoAlumnos = conteoEvaluaciones = conteoAsignaturas = 0;

            listaObj.Add(Escuela);

            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);
            }
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                }

                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }

        #endregion

    }
}