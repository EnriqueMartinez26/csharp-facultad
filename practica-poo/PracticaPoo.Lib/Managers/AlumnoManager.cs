using PracticaPoo.Lib.Modelos;

namespace PracticaPoo.Lib.Managers
{
    public class AlumnoManager
    {
        private List<Alumno> alumnos = new();

        public void EjecutarMenuAlumnos()
        {
            while (true)
            {
                System.Console.WriteLine("\n=== MenÃº Alumnos ===");
                System.Console.WriteLine("1. Agregar alumno");
                System.Console.WriteLine("2. Listar alumnos");
                System.Console.WriteLine("3. Buscar alumno por nombre");
                System.Console.WriteLine("4. Mostrar promedio general");
                System.Console.WriteLine("5. Volver al menÃº principal");
                System.Console.Write("Seleccione una opciÃ³n: ");

                string? opcion = System.Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        AgregarAlumno();
                        break;
                    case "2":
                        ListarAlumnos();
                        break;
                    case "3":
                        BuscarAlumno();
                        break;
                    case "4":
                        MostrarPromedio();
                        break;
                    case "5":
                        return;
                    default:
                        System.Console.WriteLine("OpciÃ³n no vÃ¡lida");
                        break;
                }
            }
        }

        private void AgregarAlumno()
        {
            Alumno alumno = new();
            System.Console.Write("Ingrese nombre del alumno: ");
            alumno.Nombre = System.Console.ReadLine() ?? string.Empty;
            System.Console.Write("Ingrese nota del alumno: ");
            if (double.TryParse(System.Console.ReadLine(), out double nota))
            {
                alumno.Nota = nota;
                alumnos.Add(alumno);
                System.Console.WriteLine("Alumno agregado correctamente.");
            }
            else
            {
                System.Console.WriteLine("Nota invÃ¡lida.");
            }
        }

        private void ListarAlumnos()
        {
            if (alumnos.Count == 0)
            {
                System.Console.WriteLine("No hay alumnos registrados.");
                return;
            }

            System.Console.WriteLine("\nLista de Alumnos:");
            foreach (var alumno in alumnos)
            {
                alumno.MostrarDatos();
            }
        }

        private void BuscarAlumno()
        {
            System.Console.Write("Ingrese el nombre a buscar: ");
            string nombre = System.Console.ReadLine() ?? string.Empty;
            
            var encontrados = alumnos.Where(a => a.CoincideNombre(nombre)).ToList();
            
            if (encontrados.Any())
            {
                System.Console.WriteLine("\nAlumnos encontrados:");
                foreach (var alumno in encontrados)
                {
                    alumno.MostrarDatos();
                }
            }
            else
            {
                System.Console.WriteLine("No se encontraron alumnos con ese nombre.");
            }
        }

        private void MostrarPromedio()
        {
            if (alumnos.Count == 0)
            {
                System.Console.WriteLine("No hay alumnos registrados.");
                return;
            }

            double promedio = Alumno.CalcularPromedio(alumnos);
            System.Console.WriteLine($"El promedio general es: {promedio:F2}");
        }
    }
}
