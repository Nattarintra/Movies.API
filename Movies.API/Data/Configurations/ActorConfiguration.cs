using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Entities;

namespace Movies.API.Data.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.BirthYear);

            builder.HasMany(a => a.Movies)
                   .WithMany(m => m.Actors);
          
        }
    }
}
