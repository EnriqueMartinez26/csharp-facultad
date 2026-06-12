namespace JuegoPreguntas.Models
{
    public class Pregunta
    {
        public string Categoria { get; set; } = null!;
        public string Enunciado { get; set; } = null!;
        public string Respuesta1 { get; set; } = null!;
        public string Respuesta2 { get; set; } = null!;
        public string Respuesta3 { get; set; } = null!;
        public string Respuesta4 { get; set; } = null!;
        public string RespuestaCorrecta { get; set; } = null!;
    }
}
