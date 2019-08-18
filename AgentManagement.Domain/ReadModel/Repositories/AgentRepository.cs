using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace AgentManagement.Domain.ReadModel.Repositories
{
    public class AgentRepository : BaseRepository, IAgentRepository
    {
        public AgentRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "agent") { }

        public AgentRM GetByID(int agentID)
        {
            return Get<AgentRM>(agentID);
        }

        public List<AgentRM> GetMultiple(List<int> agentIDs)
        {
            return GetMultiple<AgentRM>(agentIDs);
        }

        public IEnumerable<AgentRM> GetAll()
        {
            return Get<List<AgentRM>>("all");
        }

        public void Save(AgentRM agent)
        {
            Save(agent.AgentID, agent);
            MergeIntoAllCollection(agent);
        }

        private void MergeIntoAllCollection(AgentRM agent)
        {
            List<AgentRM> allAgents = new List<AgentRM>();
            if (Exists("all"))
            {
                allAgents = Get<List<AgentRM>>("all");
            }

            //If the district already exists in the ALL collection, remove that entry
            if (allAgents.Any(x => x.AgentID == agent.AgentID))
            {
                allAgents.Remove(allAgents.First(x => x.AgentID == agent.AgentID));
            }

            //Add the modified district to the ALL collection
            allAgents.Add(agent);

            Save("all", allAgents);
        }
    }
}
