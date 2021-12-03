using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICityRepository
    {
        Task<City> CreateCityAsync(City city);
        Task<List<City>> GetCitiesAsync();
        Task<City> GetCityAsync(int cityId);
        Task<City> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int cityId);
    }
}