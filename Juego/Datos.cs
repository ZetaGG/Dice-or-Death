using System.Text.Json.Serialization;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using Juego;

namespace Datos
{
    [Serializable]
    public class GameState
    {
        public int Vidas { get; set; }
        public string Nombre { get; set; }
        public int Turnos { get; set; }
        public int Comodines { get; set; }
        public int Puntos { get; set; }

        public int x { get; set; }

        public GameState()
        {
            Nombre = "Nombre";
            Vidas = 10;
            Turnos = 0;
            Comodines = 3;
            Puntos = 0;
        }
    }

    public class Game
    {
        public static void SaveGame(GameState state)
        {
            string saveFilePath = $"{state.Nombre}_game_save.dat";

            try
            {
                using (FileStream stream = new FileStream(saveFilePath, FileMode.OpenOrCreate))
                {
                    System.Text.Json.JsonSerializer.Serialize(stream, state);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar la partida: " + e.Message);
                // Manejar el error de forma adecuada (mostrar mensaje al usuario, etc.)
            }
        }

        public static void BorrarPartida(GameState state)
        {
            try
            {
                string saveFilePath = $"{state.Nombre}_game_save.dat";
                File.Delete(saveFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al borrar la partida: " + e.Message);
                // Manejar el error de forma adecuada (mostrar mensaje al usuario, etc.)
            }
        }

        public static void CargarPartida()
        {
            Console.WriteLine("Ingrese el nombre del jugador para cargar la partida:");
            string nombreJugador = Console.ReadLine();
            string saveFilePath = $"{nombreJugador}_game_save.dat";

            GameState state = null;

            try
            {
                if (File.Exists(saveFilePath))
                {
                    using (FileStream stream = new FileStream(saveFilePath, FileMode.Open))
                    {
                        state = System.Text.Json.JsonSerializer.Deserialize<GameState>(stream);
                    }

                    // Iniciar juego con el estado cargado
                    Partidas.IniciarJuego(state);
                }
                else
                {
                    Console.WriteLine("No hay partida guardada para el jugador especificado. Iniciando una nueva partida...");
                    Console.ReadKey();
                    Console.Clear();
                    Partidas.IniciarNuevaPartida();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar la partida: " + e.Message);
                // Manejar el error de forma adecuada (mostrar mensaje al usuario, etc.)
            }
        }
    }
}
