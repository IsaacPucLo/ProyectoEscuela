
namespace CoreEscuela.Entidades {

    class Escuela{
        //Atributos
        string nombre;
        
        public string Nombre {
            get { return nombre; }

            set { nombre = value; }
        }

        public int AñoDeCreacion { set; get; }

        public string Pais { set; get; }

        public string Ciudad { set; get; }


        //Constructor
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);







    }
}