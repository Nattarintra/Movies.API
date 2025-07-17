using Microsoft.EntityFrameworkCore;
using Movies.Core.DomainContracts;
using Movies.Core.Entities;
using Movies.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Review>> GetAllAsync() =>
            await _context.Reviews.ToListAsync();

        public async Task<Review?> GetAsync(Guid id) =>
            await _context.Reviews.FindAsync(id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Reviews.AnyAsync(m => m.Id == id);
        public void Add(Review review) => _context.Reviews.Add(review);
        public void Update(Review review) => _context.Reviews.Update(review);
        public void Remove(Review review) => _context.Reviews.Remove(review);
    }
}
