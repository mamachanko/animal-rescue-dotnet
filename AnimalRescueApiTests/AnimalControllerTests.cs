using System.Collections.Generic;
using AnimalRescueApi;
using AnimalRescueApi.Controllers;
using AnimalRescueApi.Services;
using Xunit;

namespace AnimalRescueApiTests
{
    public class AnimalControllerTests
    {
        [Fact]
        public void Get_ReturnsAnimals()
        {
            // Arrange
            var testAnimalService = new TestAnimalService
            {
                Animals = new List<Animal>
                {
                    new Animal {Name = "TestAnimal", Description = "Not a real animal."}
                }
            };
            var animalController = new AnimalController(testAnimalService);

            // Act
            var response = animalController.Get();

            // Assert
            Assert.Equal(1, response.Count);
            Assert.Contains(new Animal {Name = "TestAnimal", Description = "Not a real animal."}, response);
        }
    }

    internal class TestAnimalService : IAnimalService
    {
        public List<Animal> Animals { get; set; }

        public List<Animal> GetAnimals() => Animals;
    }
}
