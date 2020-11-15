using System.Threading.Tasks;
using AnimalRescueApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Quibble.Xunit;
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
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/animals");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(
                "application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString()
            );
            JsonAssert.Equal(
                @"[
                    {""id"": 1, ""name"": ""Dog"", ""description"": ""Not a cat.""},
                    {""id"": 2, ""name"": ""Cat"", ""description"": ""Not a dog.""}
                ]",
                await response.Content.ReadAsStringAsync()
            );
        }
    }
}
