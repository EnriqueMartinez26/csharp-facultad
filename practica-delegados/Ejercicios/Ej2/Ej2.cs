using System;

namespace Ejercicios.Ej2
{
    public delegate int Operacion(int a, int b);

    public static class Ejercicio2
    {
        private static int Sumar(int x, int y) => x + y;
        private static int Restar(int x, int y) => x - y;
        private static int Multiplicar(int x, int y) => x * y;

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese el primer número:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Operacion op = Sumar;
            Console.WriteLine($"Suma: {num1} + {num2} = {op(num1, num2)}");

            op = Restar;
            Console.WriteLine($"Resta: {num1} - {num2} = {op(num1, num2)}");

            op = Multiplicar;
            Console.WriteLine($"Multiplicación: {num1} * {num2} = {op(num1, num2)}");
        }
    }
}
