using System.Collections.Generic;
using AnimalRescueApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescueApi.Controllers
{
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        [Route("/api/animals")]
        public List<Animal> Get() => _animalService.GetAnimals();

        [HttpGet]
        [Route("/api/animals/{id}")]
        public ActionResult<Animal> GetAnimal(long id)
        {
            try
            {
                return _animalService.GetAnimal(id);
            }
            catch (AnimalNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
