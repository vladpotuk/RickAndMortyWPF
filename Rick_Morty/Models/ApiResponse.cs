using System.Collections.Generic;

namespace RickAndMortyWPF.Models
{
    public class ApiResponse
    {
        public List<Character> Results { get; set; } = new List<Character>();
    }
}
