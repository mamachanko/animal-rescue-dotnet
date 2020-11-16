using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescueApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AnimalRescueApi.Filters
{
    public class DataStartupFilter : IStartupFilter
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public DataStartupFilter(ILogger<DataStartupFilter> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            using var serviceScope = _serviceProvider.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<AnimalRescueContext>();
            _logger.LogInformation("Migrating DB ...");
            context.Database.Migrate();
            _logger.LogInformation("Migrating DB done.");

            if (context.Animals.Any()) return next;

            _logger.LogInformation("Hydrating data ...");
            context.Add(new Animal {Name = "Dog", Description = "Not a cat."});
            context.Add(new Animal {Name = "Cat", Description = "Not a dog."});
            context.SaveChanges();
            _logger.LogInformation("Hydrating data done.");

            return next;
        }
    }
}
