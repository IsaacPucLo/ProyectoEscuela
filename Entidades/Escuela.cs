namespace CoreEscuela.Entidades {

    class Escuela{
        //Atributos
        string nombre;
        
        public string Nombre {
            get { return nombre; }

            set { nombre = value; }
        }

        public int A�oDeCreacion { set; get; }

        public string Pais { set; get; }

        public string Ciudad { set; get; }

        public TipoEscuela TipoEscuela { set; get; }


        //Constructor
        public Escuela(string nombre, int a�o) => (Nombre, A�oDeCreacion) = (nombre, a�o);

        public override string ToString() {

            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPa�s: {Pais}, Ciudad: {Ciudad}";
        }

    }
}