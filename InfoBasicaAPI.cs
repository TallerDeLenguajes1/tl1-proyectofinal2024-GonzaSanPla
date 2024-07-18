
using System.Text.Json.Serialization;



public class InfoBasica
{
    [JsonPropertyName("title")]
    public string title { get; set; }
    
    [JsonPropertyName("first")]
    public string first { get; set; }

    [JsonPropertyName("last")]
    public string last { get; set; }
    
    [JsonPropertyName("gender")]
    public string gender { get; set; }

    // public class Name
    // {
    //     [JsonPropertyName("title")]
    //     public string title { get; set; }

    //     [JsonPropertyName("first")]
    //     public string first { get; set; }

    //     [JsonPropertyName("last")]
    //     public string last { get; set; }
    // }

    // public class Result
    // {
    //     [JsonPropertyName("gender")]
    //     public string gender { get; set; }

    //     [JsonPropertyName("name")]
    //     public Name name { get; set; }

    // }

    // public class Root
    // {
    //     [JsonPropertyName("results")]
    //     public List<Result> results { get; set; }

    // }

    
}
