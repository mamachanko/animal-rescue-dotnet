using System;
using System.Collections.Generic;
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
                new Animal {ID = 123, Name = "TestAnimal1", Description = "TestAnimal1 description"},
                new Animal {ID = 456, Name = "TestAnimal2", Description = "TestAnimal1 description"}
            ));

            Assert.Equal(
                new List<Animal>
                {
                    new Animal {ID = 123, Name = "TestAnimal1", Description = "TestAnimal1 description"},
                    new Animal {ID = 456, Name = "TestAnimal2", Description = "TestAnimal1 description"}
                },
                animalService.GetAnimals());
        }

        [Fact]
        public void GetAnimal_ReturnsAnimal()
        {
            var animalService = new AnimalService(CreateTestContext(
                new Animal {ID = 123, Name = "TestAnimal1", Description = "TestAnimal1 description"},
                new Animal {ID = 456, Name = "TestAnimal2", Description = "TestAnimal1 description"}
            ));

            Assert.Equal(
                new Animal {ID = 456, Name = "TestAnimal2", Description = "TestAnimal1 description"},
                animalService.GetAnimal(456)
            );
        }

        [Fact]
        public void GetAnimal_WhenItDoesNotExist_Throws()
        {
            var animalService = new AnimalService(CreateTestContext());

            Assert.Throws<AnimalNotFoundException>(() => animalService.GetAnimal(456));
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
