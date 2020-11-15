using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescueApi;
using AnimalRescueApi.Data;
using AnimalRescueApi.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AnimalRescueApiTests
{
    public class AnimalServiceTests
    {
        [Fact]
        public void GetAnimals_ReturnsAnimals()
        {
            var animalService = new AnimalService(CreateTestContext(
                new Animal {Name = "TestAnimal1", Description = "TestAnimal1 description"},
                new Animal {Name = "TestAnimal2", Description = "TestAnimal1 description"}
            ));

            Assert.Equal(
                new List<Animal>
                {
                    new Animal {Name = "TestAnimal1", Description = "TestAnimal1 description"},
                    new Animal {Name = "TestAnimal2", Description = "TestAnimal1 description"}
                },
                animalService.GetAnimals());
        }

        private static AnimalRescueContext CreateTestContext(params Animal[] animals)
        {
            var options = new DbContextOptionsBuilder<AnimalRescueContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new AnimalRescueContext(options);
            context.Database.EnsureCreated();

            foreach (var animal in animals)
            {
                context.Add(animal);
            }

            context.SaveChanges();
            return context;
        }
    }
}
