using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace Movies.Core.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public int Duration { get; set; }
        public MovieDetails MovieDetails { get; set; } = null!;

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        // Navigation property
        public ICollection<Review> Reviews { get; set; } = new List<Review>(); // 1:M
        public ICollection<Actor> Actors { get; set; } = new List<Actor>(); // N:M relationship with Actor

    }
}
