using Bogus;
using Movies.Core.Entities;

namespace Movies.Data.DataSeeders
{
    public static class ActorGenerator
    {
        public static ICollection<Actor> GenerateActors()
        {
            var faker = new Faker();
            int count = faker.Random.Int(1, 3);

            return Enumerable.Range(0, count).Select(_ => new Actor
            {
                Id = Guid.NewGuid(),
                Name = faker.Person.FullName,
                BirthYear = faker.Date.Past(60, DateTime.Now.AddYears(-20)).Year
            }).ToList();
        }
    }
}
