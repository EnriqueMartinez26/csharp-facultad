using PracticaPoo.Lib.Modelos;
using PracticaPoo.Lib.Managers;

namespace PracticaPoo.Lib.Managers
{
    public class MenuManager
    {
        public void MostrarMenu()
        {
            Console.WriteLine("\n=== MenÃº Principal ===");
            Console.WriteLine("1. Ejecutar Calculadora");
            Console.WriteLine("2. Ejecutar Usuario");
            Console.WriteLine("3. Ejecutar GestiÃ³n de Alumnos");
            Console.WriteLine("4. Ejecutar Prueba de Personas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opciÃ³n: ");
        }

        public void ProcesarOpcion(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    new CalculadoraManager().EjecutarCalculadora();
                    break;
                case "2":
                    new UsuarioManager().EjecutarUsuario();
                    break;
                case "3":
                    new AlumnoManager().EjecutarMenuAlumnos();
                    break;
                case "4":
                    EjecutarPruebaPersonas();
                    break;
                case "5":
                    Console.WriteLine("Â¡Hasta luego!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("OpciÃ³n no vÃ¡lida");
                    break;
            }
        }

        private void EjecutarPruebaPersonas()
        {
            Console.WriteLine("\n--- Prueba de Personas ---");

            List<Persona> personas = new()
            {
                new Persona { Nombre = "Juan", Edad = 25 },
                new Persona { Nombre = "Ana", Edad = 30 },
                new Persona { Nombre = "Pedro", Edad = 35 }
            };

            foreach (var persona in personas)
            {
                persona.Saludar();
            }

            Console.WriteLine($"\nTotal de personas creadas: {Persona.ObtenerTotal()}");
        }
    }
}
