namespace GestionEmpleados.Lib.Modelos
{
    public interface IntEmpleado
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        int Edad { get; set; }

        void MostrarInformacion();
    }
}
