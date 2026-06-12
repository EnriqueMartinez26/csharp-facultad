using System;

namespace Eventos.Ev6
{
    public delegate void LimiteSuperadoHandler(decimal total);

    public class Carrito
    {
        public event LimiteSuperadoHandler? LimiteSuperado;

        private decimal total = 0;
        private bool avisoEnviado;

        public void AgregarProducto(decimal precio)
        {
            total += precio;
            if (!avisoEnviado && total > 5000)
            {
                avisoEnviado = true;
                OnLimiteSuperado(total);
            }
        }

        private void OnLimiteSuperado(decimal total)
        {
            LimiteSuperado?.Invoke(total);
        }
    }

    public static class Ejercicio6
    {
        public static void Ejecutar()
        {
            Carrito carrito = new();
            carrito.LimiteSuperado += total =>
            {
                Console.WriteLine($"Total ${total} supero $5000. Tienes un descuento especial.");
            };

            while (true)
            {
                Console.Write("Ingrese precio del producto (x para salir): ");
                string entrada = Console.ReadLine() ?? "";
                if (entrada.ToLower() == "x")
                    break;

                if (decimal.TryParse(entrada, out decimal precio))
                    carrito.AgregarProducto(precio);
                else
                    Console.WriteLine("Precio invalido");
            }
        }
    }
}
