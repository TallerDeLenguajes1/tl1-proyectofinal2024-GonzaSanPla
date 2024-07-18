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

    private int vida;

    private int danio;
    private int evasion;

    private int defensa;

    private int pociones;
    private Razas raza;

    public Personajes(string NombreIngresado, int numRaza)
    {
        Nombre= NombreIngresado; 
        Vida=100;
        Danio=20;
        Evasion=75;
        Defensa=50;
        switch(numRaza)
        {
            case 1:
                Raza=Razas.Hada;
                break;
            case 2:
                Raza=Razas.Centauro;
                break;
            case 3:
                Raza=Razas.Dragon;
                break;
        }
    }


    public void MostrarEstadisticas()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEstadisticas:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("   Vida:"+Vida);
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("   Raza: Dragon");
                break;
        }

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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("El/La Dragon"+Nombre);
                break;
        }
    }
    public bool EstaVivo()
    {
        if(Vida!=0)
        {
            return false;
        }else
        {
            return true;
        }
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Vida { get => vida; set => vida = value; }
    public int Evasion { get => evasion; set => evasion = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Danio { get => danio; set => danio = value; }
    public InfoBasica DatosBasicos { get => datosBasicos; set => datosBasicos = value; }
    public int Pociones { get => pociones; set => pociones = value; }
    public Razas Raza { get => raza; set => raza = value; }
} 


