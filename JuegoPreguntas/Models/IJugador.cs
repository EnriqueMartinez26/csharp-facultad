using System.Collections.Generic;

namespace JuegoPreguntas.Models
{
    public interface IJugador
    {
        string Nombre { get; set; }
        int Puntaje { get; set; }
        List<(Pregunta pregunta, string respuesta, int puntos)> Respuestas { get; set; }
    }
}
