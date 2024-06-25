
using System.Text.Json.Serialization;


public class InfoBasica
{
    [JsonPropertyName("gender")]
    public string genero { get; set; }

    [JsonPropertyName("first")]
    public string nombre { get; set; }
}

