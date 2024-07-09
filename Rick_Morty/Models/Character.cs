using System.Collections.Generic;

namespace RickAndMortyWPF.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<string> Episode { get; set; } = new List<string>();
        public Location Origin { get; set; } = new Location();
    }
}
