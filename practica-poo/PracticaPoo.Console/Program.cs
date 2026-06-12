using PracticaPoo.Lib.Managers;

namespace PracticaPoo.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuManager menuManager = new();
            
            while (true)
            {
                menuManager.MostrarMenu();
                string? opcion = System.Console.ReadLine();
                menuManager.ProcesarOpcion(opcion ?? string.Empty);
            }
        }
    }
}
