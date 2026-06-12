using System;
using System.Threading;

namespace Eventos.Ev10
{
    public delegate void ClickHandler();

    public class Clicker
    {
        public event ClickHandler? ClickHecho;
        public event Action? LimiteAlcanzado;
        private bool detenido;

        public void RealizarClick()
        {
            if (detenido)
                return;

            ClickHecho?.Invoke();
        }

        public void Detener()
        {
            if (detenido)
                return;

            detenido = true;
            LimiteAlcanzado?.Invoke();
        }
    }

    public static class Ejercicio10
    {
        public static void Ejecutar()
        {
            using ManualResetEventSlim finalizado = new(false);
            Clicker clicker = new();
            int contador = 0;

            clicker.ClickHecho += () =>
            {
                contador++;
                Console.WriteLine($"Click numero: {contador}");
                if (contador >= 10)
                {
                    Console.WriteLine("Se realizaron 10 clics. Fin del conteo.");
                    clicker.Detener();
                }
            };

            clicker.LimiteAlcanzado += () => finalizado.Set();

            Console.WriteLine("Presione la barra espaciadora para hacer click (x para salir):");

            while (!finalizado.IsSet)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Spacebar)
                    clicker.RealizarClick();
                else if (tecla == ConsoleKey.X)
                    break;
            }
        }
    }
}
