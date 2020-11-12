using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescueApi.Controllers
{
    [ApiController]
    [Route("/api/animals")]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Animal> Get() => new[]
        {
            // Create two Animals by using an object initializer with {}
            new Animal {Name = "cat", Description = "Not a dog."},
            new Animal {Name = "dog", Description = "Not a cat."}
        };
    }
}
