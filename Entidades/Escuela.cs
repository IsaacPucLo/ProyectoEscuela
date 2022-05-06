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

        
        //En la declaraci�n del siguente constructor estamos usando dos atributos "opcionales" al momento de crear y
        //esto se hace dandole un valor "default" a los atributos
        public Escuela(string nombre, int a�o, TipoEscuela tipo, string pais="", string ciudad="") {
            Nombre = nombre;
            A�oDeCreacion = a�o;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        } 

        public override string ToString() {

            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPa�s: {Pais}, Ciudad: {Ciudad}"; //poner el signo de pesos para definir las variales dentro de la misma cadena
        }

    }
}