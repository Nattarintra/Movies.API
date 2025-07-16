using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Core.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string? Comment { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } // rating scale of 1-5 

        // Foreign Key
        public Guid MovieId { get; set; } // M:1 relationship with Movie

        // Navigation property
        [JsonIgnore]
        public Movie Movie { get; set; } = null!;
    }
}
