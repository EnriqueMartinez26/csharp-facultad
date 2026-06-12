using System;

namespace Eventos.Ev4
{
    public class SaldoNegativoEventArgs : EventArgs
    {
        public decimal Saldo { get; set; }
    }

    public delegate void SaldoNegativoHandler(object sender, SaldoNegativoEventArgs e);

    public class Cuenta
    {
        public event SaldoNegativoHandler? SaldoNegativo;

        private decimal saldo = 100;

        public void Retirar(decimal monto)
        {
            saldo -= monto;
            if (saldo < 0)
                OnSaldoNegativo(saldo);
        }

        private void OnSaldoNegativo(decimal saldo)
        {
            SaldoNegativo?.Invoke(this, new SaldoNegativoEventArgs { Saldo = saldo });
        }
    }

    public static class Ejercicio4
    {
        public static void Ejecutar()
        {
            Cuenta cuenta = new();
            cuenta.SaldoNegativo += (sender, e) =>
            {
                Console.WriteLine($"Saldo negativo detectado: ${e.Saldo}");
            };

            while (true)
            {
                Console.Write("Ingrese monto a retirar (x para salir): ");
                string entrada = Console.ReadLine() ?? "";
                if (entrada.ToLower() == "x")
                    break;

                if (decimal.TryParse(entrada, out decimal monto))
                    cuenta.Retirar(monto);
                else
                    Console.WriteLine("Monto inválido");
            }
        }
    }
}
