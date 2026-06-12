using Eventos.Ev1;
using Eventos.Ev2;
using Eventos.Ev3;
using Eventos.Ev4;
using Eventos.Ev5;
using Eventos.Ev6;
using Eventos.Ev7;
using Eventos.Ev8;
using Eventos.Ev9;
using Eventos.Ev10;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Menú de ejercicios con eventos ===");
        Console.WriteLine("1. Evento personalizado simple (Reloj)");
        Console.WriteLine("2. Sensor de temperatura");
        Console.WriteLine("3. Varios suscriptores");
        Console.WriteLine("4. Evento con EventArgs");
        Console.WriteLine("5. Simulación de descarga");
        Console.WriteLine("6. Evento y lógica de negocio (Carrito de compras)");
        Console.WriteLine("7. Control de acceso");
        Console.WriteLine("8. Encadenamiento de eventos");
        Console.WriteLine("9. Menú interactivo por consola");
        Console.WriteLine("10. Contador de eventos (Clicks)");
        Console.Write("Seleccione el número de ejercicio: ");
        string opcion = Console.ReadLine() ?? "";

        Console.WriteLine();

        switch (opcion)
        {
            case "1":
                Ejercicio1.Ejecutar();
                break;
            case "2":
                Ejercicio2.Ejecutar();
                break;
            case "3":
                Ejercicio3.Ejecutar();
                break;
            case "4":
                Ejercicio4.Ejecutar();
                break;
            case "5":
                Ejercicio5.Ejecutar();
                break;
            case "6":
                Ejercicio6.Ejecutar();
                break;
            case "7":
                Ejercicio7.Ejecutar();
                break;
            case "8":
                Ejercicio8.Ejecutar();
                break;
            case "9":
                Ejercicio9.Ejecutar();
                break;
            case "10":
                Ejercicio10.Ejecutar();
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
    }
}
