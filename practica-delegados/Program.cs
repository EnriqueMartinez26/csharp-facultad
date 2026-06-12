using Ejercicios.Ej1;
using Ejercicios.Ej2;
using Ejercicios.Ej3;
using Ejercicios.Ej4;
using Ejercicios.Ej5;
using Ejercicios.Ej6;
using Ejercicios.Ej7;
using Ejercicios.Ej8;
using Ejercicios.Ej9;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Menú de ejercicios con delegados ===");
        Console.WriteLine("1. Delegado básico");
        Console.WriteLine("2. Varios métodos con el mismo delegado");
        Console.WriteLine("3. Delegado como parámetro de un método");
        Console.WriteLine("4. Delegado con void");
        Console.WriteLine("5. Multicast de métodos");
        Console.WriteLine("6. Expresión lambda con delegado");
        Console.WriteLine("7. Formateador de texto con delegado");
        Console.WriteLine("8. Filtro con delegado");
        Console.WriteLine("9. Delegado como propiedad");
        Console.Write("Seleccione el número de ejercicio: ");
        string opcion = Console.ReadLine() ?? string.Empty;

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
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
    }
}
