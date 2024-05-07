using System;
using Datos;

namespace Juego
{
    public class Partidas{
         public static void IniciarNuevaPartida()
        {
           
             GameState state = new GameState();
            
            Random random = new Random();

            for(int x = 10; x <= state.Turnos; x--)
            {
                 bool comodines = true;


                int numerodado = random.Next(1, 6);
                int numerodado2 =random.Next(1, 6);
                int numerodado3 =random.Next(1, 6);
                Console.WriteLine($"Vidas: {state.Vidas}  Turno: {x} Comodines: {state.Comodines} Puntos: {state.Puntos} \n ");
                Console.WriteLine($"Numeros requeridos: {numerodado} {numerodado2} {numerodado3}\n");
                Console.WriteLine(@$"
                Ingrese 1 para tirar los dados
                Ingrese 2 para usar un comodin
                Ingrese 3 para guardar y salir");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 1:
                        int dado1 = random.Next(1, 6);
                        int dado2 = random.Next(1, 6);
                        int dado3 = random.Next(1, 6);
                        Console.WriteLine($"Tirando dados... {dado1} {dado2} {dado3}");
                        if (dado1 == numerodado || dado2 == numerodado || dado3 == numerodado)
                        {
                            Console.WriteLine("Has acertado el primer número!");
                            state.Puntos++;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("No has acertado los números requeridos.");
                            state.Vidas--;
                        }
                        break;
                    case 2:
                            if (comodines == true){
                            
                                if (state.Comodines > 0)
                                {
                                    int dado = random.Next(1, 6);
                                    Console.WriteLine("Usando comodín...");

                                    switch (dado){
                                        
                                    }

                                    state.Comodines--;
                                    comodines=false;

                                }
                                else
                                {
                                    Console.WriteLine("No tienes comodines disponibles.");
                                }
                            }
                            else{
                                Console.WriteLine("Ya has usado un comodín.");
                            }
                        break;
                }
            }

            
        }
    
        public static void IniciarJuego(Datos.GameState state)
        {
            Console.WriteLine("Iniciando juego...");
            
            Console.ReadKey();
        }
    }
   
}