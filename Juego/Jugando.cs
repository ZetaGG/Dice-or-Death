using System;
using Datos;

namespace Juego
{
    public class Partidas{
         public static void IniciarNuevaPartida()
        {
           
             GameState state = new GameState();
            
            Random random = new Random();

            for(state.x = 10; state.x >= state.Turnos; state.x--)
            {

                if(state.x==0){
                    Console.WriteLine("Perdiste la vida");
                    Console.ReadKey();
                    return;
                }
                 if(state.Puntos==10){
                    Console.WriteLine("Has ganado");
                    Console.ReadKey();
                    return;
                }
                bool comodines = true;
                int numerodado = random.Next(1, 6);
                int numerodado2 =random.Next(1, 6);
                int numerodado3 =random.Next(1, 6);


                Pantalla:

                Console.Clear();
                Console.WriteLine($"Vidas: {state.Vidas}  Turno: {state.x} Comodines: {state.Comodines} Puntos: {state.Puntos} \n ");
                Console.WriteLine($"Numeros requeridos: {numerodado} {numerodado2} {numerodado3}\n");
                Console.WriteLine(@$"
                Ingrese 1 para tirar los dados
                Ingrese 2 para usar un comodin
                Ingrese 3 para guardar y salir
                Ingrese 4 para salir sin guardar");
                try{
                int opcion = int.Parse(Console.ReadLine());

                 switch (opcion) {
                    case 1:

                        int dado1 = random.Next(1, 6);
                        int dado2 = random.Next(1, 6);
                       
                        Console.WriteLine($"Tirando dados... {dado1} {dado2}");

                        if(dado1==numerodado && dado1==numerodado2 && dado1==numerodado3||dado2==numerodado && dado2==numerodado2 && dado2==numerodado3){
                            Console.WriteLine("Has acertado tres números!");
                            state.Puntos+=3;
                        }
                        else if(dado1==numerodado && dado1==numerodado2 ||dado1==numerodado && dado1==numerodado3|| dado1==numerodado2 && dado1==numerodado3)
                        {
                            Console.WriteLine("Has acertado dos números!");
                            state.Puntos+=2;
                        }
                        else if(dado2==numerodado && dado2==numerodado2 ||dado2==numerodado && dado2==numerodado3|| dado2==numerodado2 && dado2==numerodado3)
                        {
                            Console.WriteLine("Has acertado dos números!");
                            state.Puntos+=2;
                        }
                        else if (dado1 == numerodado || dado2 == numerodado )
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
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"1 punto extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            break;
                                        case 2:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"1 Turno extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x++;
                                            break;
                                        case 3:
                                         Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"2 puntos extra");
                                            Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            state.Puntos++;
                                            break;
                                        case 4:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"1 punto menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos--;
                                            break;
                                        case 5:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"1 turno menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x--;
                                            break;
                                        case 6:Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"Perdiste este comodin");
                                              Console.ForegroundColor=ConsoleColor.White;
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
                    Datos.Game.BorrarPartida();
                    Datos.Game.SaveGame(state);
                    Console.ReadKey();
                    return;

                    case 4:
                    return;

                    default:
                    
                    goto Pantalla;

                }

                }


                catch (Exception e){

                    
                    goto Pantalla;
                }

                
               
            }

            
        }
    
        public static void IniciarJuego(Datos.GameState state)
        {
            Random random = new Random();

            for(state.x = state.x; state.x >= state.Turnos; state.x--)
            {
                if(state.x==0){
                    Console.WriteLine("Perdiste la vida");
                    Console.ReadKey();
                    return;
                }
                 if(state.Puntos==10){
                    Console.Clear();
                    Console.WriteLine("Has ganado");
                    Console.ReadKey();
                    Datos.Game.BorrarPartida();
                    return;
                }

                bool comodines = true;
                int numerodado = random.Next(1, 6);
                int numerodado2 =random.Next(1, 6);
                int numerodado3 =random.Next(1, 6);


                Pantalla:

                Console.Clear();
                Console.WriteLine($"Vidas: {state.Vidas}  Turno: {state.x} Comodines: {state.Comodines} Puntos: {state.Puntos} \n ");
                Console.WriteLine($"Numeros requeridos: {numerodado} {numerodado2} {numerodado3}\n");
                Console.WriteLine(@$"
                Ingrese 1 para tirar los dados
                Ingrese 2 para usar un comodin
                Ingrese 3 para guardar y salir
                Ingrese 4 para salir sin guardar");

                try{
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 1:

                        int dado1 = random.Next(1, 6);
                        int dado2 = random.Next(1, 6);
                       
                        Console.WriteLine($"Tirando dados... {dado1} {dado2}");

                        if(dado1==numerodado && dado1==numerodado2 && dado1==numerodado3||dado2==numerodado && dado2==numerodado2 && dado2==numerodado3){
                            Console.WriteLine("Has acertado tres números!");
                            state.Puntos+=3;
                        }
                        else if(dado1==numerodado && dado1==numerodado2 ||dado1==numerodado && dado1==numerodado3|| dado1==numerodado2 && dado1==numerodado3)
                        {
                            Console.WriteLine("Has acertado dos números!");
                            state.Puntos+=2;
                        }
                        else if(dado2==numerodado && dado2==numerodado2 ||dado2==numerodado && dado2==numerodado3|| dado2==numerodado2 && dado2==numerodado3)
                        {
                            Console.WriteLine("Has acertado dos números!");
                            state.Puntos+=2;
                        }
                        else if (dado1 == numerodado || dado2 == numerodado )
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
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"1 punto extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            break;
                                        case 2:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"1 Turno extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x++;
                                            break;
                                        case 3:
                                         Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Console.Write($"2 puntos extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            state.Puntos++;
                                            break;
                                        case 4:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"1 punto menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos--;
                                            break;
                                        case 5:
                                            Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"1 turno menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x--;
                                            break;
                                        case 6:Console.Write($"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Console.Write($"Perdiste este comodin");
                                              Console.ForegroundColor=ConsoleColor.White;
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
                    Datos.Game.BorrarPartida();
                    Datos.Game.SaveGame(state);
                    Console.ReadKey();
                    return;

                    case 4:
                    return;

                    default:
                    
                    goto Pantalla;

                }

                }

                catch(Exception e){
                      goto Pantalla;
                }

                
                
            }
        }
    }
   
}