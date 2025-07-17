using Bogus;
using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
using Movies.Core.Entities;
using Movies.API.Services.DataSeeders;
using Movies.Data.Contexts;

namespace Movies.API.Services
{
    public class DataSeedHostingService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DataSeedHostingService> _logger;

        public DataSeedHostingService(IServiceProvider serviceProvider, ILogger<DataSeedHostingService> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            if (!env.IsDevelopment()) return;

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            // === Seed Genres ===
            var genres = await dbContext.Genres.ToListAsync(cancellationToken);
            if (!genres.Any())
            {
                genres = GenreSeeder.SeedGenres();
                await dbContext.Genres.AddRangeAsync(genres, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Genres seeded.");
            }

            // === Seed Movies ===
            if (!await dbContext.Movies.AnyAsync(cancellationToken))
            {
                try
                {
                    var movies = MovieSeeder.GenerateMovies(10, genres);
                    await dbContext.Movies.AddRangeAsync(movies, cancellationToken);
                    await dbContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("Movies seeded.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error seeding Movies: {ex.Message}");
                }
            }
            // === Seed Actors ===
            if (!await dbContext.Actors.AnyAsync(cancellationToken))
            {
                var actors = Enumerable.Range(0, 10)
                    .Select(_ => ActorGenerator.GenerateActors().First()) // 1 actor loop
                    .ToList();

                await dbContext.Actors.AddRangeAsync(actors, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Actors seeded.");
            }
            // === Seed Reviews ===
            if (!await dbContext.Reviews.AnyAsync(cancellationToken))
            {               
                var reviews = Enumerable.Range(0, 20)
                    .SelectMany(_ => ReviewGenerator.GenerateReviews()) // multiple reviews / loop
                    .ToList();

                await dbContext.Reviews.AddRangeAsync(reviews, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Reviews seeded.");
            }
    
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
  
    }
}
