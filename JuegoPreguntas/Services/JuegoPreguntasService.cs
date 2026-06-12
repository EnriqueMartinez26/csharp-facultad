using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using JuegoPreguntas.Models;

namespace JuegoPreguntas.Services
{
    public class JuegoPreguntasService
    {
        private readonly List<Pregunta> todasPreguntas;
        private readonly Random rnd;

        public JuegoPreguntasService()
        {
            rnd = new Random();
            todasPreguntas = CargarPreguntas();
        }

        private List<Pregunta> CargarPreguntas()
        {
            var ruta = Path.Combine(AppContext.BaseDirectory, "Data", "preguntas.json");
            if (!File.Exists(ruta))
            {
                Console.WriteLine($"ERROR: No se encuentra el archivo de preguntas en {ruta}");
                return new List<Pregunta>();
            }

            try
            {
                var json = File.ReadAllText(ruta);
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<List<Pregunta>>(json, opciones) ?? new List<Pregunta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR al leer el archivo JSON: " + ex.Message);
                return new List<Pregunta>();
            }
        }

        public void Iniciar()
        {
            Console.WriteLine("Bienvenido al juego de Preguntas y Respuestas");
            Console.Write("Ingrese su nombre: ");
            var nombre = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
                nombre = "Jugador";
            var jugador = new Jugador { Nombre = nombre };

            Console.WriteLine($"\nHola, {jugador.Nombre}. Vamos a jugar 5 rondas.\n");

            var categorias = todasPreguntas.Select(p => p.Categoria).Distinct().ToList();

            for (int ronda = 1; ronda <= 5; ronda++)
            {
                Console.WriteLine($"\n--- Ronda {ronda} ---");
                Console.Write("Presione Enter para lanzar el dado...");
                Console.ReadLine();

                int dado = rnd.Next(1, 7);
                string categoria = categorias.Count >= 6
                    ? categorias[(dado - 1) % categorias.Count]
                    : categorias[rnd.Next(categorias.Count)];

                Console.WriteLine($"Dado: {dado} → Categoría: {categoria}");

                var preguntasCategoria = todasPreguntas
                    .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (!preguntasCategoria.Any())
                {
                    Console.WriteLine("No hay preguntas disponibles en esta categoría. Se saltea esta ronda.");
                    continue;
                }

                var pregunta = preguntasCategoria[rnd.Next(preguntasCategoria.Count)];
                var opciones = new List<string> { pregunta.Respuesta1, pregunta.Respuesta2, pregunta.Respuesta3, pregunta.Respuesta4 };
                var opcionesMezcladas = opciones.OrderBy(_ => rnd.Next()).ToList();

                bool respondido = false;
                int intento = 1;

                while (!respondido && intento <= 2)
                {
                    Console.WriteLine($"\n{pregunta.Enunciado}");
                    for (int i = 0; i < opcionesMezcladas.Count; i++)
                        Console.WriteLine($"{i + 1}. {opcionesMezcladas[i]}");

                    Console.Write($"Intento {intento}. Elija su respuesta (1-4): ");
                    string input = Console.ReadLine()?.Trim();

                    if (int.TryParse(input, out int eleccion) && eleccion >= 1 && eleccion <= 4)
                    {
                        string respuesta = opcionesMezcladas[eleccion - 1];
                        if (respuesta.Equals(pregunta.RespuestaCorrecta, StringComparison.OrdinalIgnoreCase))
                        {
                            int puntos = intento == 1 ? 2 : 1;
                            jugador.Puntaje += puntos;
                            jugador.Respuestas.Add((pregunta, respuesta, puntos));
                            Console.WriteLine($"¡Correcto! Ganaste {puntos} punto(s).");
                            respondido = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrecto.");
                            if (intento == 2)
                            {
                                jugador.Respuestas.Add((pregunta, respuesta, 0));
                                Console.WriteLine($"Respuesta correcta: {pregunta.RespuestaCorrecta}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                        if (intento == 2)
                        {
                            jugador.Respuestas.Add((pregunta, "", 0));
                            Console.WriteLine($"Respuesta correcta: {pregunta.RespuestaCorrecta}");
                        }
                    }

                    intento++;
                }
            }

            MostrarResultado(jugador);
        }

        private void MostrarResultado(Jugador jugador)
        {
            Console.WriteLine("\n=== RESULTADO FINAL ===");
            Console.WriteLine($"Jugador: {jugador.Nombre}");
            Console.WriteLine($"Puntaje total: {jugador.Puntaje}\n");

            int i = 1;
            foreach (var (pregunta, respuesta, puntos) in jugador.Respuestas)
            {
                string estado = puntos > 0 ? "✔️" : "❌";
                Console.WriteLine($"{i}. [{pregunta.Categoria}] {pregunta.Enunciado}");
                Console.WriteLine($"   Tu respuesta: {(string.IsNullOrEmpty(respuesta) ? "(ninguna)" : respuesta)} {estado} ({puntos} pts)");
                i++;
            }

            Console.WriteLine();

            if (jugador.Puntaje >= 8)
                Console.WriteLine("🎉 ¡Excelente! Obtuviste el premio mayor.");
            else if (jugador.Puntaje >= 4)
                Console.WriteLine("👍 Buen trabajo. Recibís un premio intermedio.");
            else
                Console.WriteLine("💪 ¡No te rindas! Seguí practicando.");

            Console.WriteLine("\nGracias por jugar.");
        }
    }
}
