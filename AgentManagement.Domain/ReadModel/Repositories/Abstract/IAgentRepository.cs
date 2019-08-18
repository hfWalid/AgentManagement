using System.Collections.Generic;

namespace AgentManagement.Domain.ReadModel.Repositories.Abstract
{
    public interface IAgentRepository : IBaseRepository<AgentRM>
    {
        IEnumerable<AgentRM> GetAll();
    }
}
