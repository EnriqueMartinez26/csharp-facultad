using PracticaPoo.Lib.Modelos;

namespace PracticaPoo.Lib.Managers
{
    public class CalculadoraManager
    {
        public void EjecutarCalculadora()
        {
            System.Console.WriteLine("\n--- Prueba de Calculadora ---");
            System.Console.Write("Ingrese primer nÃºmero: ");
            double num1 = Convert.ToDouble(System.Console.ReadLine());
            
            System.Console.Write("Ingrese segundo nÃºmero: ");
            double num2 = Convert.ToDouble(System.Console.ReadLine());

            System.Console.WriteLine($"Suma: {Calculadora.Sumar((int)num1, (int)num2)}");
            System.Console.WriteLine($"Resta: {Calculadora.Restar((int)num1, (int)num2)}");
            System.Console.WriteLine($"MultiplicaciÃ³n: {Calculadora.Multiplicar((int)num1, (int)num2)}");
            System.Console.WriteLine($"DivisiÃ³n: {Calculadora.Dividir((int)num1, (int)num2)}");
        }
    }
}
