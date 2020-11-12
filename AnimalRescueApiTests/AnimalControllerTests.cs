using System;
using System.Linq;
using AnimalRescueApi;
using AnimalRescueApi.Controllers;
using Xunit;

namespace AnimalRescueApiTests
{
    public class AnimalControllerTests
    {
        [Fact]
        public void Get_ReturnsAnimals()
        {
            var animalController = new AnimalController();

            var response = animalController.Get();
            
            Assert.Equal(2, response.Count());
            Assert.Contains(new Animal { Name = "dog", Description = "Not a cat." }, response);
            Assert.Contains(new Animal { Name = "cat", Description = "Not a dog." }, response);
        }
    }
}
