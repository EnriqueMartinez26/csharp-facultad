namespace GestionEmpleados.Lib.Modelos
{
    public class Gerente : IntEmpleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int EmpleadosACargo { get; set; }

        public Gerente() { }

        public Gerente(string nombre, string apellido, int edad, int empleadosACargo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            EmpleadosACargo = empleadosACargo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Gerente: {Nombre} {Apellido}, Edad: {Edad}, Empleados a cargo: {EmpleadosACargo}");
        }

        public new decimal CalcularSueldo()
        {
            return 150000 + (EmpleadosACargo * 5000);
        }
    }
}
