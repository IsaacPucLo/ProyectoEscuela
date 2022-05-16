using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;    //Por convencion cuando un atributo es privado empieza por " _ "
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (_diccionario == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }
            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> ObtenerListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> ObtenerListaAsignaturas()
        {
            return ObtenerListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> ObtenerListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = ObtenerListaEvaluaciones();

            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> ObtenerDicEvalXAsignatura()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = ObtenerListaAsignaturas(out var listaEval);


            foreach (var asignatura in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asignatura
                               select eval;

                dicRta.Add(asignatura, evalAsig);
            }
            return dicRta;
        }

        public Dictionary<string, IEnumerable<Object>> ObtenerPromedioAlumnoXAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<Object>>();
            var dicEvalXAsig = ObtenerDicEvalXAsignatura();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlum = from eval in asigConEval.Value  //Funcion para sacar el promedio del alumno
                                group eval by new
                                {
                                    eval.Alumno.UniqueId,
                                    eval.Alumno.Nombre
                                }
                            into grupoEvalsAlumno
                                select new AlumnoPromedio   //Creamos una clase para adicionarle los atributos a nuestro objeto y que dehe de ser de tipo anónimo
                                {
                                    alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                    alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                    promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)  //Usamos una expresión Lambda para que a cada evaluación obtenfa el promedio de cada nota en las evalaucianes
                                };
                rta.Add(asigConEval.Key, promsAlum);
            }

            return rta;
        }
    }
}