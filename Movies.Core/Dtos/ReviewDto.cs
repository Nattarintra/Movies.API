using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Core.Dtos
{
    public record ReviewDto
    {
        [MaxLength(30)]
        public string ReviewerName { get; set; } = null!;
        [MaxLength(100)]
        public string? Comment { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } // rating scale of 1-5 

    }
}