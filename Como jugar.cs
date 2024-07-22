/*
   _____                          _                        
  / ____|                        (_)                       
 | |     ___  _ __ ___   ___      _ _   _  __ _  __ _ _ __ 
 | |    / _ \| '_ ` _ \ / _ \    | | | | |/ _` |/ _` | '__|
 | |___| (_) | | | | | | (_) |   | | |_| | (_| | (_| | |   
  \_____\___/|_| |_| |_|\___/    | |\__,_|\__, |\__,_|_|   
                                _/ |       __/ |           
                               |__/       |___/            
*/

class ComoJuagar
{
    public void Mostrar()
    {
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        Console.WriteLine("  _____                          _                        ");
        Console.WriteLine(" / ____|                        (_)                       ");
        Console.WriteLine("| |     ___  _ __ ___   ___      _ _   _  __ _  __ _ _ __ ");
        Console.WriteLine("| |    / _ \\| '_ ` _ \\ / _ \\    | | | | |/ _` |/ _` | '__|");
        Console.WriteLine("| |___| (_) | | | | | | (_) |   | | |_| | (_| | (_| | |   ");
        Console.WriteLine(" \\_____\\___/|_| |_| |_|\\___/    | |\\__,_|\\__, |\\__,_|_|   ");
        Console.WriteLine("                               _/ |       __/ |           ");
        Console.WriteLine("                              |__/       |___/            ");

        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("Para  poder llegar a ser el Rey del castillo deberas enfratarte a disversos adversarios relizando movientos por turnos.");
        Console.WriteLine("En cada turno podras elegir una de las siguitens opciones como moviento:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ATACAR- Elijiendo esta opcion lo atacaras al enemigo reduciendo su salud, esto se hace teniendo en ceunta tu ataque y la defensa del enemigo.Pero mucho CUIDADO tu atauqes pueden fallar segun la evasion del enigo de misma forma que tu podras llegar a evitar ataques");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("CONCENTRAR- Mediante la concentracion lograras aguantar mejor el ataque enemigo y te permitira pegar mas fuerte en tu siguiente movimiento. Ten en cuenta que los veneficios solo duraran un turno asi que eleje sabiamente tu proximo movimiento");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("TOMAR UNA POCIONE- Durante la partida tendras la opcion de usar una de tus TRES pociones que te recuperaran la mitad de la vida. Es un recurso valioso ya que es la UNICA dfroma de recuperar vida");
    }
}