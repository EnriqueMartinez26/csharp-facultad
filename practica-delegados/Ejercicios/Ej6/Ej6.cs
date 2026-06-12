using System;

namespace Ejercicios.Ej6
{
    public delegate double Operacion(double a, double b);

    public static class Ejercicio6
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese el dividendo:");
            if (!double.TryParse(Console.ReadLine(), out double dividendo))
            {
                Console.WriteLine("Valor inválido");
                return;
            }

            Console.WriteLine("Ingrese el divisor:");
            if (!double.TryParse(Console.ReadLine(), out double divisor) || divisor == 0)
            {
                Console.WriteLine("Divisor inválido o igual a cero");
                return;
            }

            Operacion division = (x, y) => x / y;
            double resultado = division(dividendo, divisor);

            Console.WriteLine($"Resultado de dividir {dividendo} / {divisor} = {resultado}");
        }
    }
}
