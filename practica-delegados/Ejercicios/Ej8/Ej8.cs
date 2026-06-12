using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicios.Ej8
{
    public delegate bool Criterio(int numero);

    public static class Ejercicio8
    {
        private static List<int> Filtrar(List<int> numeros, Criterio criterio)
        {
            List<int> resultado = new();
            foreach (int n in numeros)
            {
                if (criterio(n))
                    resultado.Add(n);
            }
            return resultado;
        }

        private static bool EsPar(int n) => n % 2 == 0;
        private static bool EsImpar(int n) => n % 2 != 0;
        private static bool MayorA5(int n) => n > 5;

        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese numeros separados por coma:");
            string entrada = Console.ReadLine() ?? "";

            List<int> numeros = entrada
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();

            Console.WriteLine("Filtrando pares:");
            List<int> pares = Filtrar(numeros, EsPar);
            Console.WriteLine(string.Join(", ", pares));

            Console.WriteLine("Filtrando impares:");
            List<int> impares = Filtrar(numeros, EsImpar);
            Console.WriteLine(string.Join(", ", impares));

            Console.WriteLine("Filtrando mayores a 5:");
            List<int> mayores = Filtrar(numeros, MayorA5);
            Console.WriteLine(string.Join(", ", mayores));
        }
    }
}
