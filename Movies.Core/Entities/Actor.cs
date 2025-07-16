using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Core.Entities
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int BirthYear { get; set; }

        // Navigation property
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; } = new List<Movie>(); // N:M relationship with Movie


    }
}
