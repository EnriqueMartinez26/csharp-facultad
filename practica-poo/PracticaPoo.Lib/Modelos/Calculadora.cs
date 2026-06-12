using System;

namespace PracticaPoo.Lib.Modelos
{
    public static class Calculadora
    {
        public static int Sumar(int a, int b) => a + b;
        public static int Restar(int a, int b) => a - b;
        public static int Multiplicar(int a, int b) => a * b;
        public static int Dividir(int a, int b)
        {
            if (b == 0)
            {
                System.Console.WriteLine("No se puede dividir por cero.");
                return 0;
            }
            return a / b;
        }
    }
}
