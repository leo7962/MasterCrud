using AutoMapper;
using Core.Entities;
using MasterCrud.Dtos;

namespace MasterCrud.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityCreateDto, City>();
            CreateMap<Agent, AgentDto>().ReverseMap();
            CreateMap<AgentCreateDto, Agent>();
        }
    }
}
