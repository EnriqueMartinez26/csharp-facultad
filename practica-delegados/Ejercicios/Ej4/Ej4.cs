using System;

namespace Ejercicios.Ej4
{
    public delegate void Notificador(string mensaje);

    public static class Ejercicio4
    {
        private static void MostrarMensaje(string texto)
        {
            Console.WriteLine($"Mensaje recibido: {texto}");
        }

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese un mensaje:");
            string entrada = Console.ReadLine() ?? string.Empty;

            Notificador notificador = MostrarMensaje;
            notificador(entrada);
        }
    }
}
