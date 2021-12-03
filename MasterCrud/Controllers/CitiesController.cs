using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using MasterCrud.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterCrud.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var citiesList = await _cityRepository.GetCitiesAsync();
            var citiesDto = _mapper.Map<List<CityDto>>(citiesList);
            return Ok(citiesDto);
        }

        [HttpGet("{id:int}", Name = "obtenerCiudad")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _cityRepository.GetCityAsync(id);
            if (city == null) return NotFound();

            var cityDto = _mapper.Map<CityDto>(city);
            return Ok(cityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityCreateDto cityCreateDto)
        {
            var entity = _mapper.Map<City>(cityCreateDto);
            var city = await _cityRepository.CreateCityAsync(entity);
            var cityDto = _mapper.Map<CityDto>(city);
            return new CreatedAtRouteResult("obtenerCiudad", new {id = cityDto.Id}, cityDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CityCreateDto cityCreateDto)
        {
            var entity = _mapper.Map<City>(cityCreateDto);
            entity.Id = id;
            await _cityRepository.UpdateCityAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _cityRepository.DeleteCityAsync(id);
            if (!exist) return NotFound();

            return NoContent();
        }
    }
}