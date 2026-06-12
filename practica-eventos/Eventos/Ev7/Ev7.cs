using System;

namespace Eventos.Ev7
{
    public delegate void AccesoDenegadoHandler(string codigo);

    public class Puerta
    {
        public event AccesoDenegadoHandler? AccesoDenegado;
        private readonly string claveCorrecta = "1234";

        public void IntentarAbrir(string codigoIngresado)
        {
            if (codigoIngresado != claveCorrecta)
                AccesoDenegado?.Invoke(codigoIngresado);
            else
                Console.WriteLine("Acceso concedido.");
        }
    }

    public static class Ejercicio7
    {
        public static void Ejecutar()
        {
            Puerta puerta = new();
            puerta.AccesoDenegado += codigo =>
            {
                Console.WriteLine($"Acceso denegado para el código: {codigo}");
            };

            while (true)
            {
                Console.Write("Ingrese código para abrir la puerta (x para salir): ");
                string codigo = Console.ReadLine() ?? "";
                if (codigo.ToLower() == "x")
                    break;

                puerta.IntentarAbrir(codigo);
            }
        }
    }
}
