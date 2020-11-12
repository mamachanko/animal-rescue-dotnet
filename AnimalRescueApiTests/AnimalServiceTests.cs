using System.Collections.Generic;
using AnimalRescueApi;
using AnimalRescueApi.Services;
using Xunit;

namespace AnimalRescueApiTests
{
    public class AnimalServiceTests
    {
        [Fact]
        public void GetAnimals_ReturnsAnimals()
        {
            var animalService = new AnimalService();

            Assert.Equal(
                new List<Animal>
                {
                    new Animal {Name = "cat", Description = "Not a dog."},
                    new Animal {Name = "dog", Description = "Not a cat."}
                },
                animalService.GetAnimals());
        }
    }
}
