using Core.Entities;
using Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class Seed
    {
        public static async Task SeedAsync(DataContext context)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.Cities.Any())
                {
                    if (path != null)
                    {
                        var citiesData = await File.ReadAllTextAsync(
                            @"C:/Users/Ingen/RiderProjects/MasterCrud/Infrastructure/Data/File/cities.json");
                        var cities = JsonSerializer.Deserialize<List<City>>(citiesData);
                        if (cities != null)
                            foreach (var city in cities)
                                context.Cities.Add(city);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}