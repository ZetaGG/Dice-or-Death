using System;
using Datos;

namespace Juego
{
    public class Partidas{
         public static void IniciarNuevaPartida()
        {
           
             GameState state = new GameState();
            
            Random random = new Random();

            for(int x = 10; x >= state.Turnos; x--)
            {
                bool comodines = true;
                int numerodado = random.Next(1, 6);
                int numerodado2 =random.Next(1, 6);
                int numerodado3 =random.Next(1, 6);


                Pantalla:

                Console.Clear();
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
                       
                        Console.WriteLine($"Tirando dados... {dado1} {dado2}");
                        if (dado1 == numerodado || dado2 == numerodado )
                        {
                            Console.WriteLine("Has acertado el primer número!");
                            state.Puntos++;
                           
                        }
                        else if (dado1 == numerodado2 || dado2 == numerodado2 ){
                            Console.WriteLine("Has acertado el segundo número!");
                            state.Puntos++;
                            
                        }

                        else if (dado1 == numerodado3 || dado2 == numerodado3 )
                        {
                            Console.WriteLine("Has acertado el tercer número!");
                            state.Puntos++;
                            
                        }
                        
                        else
                        {
                            Console.WriteLine("No has acertado los números requeridos.");
                            state.Vidas--;
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                            if (comodines == true){
                            
                                if (state.Comodines > 0)
                                {
                                    int dado = random.Next(1, 6);
                                    Console.WriteLine("Usando comodín...");

                                //* Switch Comodines
                                    switch (dado){
                                        case 1:
                                            Console.WriteLine($"Numero {dado} 1 punto extra");
                                            state.Puntos++;
                                            break;
                                        case 2:
                                            Console.WriteLine($"Numero {dado} 1 turno extra");
                                            x++;
                                            break;
                                        case 3:
                                         Console.WriteLine($"Numero {dado} 2 puntos extra");
                                            state.Puntos++;
                                            state.Puntos++;
                                            break;
                                        case 4:
                                            Console.WriteLine($"Numero {dado} 1 punto menos");
                                            state.Puntos--;
                                            break;
                                        case 5:
                                            Console.WriteLine($"Numero {dado} 1 turno menos");
                                            x--;
                                            break;
                                        case 6:Console.WriteLine($"Numero {dado} perdiste este comodin");
                                            break;

                                    }

                                    Console.ReadKey();
                                    state.Comodines--;
                                    comodines=false;
                                    goto Pantalla;

                                }
                                else
                                {
                                    Console.WriteLine("No tienes comodines disponibles.");
                                    Console.ReadKey();
                                    goto Pantalla;
                                }
                            }
                            else{
                                Console.WriteLine("Ya has usado un comodín.");
                                Console.ReadKey();
                                    goto Pantalla;
                            }
                    case 3:
                    Console.WriteLine("Guardando partida...");
                    Datos.Game.SaveGame(state);
                    Console.ReadKey();
                    return;
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