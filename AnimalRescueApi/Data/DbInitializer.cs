using System.Linq;

namespace AnimalRescueApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AnimalRescueContext context)
        {
            context.Database.EnsureCreated();

            if (context.Animals.Any())
            {
                return;
            }

            var animals = new[]
            {
                new Animal {Name = "Dog", Description = "Not a cat."},
                new Animal {Name = "Cat", Description = "Not a dog."}
            };
            foreach (var animal in animals)
            {
                context.Animals.Add(animal);
            }

            context.SaveChanges();
        }
    }
}
