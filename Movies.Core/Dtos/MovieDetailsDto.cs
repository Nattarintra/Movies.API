using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Core.Dtos
{
    public record MovieDetailsDto
    {
        [MaxLength(300)]
        public string Synopsis { get; init; } = null!;

        [MaxLength(20)]
        public string Language { get; init; } = null!;
        public int Budget { get; init; }
   
    }
}