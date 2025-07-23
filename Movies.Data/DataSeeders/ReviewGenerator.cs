using Bogus;
using Movies.Core.Entities;

namespace Movies.Data.DataSeeders
{
    public static class ReviewGenerator
    {
        public static ICollection<Review> GenerateReviews()
        {
            var faker = new Faker();
            int count = faker.Random.Int(1, 3);

            return Enumerable.Range(0, count).Select(_ => new Review
            {
                Id = Guid.NewGuid(),
                ReviewerName = faker.Person.FullName, // กัน null
                Comment = faker.Lorem.Sentence(),
                Rating = faker.Random.Int(1, 5)
            }).ToList();
        }
    }
}
