using System;

namespace Eventos.Ev2
{
    public delegate void TemperaturaExcedidaHandler(double valor);

    public class Sensor
    {
        public event TemperaturaExcedidaHandler? TemperaturaExcedida;
        private readonly double umbral = 37.0;

        public void LeerTemperatura(double nuevaTemperatura)
        {
            if (nuevaTemperatura > umbral)
                OnTemperaturaExcedida(nuevaTemperatura);
        }

        private void OnTemperaturaExcedida(double valor)
        {
            TemperaturaExcedida?.Invoke(valor);
        }
    }

    public static class Ejercicio2
    {
        public static void Ejecutar()
        {
            Sensor sensor = new();
            sensor.TemperaturaExcedida += valor =>
            {
                Console.WriteLine($"¡Temperatura excedida! Valor: {valor}°C");
            };

            while (true)
            {
                Console.Write("Ingrese temperatura (o 'x' para salir): ");
                string entrada = Console.ReadLine() ?? "";
                if (entrada.ToLower() == "x")
                    break;

                if (double.TryParse(entrada, out double temp))
                    sensor.LeerTemperatura(temp);
                else
                    Console.WriteLine("Temperatura inválida");
            }
        }
    }
}
