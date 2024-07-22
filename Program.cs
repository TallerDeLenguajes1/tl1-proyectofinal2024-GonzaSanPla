// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPersonajes;

/*
Colores y su signficado:
    Texto       - White
    Vida        - Green
    Ataque      - Red
    Evasion     - DarkBlue
    Defensa     - Gray
    Hada        - Magenta
    Centauro    - DarkCyan
    Ogro        - DarkGreen
    Pociones    - DarkRed
    Concentrar  - Blue
    Título      - DarkYellow
    Castillo    - DarkGray
*/

Personajes Jugador;
Personajes Enemigo;

Inicio();
Jugador = FabricaDeJugador();
Jugador.MostrarEstadisticas();
while (Jugador.EstaVivo()&&!Jugador.Ganar())
{
    MostrarOleada(Jugador);
    Enemigo = await FabricaDeEnemigo();
    Enemigo.PresentarEnemigo();
    Jugador = Pelear(Jugador, Enemigo);
    if (Jugador.EstaVivo())
    {
        Jugador.RecibirRecompensa(Enemigo.Raza);
    }
}
Finalizar(Jugador);

static void Inicio()
{
    Titulo titulo = new Titulo();
    TextoInicial textoI = new TextoInicial();
    Castillo castillo = new Castillo();
    ComoJuagar comoJ = new ComoJuagar();

    titulo.Mostrar();
    Pausa();
    textoI.Mostrar();
    castillo.Mostrar();
    Pausa();
    comoJ.Mostrar();
}

static Personajes FabricaDeJugador()
{
    string nombreJ;
    int raza;
    Console.ForegroundColor = ConsoleColor.White;
    do
    {
        Console.WriteLine("\nIngresa tu nombre:");
        nombreJ = Console.ReadLine();
    }while (nombreJ=="");
    raza = ElegirRaza();
    Personajes pj = new Personajes(nombreJ, raza);
    return pj;
}
static void MostrarOleada(Personajes Jugador)
{
    ProximaOleada proxOl= new ProximaOleada();
    proxOl.Mostrar();
    Jugador.MostrarOleada();
}
static async Task<Personajes> FabricaDeEnemigo()
{
    Random rand = new Random();
    // InfoBasica info= await ObtenerInfoBas();
    //CAMBIAR Enemigo por el nombre traido por la API
    Personajes pj = new Personajes("Enemigo", rand.Next(1, 4));//Genera un numero al azar entre 1 y 3 
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
    MostrarHada hada= new MostrarHada();
    MostrarCentauro centauro= new MostrarCentauro();
    MostrarOgro ogro= new MostrarOgro();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\nHada: Fragil pero gracias su diminuta altura y alta velocidad puede evitar muchos golpes");
    hada.Mostrar();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("\nCentauro: Logra aguantar unos cuantes golpes y con cierta agilidad se mueve evitando algunos ataques");
    centauro.Mostrar();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("\nOgro: Debido a su gran tamanio se le complica movese velozmente lo cual queda extramadamente vulnerable a los golpes enemigos. Pero lo compensa con su gran capacidad de recibir golpes");
    ogro.Mostrar();
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nElija que quiere ser:");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n  1-Hada");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n  2-Centauro");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n  3-Ogro");
        Console.ForegroundColor=ConsoleColor.White;
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

    } while (!condiciones);

    return raza;
}

static Personajes Pelear(Personajes Jugador, Personajes Enemigo)
{
    PersonajesEnCombate ConjuntoDePersonaje = new PersonajesEnCombate();
    int opcion;
    do
    {
        Jugador.MostrarVida();
        Enemigo.MostrarVida();
        opcion = ElegirOpcion(Jugador);          // Regresa un string con 1 para atacar, 2 para defender y 3 para usar pocion
        if (Enemigo.Raza >= Jugador.Raza)          //Para elegir quien ataca primero me baso en su raza siendo Hada>Centauro>Ogro y si son de la misma raza va primero el jugador
        {
            Console.WriteLine("\n");
            ConjuntoDePersonaje.Atacante = Jugador;                                    //Este bloque es para realizar la accion del jugador
            ConjuntoDePersonaje.Defensor = Enemigo;
            ConjuntoDePersonaje = RealizarMovimiento(ConjuntoDePersonaje, opcion);
            Jugador = ConjuntoDePersonaje.Atacante;
            Enemigo = ConjuntoDePersonaje.Defensor;
            if (Enemigo.EstaVivo())
            {
                Console.WriteLine("\n");
                ConjuntoDePersonaje.Atacante = Enemigo;                                    //Este bloque es para realizar la accion del enemigo
                ConjuntoDePersonaje.Defensor = Jugador;
                ConjuntoDePersonaje = RealizarMovimiento(ConjuntoDePersonaje, Enemigo.ElegirMovimiento());
                Enemigo = ConjuntoDePersonaje.Atacante;
                Jugador = ConjuntoDePersonaje.Defensor;
            }
        }
        else
        {
            Console.WriteLine("\n");
            ConjuntoDePersonaje.Atacante = Enemigo;                                    //Este bloque es para realizar la accion del enemigo
            ConjuntoDePersonaje.Defensor = Jugador;
            ConjuntoDePersonaje = RealizarMovimiento(ConjuntoDePersonaje, Enemigo.ElegirMovimiento());
            Enemigo = ConjuntoDePersonaje.Atacante;
            Jugador = ConjuntoDePersonaje.Defensor;
            if (Jugador.EstaVivo())
            {
                Console.WriteLine("\n");
                ConjuntoDePersonaje.Atacante = Jugador;                                    //Este bloque es para realizar la accion del jugador
                ConjuntoDePersonaje.Defensor = Enemigo;
                ConjuntoDePersonaje = RealizarMovimiento(ConjuntoDePersonaje, opcion);
                Jugador = ConjuntoDePersonaje.Atacante;
                Enemigo = ConjuntoDePersonaje.Defensor;
            }
        }
    } while (Jugador.EstaVivo() && Enemigo.EstaVivo());
    if (Jugador.EstaVivo())
    {
        Console.WriteLine("Has derrotado a " + Enemigo.Nombre);
        Jugador.AumentarOleada();
    }

    return Jugador;
}

static int ElegirOpcion(Personajes Jugador)        // Regresa un string con 1 para atacar, 2 para defender y 3 para usar pocion
{
    int opcion;
    string strOpcion;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nElija su siguiente movimiento:");
        Console.ForegroundColor = ConsoleColor.Green;   //Exepcion de color sino es demasiado rojo
        Console.WriteLine(" 1-Artacar");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(" 2-Concentrar");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" 3-Tomar pocion(Pociones restantes:" + Jugador.Pociones + ")");
        Console.ForegroundColor=ConsoleColor.White;
        strOpcion = Console.ReadLine();
    } while (strOpcion != "1" && strOpcion != "2" && strOpcion != "3");
    int.TryParse(strOpcion, out opcion);
    return opcion;
}

static Personajes Atacar(Personajes Atacante, Personajes Defensor)
{
    Random rand = new Random();
    int danioRealizado, varConcentracion;
    if (!Defensor.LoEsquiva(rand.Next(1, 101)))                    //Para que sean numeros entre el 1 y el 100 
    {
        varConcentracion = VariableDeConcentracionParaCalcularDanio(Atacante, Defensor);
        danioRealizado = Atacante.Ataque * 15 * varConcentracion / Defensor.Defensa;     //15 es una variable de balanceo
        Defensor.PerderVida(danioRealizado);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Atacante.Nombre + " ha realizado " + danioRealizado + " puntos de daño a " + Defensor.Nombre);
    }
    return Defensor;
}

static int VariableDeConcentracionParaCalcularDanio(Personajes Atacante, Personajes Defensor)       //Retorna 2 si estan neutro,4 si solo el atacante y 1 si solo el defensor
{

    if (Atacante.EstaContrado() == Defensor.EstaContrado())    //Si los dos estan concentrados queda en un ataque normal porque se neutraliza
    {
        return 2;
    }
    else
    {
        if (Atacante.EstaContrado())                         //Si no esta concentrado el atacante entonces tiene que estar concentrado el defensor en este caso 
        {
            return 4;
        }
        else
        {
            return 1;
        }
    }

}

static PersonajesEnCombate RealizarMovimiento(PersonajesEnCombate ConjuntoDePersonaje, int opcion)
{

    switch (opcion)
    {
        case 1:
            ConjuntoDePersonaje.Defensor = Atacar(ConjuntoDePersonaje.Atacante, ConjuntoDePersonaje.Defensor);
            if (ConjuntoDePersonaje.Atacante.EstaContrado())
            {
                ConjuntoDePersonaje.Atacante.Desoncentar();
            }
            break;
        case 2:
            ConjuntoDePersonaje.Atacante.Concentar();
            break;
        case 3:
            ConjuntoDePersonaje.Atacante.UtilizarPocion();
            if (ConjuntoDePersonaje.Atacante.EstaContrado())
            {
                ConjuntoDePersonaje.Atacante.Desoncentar();
            }
            break;
    }
    return ConjuntoDePersonaje;
}

static void Finalizar(Personajes Jugador)
{
    string JugadorSerializado;
    var helper = new HelperDeJson();
    string NombreDelArchivo = "Historial del jugadores";

    if(Jugador.Ganar())
    {
        Corona corona=new Corona();
        Felicidades felicidas= new Felicidades();
        corona.Mostrar();
        felicidas.Mostrar();
        Console.WriteLine("Losgraste tu objetivo y te convertiste en el/la Rey del castillo");
        Jugador.MostrarOleadaFinal();

    }
    JugadorSerializado = JsonSerializer.Serialize(Jugador);

    helper.GuardarArchivoTexto(NombreDelArchivo, JugadorSerializado);
}

static void Pausa()
{
    string basura;
    Console.ForegroundColor=ConsoleColor.White;
    Console.WriteLine("Presione enter para continuar.");
    basura=Console.ReadLine();
}