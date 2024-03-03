using Newtonsoft.Json;

namespace BackendProvaConceitoTimeIAGRO.Models
{
    public class SpecificationsModel
    {
        [JsonProperty("Originally published")]
        public string Published { get; set; }
        [JsonProperty("Author")]
        public string Author { get; set; }
        [JsonProperty("Page count")]
        public int Pages { get; set; }
        [JsonProperty("Illustrator")]
        public List<string> Illustrator { get; set; }
        [JsonProperty("Genres")]
        public List<string> Genres { get; set; }
        
    }

}
