using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Core.Dtos
{
    public record ActorDto
    {
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public int BirthYear { get; set; } 
    }
}