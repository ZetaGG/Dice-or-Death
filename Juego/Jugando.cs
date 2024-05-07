using System;
using Datos;

namespace Juego
{
    public class Partidas{
         public static void IniciarNuevaPartida()
        {
           
             GameState state = new GameState();
            
           
            Console.WriteLine("Iniciando nueva partida...");
            Console.ReadKey();

            
        }
    
        public static void IniciarJuego(Datos.GameState state)
        {
            Console.WriteLine("Iniciando juego...");
            Console.ReadKey();
        }
    }
   
}