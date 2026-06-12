using System;

namespace Eventos.Ev8
{
    public delegate void MovimientoDetectadoHandler();
    public delegate void LuzEncendidaHandler();

    public class Sensor
    {
        public event MovimientoDetectadoHandler? MovimientoDetectado;

        public void DetectarMovimiento()
        {
            Console.WriteLine("Sensor: Movimiento detectado");
            MovimientoDetectado?.Invoke();
        }
    }

    public class Luz
    {
        public event LuzEncendidaHandler? LuzEncendida;

        public void Encender()
        {
            Console.WriteLine("Luz: Encendida");
            LuzEncendida?.Invoke();
        }
    }

    public static class Ejercicio8
    {
        public static void Ejecutar()
        {
            Sensor sensor = new();
            Luz luz = new();

            sensor.MovimientoDetectado += luz.Encender;
            luz.LuzEncendida += () =>
            {
                Console.WriteLine("Luz: Evento 'LuzEncendida' recibido");
            };

            Console.WriteLine("Presione Enter para simular detección de movimiento (x para salir):");

            while (true)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Enter)
                    sensor.DetectarMovimiento();
                else if (tecla == ConsoleKey.X)
                    break;
            }
        }
    }
}
