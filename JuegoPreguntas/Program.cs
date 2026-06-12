using JuegoPreguntas.Services;

class Program
{
    static void Main(string[] args)
    {
        var juego = new JuegoPreguntasService();
        juego.Iniciar();
    }
}
