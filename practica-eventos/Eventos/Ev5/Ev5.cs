using System;
using System.Threading;

namespace Eventos.Ev5
{
    public delegate void ProgresoHandler(int porcentaje);

    public class Descarga
    {
        public event ProgresoHandler? ProgresoActualizado;

        public void IniciarDescarga()
        {
            for (int i = 10; i <= 100; i += 10)
            {
                Thread.Sleep(500);
                OnProgresoActualizado(i);
            }
        }

        private void OnProgresoActualizado(int porcentaje)
        {
            ProgresoActualizado?.Invoke(porcentaje);
        }
    }

    public static class Ejercicio5
    {
        public static void Ejecutar()
        {
            Descarga descarga = new();
            descarga.ProgresoActualizado += porcentaje =>
            {
                Console.WriteLine($"Descarga {porcentaje}% completada");
            };

            descarga.IniciarDescarga();
        }
    }
}
