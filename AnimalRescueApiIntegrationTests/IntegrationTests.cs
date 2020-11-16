using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AnimalRescueApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Quibble.Xunit;
using Xunit;

namespace AnimalRescueApiIntegrationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly string _integrationTestSettings = Path.Combine(
            Directory.GetCurrentDirectory(),
            "appsettings.integrationtests.json"
        );

        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.AddJsonFile(_integrationTestSettings);
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetAnimals_ReturnsAllAnimals()
        {
            var response = await _client.GetAsync("/api/animals");

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

        [Fact]
        public async Task GetAnimal_ReturnsAnimals()
        {
            var response = await _client.GetAsync("/api/animals/2");

            response.EnsureSuccessStatusCode();
            Assert.Equal(
                "application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString()
            );
            JsonAssert.Equal(
                @"{""id"": 2, ""name"": ""Cat"", ""description"": ""Not a dog.""}",
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task GetAnimal_WhenAnimalDoesNotExist_Returns404()
        {
            var response = await _client.GetAsync("/api/animals/135");

            Assert.Equal(
                HttpStatusCode.NotFound,
                response.StatusCode
            );
            Assert.Equal(
                "application/problem+json; charset=utf-8",
                response.Content.Headers.ContentType.ToString()
            );
        }
    }
}
