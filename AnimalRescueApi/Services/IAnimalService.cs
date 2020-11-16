using System.Collections.Generic;

namespace AnimalRescueApi.Services
{
    public interface IAnimalService
    {
        List<Animal> GetAnimals();
        Animal GetAnimal(long id);
    }
}
