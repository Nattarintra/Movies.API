using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Dtos
{
    public class MovieDetailDto
    {
        [MaxLength(30)]
        public string Title { get; set; } = null!;

        [Range(1995, 2025)]
        public int Year { get; set; }

        [Range(60, 80)]
        public int Duration { get; set; }
        public MovieDetailsDto MovieDetails { get; set; } = null!;
        public int MovieGenreId { get; set; }

        List<ReviewCreateDto> Reviews { get; set; } = new List<ReviewCreateDto>();
        List<ActorDto> Actors { get; set; } = new List<ActorDto>();
    }
}
