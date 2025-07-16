using Movies.API.Data;
using Movies.Core.Entities;

namespace Movies.API.Services.DataSeeders
{
    public static class GenreSeeder
    {
        public static List<Genre> SeedGenres()
        {
            var names = new[] { "Action", "Drama", "Comedy", "Horror", "Romance" };
            return names.Select(name => new Genre
            {
                Id = Guid.NewGuid(),
                Name = name
            }).ToList();
        }

    }
}
