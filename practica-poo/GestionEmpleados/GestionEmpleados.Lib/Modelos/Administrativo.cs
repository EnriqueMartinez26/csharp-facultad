namespace GestionEmpleados.Lib.Modelos
{
    public class Administrativo : IntEmpleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Area { get; set; }

        public Administrativo() { }

        public Administrativo(string nombre, string apellido, int edad, string area)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Area = area;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Administrativo: {Nombre} {Apellido}, Edad: {Edad}, Área: {Area}");
        }
    }
}
