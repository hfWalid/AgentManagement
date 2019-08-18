using System.Collections.Generic;

namespace AgentManagement.Domain.ReadModel.Repositories.Abstract
{
    public interface ILocationRepository : IBaseRepository<LocationRM>
    {
        IEnumerable<LocationRM> GetAll();
        IEnumerable<AgentRM> GetAgents(int locationID);
        bool HasAgent(int locationID, int agentID);
    }
}
