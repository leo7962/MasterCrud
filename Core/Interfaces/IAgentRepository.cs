using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAgentRepository
    {
        Task<Agent> CreateAgentAsync(Agent agent);
        Task<List<Agent>> GetAgentsAsync();
        Task<Agent> GetAgentAsync(int agentId);
        Task<Agent> UpdateAgentAsync(Agent agent);
        Task<bool> DeleteAgentAsync(int agentId);
    }
}