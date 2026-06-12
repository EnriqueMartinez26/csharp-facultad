
using GestionEmpleados.Lib.Modelos;

List<IntEmpleado> empleados = new()
{
    new Administrativo("Mauricio", "Pérez", 30, "Recursos Humanos"),
    new Gerente("Javier", "Gómez", 45, 10),
    new Operario("Sergio", "Ruiz", 25, "Turno noche")
};

foreach (IntEmpleado emp in empleados)
{
    emp.MostrarInformacion();
}
