using System;
using Fonts;
using Juego;
using Datos;

namespace KillerCard
{
    class Program
    {
           

        
        static void Main(string[] args)
        {
            

            Fonts.ConsoleUtils.MasFontSize();
            Console.ResetColor();
            
            

            Seleccion:
            Console.Clear();
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Killer Card");
            

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(@$"
            
    1.Jugar
    2.Cargar Partida
    3.Creditos
    4.Salir");

           
            int opcion = 0;
            
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
                {
                    
                    case 1:
                        Console.Clear();
                        Juego.Partidas.IniciarNuevaPartida();
                        break;
                    case 2:
                        Console.Clear();
                        Datos.Game.CargarPartida();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Hola");
                        Console.ReadKey();
                        goto Seleccion;
                    case 4:
                        Console.Clear();
                        
                        break;
                    default:
                        
                        Console.WriteLine("Opcion no valida");
                        Console.ReadKey();
                        Console.Clear();
                        

                        goto Seleccion;
                }
        }
    }
}