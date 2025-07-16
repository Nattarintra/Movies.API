using Bogus;
using Movies.API.Data;
using Movies.Core.Entities;

namespace Movies.API.Services.DataSeeders
{
    public static class MovieSeeder
    {
        public static IEnumerable<Movie> GenerateMovies(int numberOfMovies, List<Genre> genres)
        {
            var faker = new Faker<Movie>("en")
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Title, f => string.Join(" ", f.Lorem.Words(3)))
                .RuleFor(m => m.Year, f => f.Date.Past(20).Year)
                .RuleFor(m => m.Duration, f => f.Random.Int(60, 180))
                .RuleFor(m => m.MovieDetails, f => new MovieDetails
                {
                    Id = Guid.NewGuid(),
                    Synopsis = f.Lorem.Paragraph(),
                    Language = f.PickRandom("English", "Swedish"),
                    Budget = f.Random.Int(1_000_000, 200_000_000)
                })
                .RuleFor(m => m.GenreId, f => f.PickRandom(genres).Id)
                .RuleFor(m => m.Reviews, f => ReviewGenerator.GenerateReviews())
                .RuleFor(m => m.Actors, f => ActorGenerator.GenerateActors());

            return faker.Generate(numberOfMovies);
        }

    }
}
