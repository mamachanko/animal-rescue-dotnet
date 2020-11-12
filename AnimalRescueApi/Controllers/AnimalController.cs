using System.Collections.Generic;
using AnimalRescueApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescueApi.Controllers
{
    [ApiController]
    [Route("/api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public List<Animal> Get() => _animalService.GetAnimals();
    }
}
