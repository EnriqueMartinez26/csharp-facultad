namespace GestionEmpleados.Lib.Modelos
{
    public class Operario : IntEmpleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Turno { get; set; }

        public Operario() { }

        public Operario(string nombre, string apellido, int edad, string turno)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Turno = turno;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Operario: {Nombre} {Apellido}, Edad: {Edad}, Turno: {Turno}");
        }
    }
}
