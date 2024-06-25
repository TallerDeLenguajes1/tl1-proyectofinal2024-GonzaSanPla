
namespace EspacioPersonajes;

public enum Razas{
    Hada,
    Ogro,
    Humano,
    Centauro
    
}

public class Personajes
{
    InfoBasica infoBasica= await ObtenerInfoBas();
    private string nombre;

    nombre=infoBasica.nombre;


    

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
