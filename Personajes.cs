using System.Text.Json;


namespace EspacioPersonajes;

public enum Razas{
    Hada,
    Dragon,
    Centauro
}

public class Personajes
{
    private InfoBasica datosBasicos;
     
    private string nombre;

    private int vidaActual;
    private int vidaMaxima;
    private int danio;
    private int evasion;
    private int defensa;

    private int pociones;
    private Razas raza;

    public Personajes(string NombreIngresado, int numRaza)
    {
        Nombre= NombreIngresado; 
        Pociones=3;
        
        switch(numRaza)
        {
            case 1:                     //Balancear las estadisticas 
                Raza=Razas.Hada;
                VidaMaxima=75;
                VidaActual=75;
                Danio=25;
                Evasion=50;
                Defensa=25;
                break;
            case 2:
                Raza=Razas.Centauro;
                VidaMaxima=100;
                VidaActual=100;
                Danio=25;
                Evasion=75;
                Defensa=50;
                break;
            case 3:
                Raza=Razas.Dragon;
                VidaMaxima=125;
                VidaActual=125;
                Danio=25;
                Evasion=100;
                Defensa=75;
                break;
        }
    }


    public void MostrarEstadisticas()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEstadisticas:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("   VidaActual:"+VidaActual);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("   Danio:"+Danio);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("   Evasion:"+Evasion);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("   Defensa:"+Defensa);
        switch(Raza)
        {
            case Razas.Hada:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("   Raza: Hada");
                break;
            case Razas.Centauro:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("   Raza: Centauro");
                break;
            case Razas.Dragon:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("   Raza: Dragon");
                break;
        }
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("   Pociones restantes:"+Pociones);
    }
    public void PresentarEnemigo()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nTu proximo enemigo sera:");
        switch (Raza)
         {
            case Razas.Hada:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("El/La Hada"+Nombre);
                break;
            case Razas.Centauro:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("El/La Centauro"+Nombre);
                break;
            case Razas.Dragon:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("El/La Dragon"+Nombre);
                break;
        }
    }
    public bool EstaVivo()
    {
        if(VidaActual!=0)
        {
            return false;
        }else
        {
            return true;
        }
    }

    public void PerderVida(int danioRecibido)
    {
        if(danioRecibido>VidaActual)
        {
            VidaActual=0;
        }else
        {
            VidaActual=VidaActual-danioRecibido;
        }
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public int VidaActual { get => VidaActual; set => VidaActual = value; }
    public int Evasion { get => evasion; set => evasion = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Danio { get => danio; set => danio = value; }
    public InfoBasica DatosBasicos { get => datosBasicos; set => datosBasicos = value; }
    public int Pociones { get => pociones; set => pociones = value; }
    public Razas Raza { get => raza; set => raza = value; }
    public int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }
} 


