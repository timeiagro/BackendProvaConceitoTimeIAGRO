using Newtonsoft.Json;

namespace WebLivros.Models
{
    public class Specifications
    {
        [JsonProperty("Originally published")]
        public String? OriginallyPublished { get; set; }
        public String? Author { get; set; }

        public int PageCount { get; set; }

        public Object Illustrator { get; set; }

        public Object Genres { get; set; }

    }
}
