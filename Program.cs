using System;
using Fonts;
using Juego;

namespace KillerCard
{
    class Program
    {
           

        
        static void Main(string[] args)
        {
            

            Fonts.ConsoleUtils.MasFontSize();
            
            

            Seleccion:
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
                                Juego.Juego.Jugar();
                                break;
                            case 2:
                                Console.Clear();
                                Juego.Juego.CargarPartida();
                                break;
                            case 3:
                                Console.Clear();
                                Juego.Juego.Creditos();
                                break;
                            case 4:
                                Console.Clear();
                                Juego.Juego.Salir();
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