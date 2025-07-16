using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Entities;

namespace Movies.API.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(m => m.Year);

            builder.Property(m => m.Duration);

            builder.HasOne(m => m.MovieDetails)
                   .WithOne(md => md.Movie)
                   .HasForeignKey<MovieDetails>(md => md.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(g => g.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Reviews)
                   .WithOne(r => r.Movie)
                   .HasForeignKey(r => r.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Actors)
                   .WithMany(a => a.Movies);
        }
    }
}
