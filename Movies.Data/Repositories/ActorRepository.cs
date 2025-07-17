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
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Actor>> GetAllAsync() =>
            await _context.Actors.ToListAsync();

        public async Task<Actor?> GetAsync(Guid id) =>
            await _context.Actors.FindAsync(id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Actors.AnyAsync(m => m.Id == id);

        public void Add(Actor actor) => _context.Actors.Add(actor);
        public void Update(Actor actor) => _context.Actors.Update(actor);
        public void Remove(Actor actor) => _context.Actors.Remove(actor);
    }
}
