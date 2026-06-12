using System;

namespace Eventos.Ev3
{
    public delegate void ClickHandler();

    public class Boton
    {
        public event ClickHandler? AlHacerClick;

        public void HacerClick()
        {
            AlHacerClick?.Invoke();
        }
    }

    public class Receptor1
    {
        public void Responder()
        {
            Console.WriteLine("Receptor 1: Se hizo clic en el botón");
        }
    }

    public class Receptor2
    {
        public void Reaccionar()
        {
            Console.WriteLine("Receptor 2: Click detectado");
        }
    }

    public static class Ejercicio3
    {
        public static void Ejecutar()
        {
            Boton boton = new();
            Receptor1 r1 = new();
            Receptor2 r2 = new();

            boton.AlHacerClick += r1.Responder;
            boton.AlHacerClick += r2.Reaccionar;

            Console.WriteLine("Presione Enter para simular un click (x para salir):");

            while (true)
            {
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Enter)
                    boton.HacerClick();
                else if (tecla == ConsoleKey.X)
                    break;
            }
        }
    }
}
