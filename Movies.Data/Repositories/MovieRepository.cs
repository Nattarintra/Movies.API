using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.DomainContracts;
using Movies.Data.Contexts;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        // This class  EF  fetches data from the database and maps it to the Movie entity.?
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await _context.Movies.ToListAsync(); // Fetch all movies from the database

        public async Task<Movie?> GetAsync(Guid id) =>
            await _context.Movies.FindAsync(id); // Fetch a movie by its ID from the database

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Movies.AnyAsync(m => m.Id == id); // Check if a movie with the given ID exists in the database

        public void Add(Movie movie) => _context.Movies.Add(movie); // Add a new movie to the database
        public void Update(Movie movie) => _context.Movies.Update(movie); // Update an existing movie in the database
        public void Remove(Movie movie) => _context.Movies.Remove(movie); // Remove a movie from the database
    }
}
