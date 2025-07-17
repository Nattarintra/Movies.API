using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.API.Data.Configurations;
using Movies.Core.Entities;

namespace Movies.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<MovieDetails> MoviesDetails { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
        }
    }
}
