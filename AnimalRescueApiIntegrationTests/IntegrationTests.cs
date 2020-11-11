using System.Threading.Tasks;
using AnimalRescueApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AnimalRescueApiIntegrationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_ReturnsAnimals()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/animals");

            response.EnsureSuccessStatusCode();
        }
    }
}
