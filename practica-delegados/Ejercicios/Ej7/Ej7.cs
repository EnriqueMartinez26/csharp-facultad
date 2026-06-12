using System;

namespace Ejercicios.Ej7
{
    public delegate string Formateador(string texto);

    public static class Ejercicio7
    {
        private static string Mayusculas(string texto) => texto.ToUpper();
        private static string Minusculas(string texto) => texto.ToLower();
        private static string ConAsteriscos(string texto) => $"*{texto}*";

        private static void MostrarMensaje(string mensaje, Formateador formateador)
        {
            string resultado = formateador(mensaje);
            Console.WriteLine(resultado);
        }

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese un texto:");
            string entrada = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Formato 1: Mayúsculas");
            MostrarMensaje(entrada, Mayusculas);

            Console.WriteLine("Formato 2: Minúsculas");
            MostrarMensaje(entrada, Minusculas);

            Console.WriteLine("Formato 3: Entre asteriscos");
            MostrarMensaje(entrada, ConAsteriscos);
        }
    }
}
