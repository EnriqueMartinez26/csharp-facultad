namespace PracticaPoo.Lib.Modelos
{
    public class Usuario
    {
        private string contraseÃ±a = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        public void EstablecerContraseÃ±a(string pass)
        {
            contraseÃ±a = pass;
        }

        public bool VerificarContraseÃ±a(string pass)
        {
            return contraseÃ±a == pass;
        }
    }
}
