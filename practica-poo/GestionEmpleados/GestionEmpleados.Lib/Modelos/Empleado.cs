namespace GestionEmpleados.Lib.Modelos
{
    public class Empleado : IntEmpleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Empleado()
        {
            Nombre = "Sin nombre";
            Apellido = "Sin apellido";
            Edad = 0;
        }

        public Empleado(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Empleado: {Nombre} {Apellido}, Edad: {Edad}");
        }
    }
}
