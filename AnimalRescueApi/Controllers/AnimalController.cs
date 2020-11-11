using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescueApi.Controllers
{
    [ApiController]
    [Route("/api/animals")]
    public class AnimalController : Controller
    {
        [HttpGet]
        public IEnumerable<Animal> Get() => new[]
        {
            new Animal("cat", "Not a dog."),
            new Animal("dog", "Not a cat.")
        };
    }
}
