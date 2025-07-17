using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.DomainContracts;
using Movies.Data.Contexts;

namespace Movies.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await _context.Movies.ToListAsync();

        public async Task<Movie?> GetAsync(Guid id) =>
            await _context.Movies.FindAsync(id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Movies.AnyAsync(m => m.Id == id);

        public void Add(Movie movie) => _context.Movies.Add(movie);
        public void Update(Movie movie) => _context.Movies.Update(movie);
        public void Remove(Movie movie) => _context.Movies.Remove(movie);
    }
}
