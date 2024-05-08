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

            Console.Write("Dice Or Death");
            

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(@$"
            
    1.Jugar
    2.Cargar Partida
    3.Creditos
    4.Salir");

           
            int opcion = 0;
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                
                goto Seleccion;
            }
            

            switch (opcion)
                {
                    
                    case 1:
                        Console.Clear();
                        Juego.Partidas.IniciarNuevaPartida();
                        goto Seleccion;
                    case 2:
                        Console.Clear();
                        Datos.Game.CargarPartida();
                        goto Seleccion;
                    case 3:
                        Console.Clear();
                        Fonts.ConsoleUtils.Escribir(15,@$"
        Desarrollado por:
        Zeta y Evergaster
    
        Nombres reales:
    Jose Martin Moreno Hernandez
      Everardo Garcia Romero

        Desarrollado en:
        Visual Studio Code

        Inspiraciones:
           Unlikeil
        
    Este proyecto fue creado
       para la siguiente
           materia:
     Programacion Orientada
          a Objetos

    
    ");
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