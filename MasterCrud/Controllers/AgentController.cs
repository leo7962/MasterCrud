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
    [Route("api/vendedores")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public AgentController(IAgentRepository agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agentsList = await _agentRepository.GetAgentsAsync();
            var agentDto = _mapper.Map<List<AgentDto>>(agentsList);
            return Ok(agentDto);
        }

        [HttpGet("{id:int}", Name = "obtenerVendedor")]
        public async Task<IActionResult> Get(int id)
        {
            var agent = await _agentRepository.GetAgentAsync(id);
            if (agent == null) return NotFound();

            var agentDto = _mapper.Map<AgentDto>(agent);
            return Ok(agentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgentCreateDto agentCreateDto)
        {
            var entity = _mapper.Map<Agent>(agentCreateDto);
            var agent = await _agentRepository.CreateAgentAsync(entity);
            var agentDto = _mapper.Map<AgentDto>(agent);
            return new CreatedAtRouteResult("obtenerVendedor", new {id = agentDto.Id}, agentDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] AgentCreateDto agentCreateDto)
        {
            var entity = _mapper.Map<Agent>(agentCreateDto);
            entity.Id = id;
            await _agentRepository.UpdateAgentAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _agentRepository.DeleteAgentAsync(id);
            if (!exist) return NotFound();

            return NoContent();
        }
    }
}