using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contexts
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<City> CreateCityAsync(City city)
        {
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            var entity = await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
            return entity;
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetCityAsync(city.Id);
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var exists = await _context.Cities.AnyAsync(x => x.Id == cityId);
            if (!exists) return false;

            _context.Remove(new City {Id = cityId});
            await _context.SaveChangesAsync();
            return true;
        }
    }
}