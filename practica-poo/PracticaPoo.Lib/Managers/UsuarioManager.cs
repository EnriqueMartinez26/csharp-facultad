using PracticaPoo.Lib.Modelos;

namespace PracticaPoo.Lib.Managers
{
    public class UsuarioManager
    {
        public void EjecutarUsuario()
        {
            System.Console.WriteLine("\n--- Prueba de Usuario ---");
            
            System.Console.Write("Ingrese nombre de usuario: ");
            Usuario usuario = new Usuario { Nombre = System.Console.ReadLine() ?? string.Empty };
            
            System.Console.Write("Establezca una contraseÃ±a: ");
            string password = System.Console.ReadLine() ?? string.Empty;
            usuario.EstablecerContraseÃ±a(password);
            
            System.Console.Write("\nPara verificar, ingrese la contraseÃ±a nuevamente: ");
            string verificacion = System.Console.ReadLine() ?? string.Empty;
            
            bool esCorrecta = usuario.VerificarContraseÃ±a(verificacion);
            System.Console.WriteLine(esCorrecta 
                ? "\nVerificaciÃ³n exitosa! La contraseÃ±a es correcta." 
                : "\nVerificaciÃ³n fallida! La contraseÃ±a es incorrecta.");
        }
    }
}
