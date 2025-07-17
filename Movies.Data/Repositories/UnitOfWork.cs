using Movies.Core.DomainContracts;
using Movies.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Movies.Core.DomainContracts.IMovieRepository;

namespace Movies.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IMovieRepository Movies { get; }
        public IActorRepository Actors { get; }
        public IReviewRepository Reviews { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(context);
            //Actors = new ActorRepository(context);
            //Reviews = new ReviewRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
