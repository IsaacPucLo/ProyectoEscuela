using System.Collections.Generic;

namespace CoreEscuela.Entidades {

    public class Escuela{
        //Atributos
        string nombre;
        
        public string Nombre {
            get { return nombre; }

            set { nombre = value; }
        }

        public int AñoDeCreacion { set; get; }

        public string Pais { set; get; }

        public string Ciudad { set; get; }

        public TiposEscuela TipoEscuela { set; get; }

        public List<Curso> Cursos { set; get; } 




        //Constructor
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        
        //En la declaración del siguente constructor estamos usando dos atributos "opcionales" al momento de crear y
        //esto se hace dandole un valor "default" a los atributos
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais="", string ciudad="") {
            Nombre = nombre;
            AñoDeCreacion = año;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        } 

        public override string ToString() {

            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPa�s: {Pais}, Ciudad: {Ciudad}"; //poner el signo de pesos para definir las variales dentro de la misma cadena
        }

    }
}