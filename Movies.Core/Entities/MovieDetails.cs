using System.Text.Json.Serialization;

namespace Movies.Core.Entities
{
    public class MovieDetails
    {
        public Guid Id { get; set; }
        public string Synopsis { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int Budget { get; set; }

        // Forein Key
        public Guid MovieId { get; set; }

        // Navigation property
        [JsonIgnore]
        public Movie Movie { get; set; } = null!;
    }
}
