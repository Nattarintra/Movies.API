using System.Text.Json.Serialization;

namespace Movies.Core.Dtos
{
    public record GenreDto
    {
        public string Name { get; set; } = null!;

    }
}