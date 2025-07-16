using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Entities;

namespace Movies.API.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
           builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.ReviewerName)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(r => r.Rating)
                   .IsRequired();
                  
            builder.Property(r => r.Comment)
                   .HasMaxLength(100);

            builder.Property(r => r.MovieId)
                   .IsRequired();

            // Foreign Key
            builder.HasOne(r => r.Movie)
                   .WithMany(m => m.Reviews)
                   .HasForeignKey(r => r.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
