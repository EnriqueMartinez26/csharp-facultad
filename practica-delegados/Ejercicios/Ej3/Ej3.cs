using System;

namespace Ejercicios.Ej3
{
    public delegate int Operacion(int a, int b);

    public static class Ejercicio3
    {
        private static int Sumar(int x, int y) => x + y;
        private static int Multiplicar(int x, int y) => x * y;

        private static int EjecutarOperacion(int a, int b, Operacion operacion)
        {
            return operacion(a, b);
        }

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese el primer número:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int resultadoSuma = EjecutarOperacion(num1, num2, Sumar);
            Console.WriteLine($"Suma: {num1} + {num2} = {resultadoSuma}");

            int resultadoMultiplicacion = EjecutarOperacion(num1, num2, Multiplicar);
            Console.WriteLine($"Multiplicación: {num1} * {num2} = {resultadoMultiplicacion}");
        }
    }
}
