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
        public int Turnos { get; set; }
        public int Comodines { get; set; }
        public int Puntos { get; set; }

        public int x { get; set; }

        public GameState()
        {
            Vidas = 10;
            Turnos = 0;
            Comodines = 3;
            Puntos = 0;
        }
        

        
    }

    class Game
    {
    private static string saveFilePath = "game_save.dat";

    public static void SaveGame(GameState state)
    {
        using (FileStream stream = new FileStream(saveFilePath, FileMode.OpenOrCreate))
        {
            System.Text.Json.JsonSerializer.Serialize(stream, state);
        }
    }

    public static void BorrarPartida()
    {
        try
        {
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
                    Console.WriteLine("No hay partida guardada. Iniciando una nueva partida...");
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
