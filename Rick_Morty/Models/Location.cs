using Newtonsoft.Json;

namespace RickAndMortyWPF.Models
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
