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
    }
}
