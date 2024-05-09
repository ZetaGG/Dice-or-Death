using System;
using Datos;
using Fonts;

namespace Juego
{
    public class Partidas{
         public static void IniciarNuevaPartida()
        {
           
             GameState state = new GameState();

             Console.WriteLine("Ingrese su nombre: ");
             state.Nombre = Console.ReadLine();
            
            Random random = new Random();



            for(state.x = 10; state.x >= state.Turnos || state.Puntos==10; state.x--)
            {

                List<int> numerosAleatorios = new List<int>{random.Next(1, 7), random.Next(1, 7), random.Next(1, 7)};
                
                bool comodines = true;

                
                int n1=numerosAleatorios.ElementAt(0);
                int n2=numerosAleatorios.ElementAt(1);
                int n3=numerosAleatorios.ElementAt(2);

                Pantalla:

                if(state.x==0){
                    Console.WriteLine("");
                    Fonts.ConsoleUtils.Escribir(25,"Perdiste la vida");
                    Console.ReadKey();
                    return;
                }
                 else if(state.Puntos==10){
                    Console.WriteLine("");
                    Fonts.ConsoleUtils.Escribir(25,"Has ganado");
                    Console.ReadKey();
                    return;
                }

                else if (state.Puntos!=10){
                

                Console.Clear();
Console.WriteLine(@$"Vidas: {state.Vidas}  Turno: {state.x} Comodines: {state.Comodines} Puntos: {state.Puntos}  
5.-Nueva Partida 6.-Cargar Partida 7.Creditos  ");
                Console.WriteLine($"\nNumeros requeridos: {n1} {n2} {n3}\n");
                Console.WriteLine(@$"
                Ingrese 1 para tirar los dados
                Ingrese 2 para usar un comodin
                Ingrese 3 para guardar y salir
                Ingrese 4 para salir sin guardar");
                try{
                int opcion = int.Parse(Console.ReadLine());

                 switch (opcion) {
                    case 1:

                         List<int> dados = new List<int>{random.Next(1,7), random.Next(1,7)};

                        int dado1 = dados[0];
                        int dado2 = dados[1];
                        Fonts.ConsoleUtils.Escribir(25, $"Tirando dados... {dado1} {dado2}");


                        int coincidencias = 0;

                        foreach (int numeroLista1 in numerosAleatorios)
                            {
                                foreach (int numeroLista2 in dados)
                                {
                                    if (numeroLista1 == numeroLista2)
                                        coincidencias++;  
                                }
                            }
                        if(coincidencias == 0)
                        state.Vidas--;

                        Console.WriteLine("");
                        Fonts.ConsoleUtils.Escribir(25, $"Numero de Coincidencias:... {coincidencias}");

                        state.Puntos += coincidencias;
                        Console.ReadKey();
                        break;
                    case 2:
                            if (comodines == true){
                            
                                if (state.Comodines > 0)
                                {
                                    int dado = random.Next(1, 6);
                                    Fonts.ConsoleUtils.Escribir(25,"Usando comodín...");
                                    Console.WriteLine("");

                                //* Switch Comodines
                                    switch (dado){
                                        case 1:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 punto extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            break;
                                        case 2:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 Turno extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x++;
                                            break;
                                        case 3:
                                         Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"2 puntos extra");
                                            Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            state.Puntos++;
                                            break;
                                        case 4:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 punto menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos--;
                                            break;
                                        case 5:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 turno menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x--;
                                            break;
                                        case 6:Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"Perdiste este comodin");
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
                                    Fonts.ConsoleUtils.Escribir(25,"No tienes comodines disponibles.");
                                    Console.ReadKey();
                                    goto Pantalla;
                                }
                            }
                            else{
                                Fonts.ConsoleUtils.Escribir(25,"Ya has usado un comodín.");
                                Console.ReadKey();
                                    goto Pantalla;
                            }
                    case 3:
                    Fonts.ConsoleUtils.Escribir(25,"Guardando partida...");
                    Datos.Game.BorrarPartida(state);
                    Datos.Game.SaveGame(state);
                    Console.ReadKey();
                    return;

                    case 4:
                    return;

                    case 5:
                    Console.Clear();
                    IniciarNuevaPartida(); return;
                    case 6:
                    Console.Clear();
                    Datos.Game.CargarPartida();
                     return;

                     case 7:
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
    goto Pantalla;
    
           

                    default:
                    
                    goto Pantalla;

                }

                }


                catch (Exception e){

                    
                    goto Pantalla;
                }
            }
                
               
            }

            
        }
    
        public static void IniciarJuego(Datos.GameState state)
        {
            Random random = new Random();

            for(state.x = state.x; state.x >= state.Turnos; state.x--)
            {
                 List<int> numerosAleatorios = new List<int>{random.Next(1, 7), random.Next(1, 7), random.Next(1, 7)};
                

                 bool comodines = true;

                
                int n1=numerosAleatorios.ElementAt(0);
                int n2=numerosAleatorios.ElementAt(1);
                int n3=numerosAleatorios.ElementAt(2);

                Pantalla:
                if(state.x==0){
                    Console.WriteLine("");
                    Fonts.ConsoleUtils.Escribir(25,"Perdiste la vida");
                    Console.ReadKey();
                    return;
                }
                else if(state.Puntos==10){
                    Console.WriteLine("");
                    Fonts.ConsoleUtils.Escribir(25,"Has ganado");
                    Console.ReadKey();
                    return;
                }

                else if(state.Puntos!=10){
               

                Console.Clear();
                Console.WriteLine(@$"Vidas: {state.Vidas}  Turno: {state.x} Comodines: {state.Comodines} Puntos: {state.Puntos}  
5.-Nueva Partida 6.-Cargar Partida 7.Creditos  ");
                Console.WriteLine($"\nNumeros requeridos: {n1} {n2} {n3}\n");
                Console.WriteLine(@$"
                Ingrese 1 para tirar los dados
                Ingrese 2 para usar un comodin
                Ingrese 3 para guardar y salir
                Ingrese 4 para salir sin guardar");
               
                try{
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 1:

                         List<int> dados = new List<int>{random.Next(1,7), random.Next(1,7)};

                        int dado1 = dados[0];
                        int dado2 = dados[1];
                        Fonts.ConsoleUtils.Escribir(25, $"Tirando dados... {dado1} {dado2}");


                        int coincidencias = 0;

                        foreach (int numeroLista1 in numerosAleatorios)
                            {
                                foreach (int numeroLista2 in dados)
                                {
                                    if (numeroLista1 == numeroLista2)
                                        coincidencias++;  
                                }
                            }
                        if(coincidencias == 0)
                        state.Vidas--;

                        Console.WriteLine("");
                        Fonts.ConsoleUtils.Escribir(25, $"Numero de Coincidencias:... {coincidencias}");

                        state.Puntos += coincidencias;
                        Console.ReadKey();
                        break;
                    case 2:
                            if (comodines == true){
                            
                                if (state.Comodines > 0)
                                {
                                    int dado = random.Next(1, 6);
                                    Fonts.ConsoleUtils.Escribir(25,"Usando comodín...");
                                    Console.WriteLine("");

                                //* Switch Comodines
                                    switch (dado){
                                        case 1:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 punto extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            break;
                                        case 2:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 Turno extra");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x++;
                                            break;
                                        case 3:
                                         Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Green;
                                            Fonts.ConsoleUtils.Escribir(25,$"2 puntos extra");
                                            Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos++;
                                            state.Puntos++;
                                            break;
                                        case 4:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 punto menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.Puntos--;
                                            break;
                                        case 5:
                                            Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"1 turno menos");
                                              Console.ForegroundColor=ConsoleColor.White;
                                            state.x--;
                                            break;
                                        case 6:Fonts.ConsoleUtils.Escribir(25,$"Numero del dado {dado}: ");
                                            Console.ForegroundColor=ConsoleColor.Red;
                                            Fonts.ConsoleUtils.Escribir(25,$"Perdiste este comodin");
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
                                    Fonts.ConsoleUtils.Escribir(25,"No tienes comodines disponibles.");
                                    Console.ReadKey();
                                    goto Pantalla;
                                }
                            }
                            else{
                                Fonts.ConsoleUtils.Escribir(25,"Ya has usado un comodín.");
                                Console.ReadKey();
                                    goto Pantalla;
                            }
                    case 3:
                    Fonts.ConsoleUtils.Escribir(25,"Guardando partida...");
                    Datos.Game.BorrarPartida(state);
                    Datos.Game.SaveGame(state);
                    Console.ReadKey();
                    return;

                    case 4:
                    return;

                     case 5:
                    Console.Clear();
                    IniciarNuevaPartida(); return;
                    case 6:
                    Console.Clear();
                    Datos.Game.CargarPartida();
                     return;

                     case 7:
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
    goto Pantalla;
    
           

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
   
}