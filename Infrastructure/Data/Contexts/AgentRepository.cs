using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contexts
{
    public class AgentRepository : IAgentRepository
    {
        private readonly DataContext _context;

        public AgentRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Agent> CreateAgentAsync(Agent agent)
        {
            await _context.AddAsync(agent);
            await _context.SaveChangesAsync();
            return agent;
        }

        public async Task<List<Agent>> GetAgentsAsync()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task<Agent> GetAgentAsync(int agentId)
        {
            var entity = await _context.Agents.FirstOrDefaultAsync(x => x.Id == agentId);
            return entity;
        }

        public async Task<Agent> UpdateAgentAsync(Agent agent)
        {
            _context.Entry(agent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetAgentAsync(agent.Id);
        }

        public async Task<bool> DeleteAgentAsync(int agentId)
        {
            var exists = await _context.Agents.AnyAsync(x => x.Id == agentId);
            if (!exists) return false;

            _context.Remove(new City {Id = agentId});
            await _context.SaveChangesAsync();
            return true;
        }
    }
}