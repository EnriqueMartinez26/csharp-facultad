using System;

namespace Eventos.Ev9
{
    public delegate void OpcionSeleccionadaHandler(string opcion);

    public class Menu
    {
        public event OpcionSeleccionadaHandler? OpcionSeleccionada;

        public void MostrarMenu()
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Saludo");
            Console.WriteLine("2. Despedida");
            Console.Write("Seleccione una opción (x para salir): ");

            var tecla = Console.ReadKey(true).KeyChar;

            if (tecla == '1')
                OpcionSeleccionada?.Invoke("Saludo");
            else if (tecla == '2')
                OpcionSeleccionada?.Invoke("Despedida");
            else if (tecla == 'x' || tecla == 'X')
                Environment.Exit(0);
            else
                Console.WriteLine("Opción inválida");
        }
    }

    public static class Ejercicio9
    {
        public static void Ejecutar()
        {
            Menu menu = new();

            menu.OpcionSeleccionada += opcion =>
            {
                if (opcion == "Saludo")
                    Console.WriteLine("¡Hola! Has seleccionado Saludo.");
                else if (opcion == "Despedida")
                    Console.WriteLine("¡Adiós! Has seleccionado Despedida.");
            };

            while (true)
            {
                menu.MostrarMenu();
                Console.WriteLine();
            }
        }
    }
}
