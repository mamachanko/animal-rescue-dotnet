using System.Collections.Generic;

namespace AnimalRescueApi.Services
{
    public class AnimalService : IAnimalService
    {
        public List<Animal> GetAnimals() => new List<Animal>
        {
            // Create two Animals by using an object initializer with {}
            new Animal {Name = "cat", Description = "Not a dog."},
            new Animal {Name = "dog", Description = "Not a cat."}
        };
    }
}
