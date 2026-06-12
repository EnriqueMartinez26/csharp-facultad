using System.Collections.Generic;

namespace JuegoPreguntas.Models
{
    public class Jugador : IJugador
    {
        public string Nombre { get; set; } = string.Empty;
        public int Puntaje { get; set; }
        public List<(Pregunta pregunta, string respuesta, int puntos)> Respuestas { get; set; }

        public Jugador()
        {
            Puntaje = 0;
            Respuestas = new List<(Pregunta, string, int)>();
        }
    }
}
