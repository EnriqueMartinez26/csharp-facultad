using System;

namespace Ejercicios.Ej9
{
    public delegate int Operacion(int a, int b);

    public class Calculadora
    {
        public Operacion? OperacionSeleccionada { get; set; }

        public int Calcular(int a, int b)
        {
            if (OperacionSeleccionada is null)
                throw new InvalidOperationException("No se ha asignado una operacion.");

            return OperacionSeleccionada(a, b);
        }
    }

    public static class Ejercicio9
    {
        private static int Sumar(int x, int y) => x + y;
        private static int Restar(int x, int y) => x - y;

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese el primer numero:");
            if (!int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.WriteLine("Numero invalido");
                return;
            }

            Console.WriteLine("Ingrese el segundo numero:");
            if (!int.TryParse(Console.ReadLine(), out int num2))
            {
                Console.WriteLine("Numero invalido");
                return;
            }

            Console.WriteLine("Seleccione operacion (sumar/restar):");
            string opcion = Console.ReadLine() ?? "";

            Calculadora calc = new();

            switch (opcion.ToLower())
            {
                case "sumar":
                    calc.OperacionSeleccionada = Sumar;
                    break;
                case "restar":
                    calc.OperacionSeleccionada = Restar;
                    break;
                default:
                    Console.WriteLine("Operacion no valida");
                    return;
            }

            int resultado = calc.Calcular(num1, num2);
            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}
