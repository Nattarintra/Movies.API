using System.ComponentModel.DataAnnotations;

namespace Movies.Core.Dtos
{
    public record MovieDto
    {
        [MaxLength(30)]
        public string Title { get; init; } = null!;
        public int Year { get; init; }
        public int Duration { get; init; }

        public MovieDetailsDto? MovieDetails { get; init; } = null!;

    }
}
