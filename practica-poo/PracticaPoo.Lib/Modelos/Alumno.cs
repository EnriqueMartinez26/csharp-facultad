namespace PracticaPoo.Lib.Modelos
{
    public class Alumno
    {
        public string Nombre { get; set; } = string.Empty;
        public double Nota { get; set; }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}, Nota: {Nota}");
        }

        public bool CoincideNombre(string busqueda)
        {
            return Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase);
        }

        public static double CalcularPromedio(List<Alumno> alumnos)
        {
            return alumnos.Count > 0 ? alumnos.Average(a => a.Nota) : 0;
        }
    }
}

