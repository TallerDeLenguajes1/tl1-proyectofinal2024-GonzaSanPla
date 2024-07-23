

    using System.Text.Json.Serialization;

    namespace EspacioRoot; 
    public class Name
    {
        
        [JsonPropertyName("first")]
        public string First { get; set; }        
    }


    public class Result
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

    