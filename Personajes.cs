using System.Drawing;
using System.Text.Json;


namespace EspacioPersonajes;


public class Personajes
{
     
    private string nombre;

    private float vidaActual;
    private float vidaMaxima;
    private int ataque;
    private int evasion;
    private int defensa;
    private int pociones;
    private int raza; // 1- Hada 2-Centauro 3- Ogro
    private bool concentrado;
    private int movimiento;//Esta es una varible unicamente para que el enemigo elija movimiento 
    private int oleada;

    public Personajes()
    {

    }
    public Personajes(string NombreIngresado, int numRaza)
    {
        Nombre= NombreIngresado; 
        Pociones=3;
        Concentrado=false;
        Movimiento=1;
        Oleada=1;
        switch(numRaza)
        {
            case 1:                     //Balancear las estadisticas 
                Raza= numRaza;
                VidaMaxima=75;
                VidaActual=75;
                Ataque=25;
                Evasion=50;
                Defensa=25;
                break;
            case 2:
                Raza=numRaza;
                VidaMaxima=100;
                VidaActual=100;
                Ataque=25;
                Evasion=25;
                Defensa=30;
                break;
            case 3:
                Raza=numRaza;
                VidaMaxima=125;
                VidaActual=125;
                Ataque=25;
                Evasion=0;
                Defensa=35;
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
        Console.WriteLine("   Ataque:"+Ataque);
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
        Console.WriteLine("\nVida de "+Nombre+": "+VidaActual+"/"+vidaMaxima);

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

    public int ElegirMovimiento()
    {
        switch(Raza)
        {
            case 1:
                if(Movimiento==1) //Esto es para el patron de moviento del Hada que es: Concentrar-Ataque
                {
                    Movimiento=2;
                    return 2;
                }else
                {
                    Movimiento=1;
                    return 1;
                }
                break;
            case 2:
                if(Movimiento<3) //Esto es para el patron de moviento del Centauro que es: Ataque-Ataque-Concentrar
                    {
                        Movimiento++;
                        return 1;
                    }else
                    {
                        Movimiento=1;
                        return 2;
                    }
                break;
            case 3:             //Esto es para el patron de moviento del Ogro que es: Ataque
                return 1;
                break;
        }
        return 1;   //Lo agrego por si llega a haber un error con la Raza
    }

    public void RecibirRecompensa(int razaEnemiga)
    {
        switch(razaEnemiga)
        {
            case 1:
                Evasion+=10;
                Console.ForegroundColor=ConsoleColor.DarkBlue;
                Console.WriteLine("La evasion de "+Nombre+" ha aumentado");
                break;
            case 2:
                Ataque+=10;
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("El ataque de "+Nombre+" ha aumentado");
                break;
            case 3:
                Defensa+=5;
                Console.ForegroundColor=ConsoleColor.Gray;
                Console.WriteLine("La defensa de "+Nombre+" ha aumentado");
                break;
        }
    }

    public void AumentarOleada()
    {
        Oleada++;
    }
    public void MostrarOleada()
    {
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("Oleada numero:"+Oleada);
    }
    public void MostrarOleadaFinal()
    {
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine(Nombre+" llego hasta la oleada numero:"+Oleada);
    }
    public bool Ganar()
    {
        if(Oleada>=10)
        {
            return true;
        }else
        {
            return false;
        }
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public float VidaActual { get => vidaActual; set => vidaActual = value; }
    public int Evasion { get => evasion; set => evasion = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Ataque { get => ataque; set => ataque = value; }
    public int Pociones { get => pociones; set => pociones = value; }
    public int Raza { get => raza; set => raza = value; }
    public float VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }
    public bool Concentrado { get => concentrado; set => concentrado = value; }
    public int Movimiento { get => movimiento; set => movimiento = value; }
    public int Oleada { get => oleada; set => oleada = value; }
} 


public class PersonajesEnCombate()      //Esto variable la creo para poder utlizar una funcion que me modifique y retone a ambos
{
     public Personajes Atacante;
     public Personajes Defensor;

}