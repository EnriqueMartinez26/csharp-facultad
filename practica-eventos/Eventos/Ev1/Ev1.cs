using System;
using System.Threading;

namespace Eventos.Ev1
{
    public delegate void SegundoPasadoHandler(int segundos);

    public class Reloj
    {
        public event SegundoPasadoHandler? SegundoPasado;
        private readonly System.Timers.Timer timer;
        private int contador = 0;
        private bool detenido;

        public Reloj()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) => OnSegundoPasado(++contador);
            timer.Start();
        }

        public void Detener()
        {
            if (detenido)
                return;

            detenido = true;
            timer.Stop();
            timer.Dispose();
        }

        private void OnSegundoPasado(int segundos)
        {
            if (detenido)
                return;

            SegundoPasado?.Invoke(segundos);
        }
    }

    public static class Ejercicio1
    {
        public static void Ejecutar()
        {
            using ManualResetEventSlim finalizado = new(false);
            Reloj reloj = new();

            reloj.SegundoPasado += segundos =>
            {
                Console.WriteLine($"Segundos transcurridos: {segundos}");
                if (segundos >= 10)
                {
                    reloj.Detener();
                    finalizado.Set();
                }
            };

            finalizado.Wait();
        }
    }
}
