using System;

namespace Ejercicios.Ej1
{
    public delegate int Operacion(int a, int b);

    public static class Ejercicio1
    {
        private static int Sumar(int x, int y)
        {
            return x + y;
        }

        public static void Ejecutar()
        {
            if (!LeerEntero("Ingrese el primer numero:", out int num1))
                return;

            if (!LeerEntero("Ingrese el segundo numero:", out int num2))
                return;

            Operacion operacion = Sumar;
            int resultado = operacion(num1, num2);

            Console.WriteLine($"El resultado de sumar {num1} + {num2} es: {resultado}");
        }

        private static bool LeerEntero(string mensaje, out int numero)
        {
            Console.WriteLine(mensaje);
            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Numero invalido.");
                return false;
            }

            return true;
        }
    }
}
