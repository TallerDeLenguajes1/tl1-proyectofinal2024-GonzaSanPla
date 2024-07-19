using System.Drawing;
using System.Text.Json;


namespace EspacioPersonajes;


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
    private int raza; // 1- Hada 2-Centauro 3- Ogro

    private bool concentrado;

    public Personajes(string NombreIngresado, int numRaza)
    {
        Nombre= NombreIngresado; 
        Pociones=3;
        Concentrado=false;
        switch(numRaza)
        {
            case 1:                     //Balancear las estadisticas 
                Raza= numRaza;
                VidaMaxima=75;
                VidaActual=75;
                Danio=25;
                Evasion=50;
                Defensa=25;
                break;
            case 2:
                Raza=numRaza;
                VidaMaxima=100;
                VidaActual=100;
                Danio=25;
                Evasion=75;
                Defensa=50;
                break;
            case 3:
                Raza=numRaza;
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
            case 1:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("   Raza: Hada");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("   Raza: Centauro");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("   Raza: Ogro");
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
            case 1:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Nombre+",el/la Hada");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(Nombre+",el/la Centauro");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Nombre+",el/la Ogro ");
                break;
        }
    }
    public bool EstaVivo()// Si esta vivo retorna true
    {
        if(VidaActual!=0)
        {
            return true;
        }else
        {
            return false;
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
    public void MostrarVida()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nVida de "+Nombre+": "+VidaActual);

    }

    public void UtilizarPocion()
    {
        if(Pociones!=0)
        {
            if((VidaActual+(VidaMaxima/2))>vidaMaxima)
            {
                VidaActual=VidaMaxima;
            }else
            {
                VidaActual=VidaActual+(VidaMaxima/2);
            }
            
            Pociones--;
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine("\n"+Nombre+" ha utilizado una pocion, quedan "+Pociones+" pociones");
        }else
        {            
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine("A "+Nombre+" no le quedan mas pociones");
        }

    }
    public void Concentar()
    {
        Concentrado=true;
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine("\n"+Nombre+" se ha concentrado");
    }
    public void Desoncentar()
    {
        Concentrado=false;
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine("\n"+Nombre+" se ha desconcentrado");
    }
    public bool EstaContrado()
    {
        if(Concentrado)
        {
            return true;
        }else
        {
            return false;
        }
    }
    public bool LoEsquiva(int numAtaque)
    {
        if(numAtaque>Evasion)
        {
            return false;
        }else
        {
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine(Nombre+" ha evitado el ataque");
            return true;
        }
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public int VidaActual { get => vidaActual; set => vidaActual = value; }
    public int Evasion { get => evasion; set => evasion = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Danio { get => danio; set => danio = value; }
    public InfoBasica DatosBasicos { get => datosBasicos; set => datosBasicos = value; }
    public int Pociones { get => pociones; set => pociones = value; }
    public int Raza { get => raza; set => raza = value; }
    public int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }
    public bool Concentrado { get => concentrado; set => concentrado = value; }
} 


