using System;

namespace Ejercicios.Ej5
{
    public delegate void Saludo();

    public static class Ejercicio5
    {
        private static void DecirHola()
        {
            Console.WriteLine("Hola");
        }

        private static void DecirBienvenido()
        {
            Console.WriteLine("¡Bienvenido!");
        }

        public static void Ejecutar()
        {
            Saludo saludo = DecirHola;
            saludo += DecirBienvenido;
            saludo();
        }
    }
}
