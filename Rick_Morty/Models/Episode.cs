using Newtonsoft.Json;

namespace RickAndMortyWPF.Models
{
    public class Episode
    {
        public string Name { get; set; } = string.Empty;

        [JsonProperty("air_date")]
        public string AirDate { get; set; } = string.Empty;

        [JsonProperty("episode")]
        public string EpisodeCode { get; set; } = string.Empty;
    }
}
