using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {

        public static void DibujarLinea(int tamaño = 10)
        {
            //Imprime una linea recibiendo el tamaño como parametro, sino se coloca el default es 10
            var linea = "".PadLeft(tamaño, '-');
            WriteLine(linea);
        }

        public static void ImprimirTitulo(string titulo)
        {
            //Imprime la linea pasada por parametro como si fuera un titulo
            int tamño = titulo.Length + 6;

            Printer.DibujarLinea(tamño);
            WriteLine($"|  {titulo}  |");
            Printer.DibujarLinea(tamño);
        }

        public static void Beep(int hz = 2000, int tiempo= 500, int cantidad = 1){
            while (cantidad-- < 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }

    }
}