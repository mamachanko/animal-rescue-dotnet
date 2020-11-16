using System.Collections.Generic;
using AnimalRescueApi;
using AnimalRescueApi.Controllers;
using AnimalRescueApi.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AnimalRescueApiTests
{
    public class AnimalControllerTests
    {
        [Fact]
        public void GetAnimals_ReturnsAllAnimals()
        {
            var testAnimalService = new TestAnimalService
            {
                Animals = new List<Animal>
                {
                    new Animal {Name = "TestAnimal", Description = "Not a real animal."}
                }
            };
            var animalController = new AnimalController(testAnimalService);

            var response = animalController.Get();

            Assert.Equal(1, response.Count);
            Assert.Contains(new Animal {Name = "TestAnimal", Description = "Not a real animal."}, response);
        }

        [Fact]
        public void GetAnimal_ReturnsAnimal()
        {
            var testAnimalService = new TestAnimalService
            {
                Animals = new List<Animal>
                {
                    new Animal {ID = 123, Name = "TestAnimal", Description = "Not a real animal."}
                }
            };
            var animalController = new AnimalController(testAnimalService);

            var response = animalController.GetAnimal(123);

            Assert.Equal(new Animal {ID = 123, Name = "TestAnimal", Description = "Not a real animal."}, response.Value);
        }

        [Fact]
        public void GetAnimal_WhenAnimalDoesNotExist_Returns404()
        {
            var animalController = new AnimalController(new UnknownAnimalService());

            var response = animalController.GetAnimal(123);

            Assert.IsType<NotFoundResult>(response.Result);
        }
    }

    internal class TestAnimalService : IAnimalService
    {
        public List<Animal> Animals { get; set; }

        public List<Animal> GetAnimals() => Animals;
        public Animal GetAnimal(long id) => Animals.Find(animal => animal.ID.Equals(id));
    }

    internal class UnknownAnimalService : IAnimalService
    {
        public List<Animal> GetAnimals() => new List<Animal>();
        public Animal GetAnimal(long _) => throw new AnimalNotFoundException("sorry.");
    }
}
