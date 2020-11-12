using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescueApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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

    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<PageOptions> _pageOptions;

        public ConfigController(IConfiguration configuration, IOptions<PageOptions> pageOptions)
        {
            _configuration = configuration;
            _pageOptions = pageOptions;
        }

        [HttpGet]
        [Route("/api/config")]
        public List<string> GetConfig() =>
            ((IConfigurationRoot) _configuration)
            .Providers
            .Select(provider => provider.ToString())
            .ToList();

        [HttpGet]
        [Route("/api/config/page")]
        public PageOptions GetPageConfig() => _pageOptions.Value;
    }
}
