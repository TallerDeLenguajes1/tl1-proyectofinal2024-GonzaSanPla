﻿// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPersonajes;

/*
Colores y su signficado:
    Texto   - White
    Vida    - Green
    Daño    - Red
    Evasion - Cyan
    Defensa - DarkBlue
    Hada    - Magenta
    Centauro- DarkCyan
    Ogro  - DarkGreen
    Pociones- DarkRed

*/

Personajes Jugador;
Personajes Enemigo;

Jugador = await FabricaDeJugador();
Jugador.MostrarEstadisticas();
// while(Jugador.EstaVivo())
// {
    Enemigo = await FabricaDeEnemigo();
    Jugador=Pelear(Jugador,Enemigo);
// }


static async Task<Personajes> FabricaDeJugador()
{
   string nombreJ;
    int raza;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nIngrese su nombre:");
    nombreJ = Console.ReadLine();
    raza=ElegirRaza();
    Personajes pj = new Personajes(nombreJ, raza);
    return pj;
}

static async Task<Personajes> FabricaDeEnemigo()
{
    Random rand=new Random();
    // InfoBasica info= await ObtenerInfoBas();
    //CAMBIAR Enemigo por el nombre traido por la API
    Personajes pj = new Personajes("Enemigo", rand.Next(1,4));//Genera un numero al azar entre 1 y 3 
    return pj;
}

static async Task<InfoBasica> ObtenerInfoBas()
{
    var url = "https://randomuser.me/api/";
    try
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        InfoBasica infoBas = JsonSerializer.Deserialize<InfoBasica>(responseBody);
        return infoBas;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}

static int ElegirRaza()
{
    bool condiciones;
    string strRaza;
    int raza;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nElija que quiere ser:");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n  1-Hada: Fragil pero puede evitar muchos golpes");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n  2-Centauro: El mas equilibrado");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n  3-Ogro: Es mas fuerte pero no esquiva ningun golpe");
        strRaza = Console.ReadLine();
        if (int.TryParse(strRaza, out raza))        // Para controlar si es un numero y sies un numero valido
        {
            if (raza < 4 && raza > 0)
            {
                condiciones = true;
            }
            else
            {
                condiciones = false;
            }
        }
        else
        {
            condiciones = false;
        }

    }while(!condiciones);

    return raza;
}

static Personajes Pelear(Personajes Jugador, Personajes Enemigo)
{
    string opcion;
    Jugador.MostrarVida();
    Enemigo.MostrarVida();
    opcion=ElegirOpcion(Jugador);          // Regresa un string con 1 para atacar, 2 para defender y 3 para usar pocion
    if(Jugador.Raza<Enemigo.Raza)          //Para elegir quien ataca primero me baso en su raza siendo Hada>Centauro>Ogro y si son de la misma raza va primero el jugador
    {

    }
    return Jugador;
}

static string ElegirOpcion(Personajes Jugador)        // Regresa un string con 1 para atacar, 2 para defender y 3 para usar pocion
{
    string opcion;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nElija su siguiente movimiento:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" 1-Artacar");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(" 2-Defender");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" 3-Tomar pocion(Pociones restantes:"+Jugador.Pociones+")");  
        opcion=Console.ReadLine();
    }while(opcion!="1"&&opcion!="2"&&opcion!="3");
    return opcion;
}