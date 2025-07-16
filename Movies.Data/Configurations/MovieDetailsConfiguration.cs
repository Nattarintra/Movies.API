using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Entities;

namespace Movies.API.Data.Configurations
{
    public class MovieDetailsConfiguration : IEntityTypeConfiguration<MovieDetails>
    {
        public void Configure(EntityTypeBuilder<MovieDetails> builder)
        {
            builder.ToTable("MovieDetails");

            builder.HasKey(m => m.Id);

            builder.Property(md => md.Synopsis)
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(md => md.Language)
                     .HasMaxLength(20)
                     .IsRequired();

            builder.Property(md => md.Budget);

            builder.Property(md => md.MovieId)
                   .IsRequired();

        }
    }
}
