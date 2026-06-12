using System;

namespace PracticaPoo.Lib.Modelos
{
    public class Persona
    {
        private static int contador = 0;
        
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }

        public Persona()
        {
            contador++;
        }

        public void Saludar()
        {
            Console.WriteLine($"Â¡Hola! Soy {Nombre} y tengo {Edad} aÃ±os.");
        }

        public static int ObtenerTotal()
        {
            return contador;
        }
    }
}
