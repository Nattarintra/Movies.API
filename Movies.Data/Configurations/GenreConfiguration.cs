using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Entities;

namespace Movies.API.Data.Configurations
{
    public class GenreConfiguration: IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.HasIndex(g => g.Name).IsUnique();

            builder.HasMany(m => m.Movies)
                   .WithOne(g => g.Genre)
                   .HasForeignKey(m => m.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
   
    }
 
}
