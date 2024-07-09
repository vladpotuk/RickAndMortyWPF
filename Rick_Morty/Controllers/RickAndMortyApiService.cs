using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RickAndMortyWPF.Models;

namespace RickAndMortyWPF.Controllers
{
    public class RickAndMortyApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new System.Uri("https://rickandmortyapi.com/api/") };

        public async Task<List<Character>> GetCharactersAsync()
        {
            var characters = new List<Character>();
            int page = 1;
            bool morePages = true;

            while (morePages)
            {
                var response = await _httpClient.GetAsync($"character/?page={page}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse>(content);
                    characters.AddRange(data.Results);

                    // Check if more pages are available
                    morePages = data.Results.Count > 0;
                    page++;
                }
                else
                {
                    morePages = false;
                }
            }

            return characters;
        }

        public async Task<Location> GetLocationAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<Location>(content);
            return location;
        }

        public async Task<List<Episode>> GetEpisodesAsync(List<string> episodeUrls)
        {
            var episodes = new List<Episode>();
            foreach (var url in episodeUrls)
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var episode = JsonConvert.DeserializeObject<Episode>(content);
                episodes.Add(episode);
            }

            return episodes;
        }
    }
}
