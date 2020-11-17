using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescueApi.Data;

namespace AnimalRescueApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalRescueContext _context;

        public AnimalService(AnimalRescueContext context)
        {
            _context = context;
        }

        public List<Animal> GetAnimals() => _context.Animals.ToList();

        public Animal GetAnimal(long id) =>
            _context.Animals.Find(id)
            ?? throw new AnimalNotFoundException($"Animal with id {id} does not exist");
    }

    public class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException(string message) : base(message)
        {
        }
    }
}
