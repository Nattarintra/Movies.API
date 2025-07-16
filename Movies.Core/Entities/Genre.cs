using System.Text.Json.Serialization;

namespace Movies.Core.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation property
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
