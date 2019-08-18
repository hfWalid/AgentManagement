using System;

namespace AgentManagement.Domain.Commands
{
    public class AssignAgentToLocationCommand : BaseCommand
    {
        public readonly int AgentID;
        public readonly int LocationID;

        public AssignAgentToLocationCommand(Guid id, int locationID, int agentID)
        {
            Id = id;
            AgentID = agentID;
            LocationID = locationID;
        }
    }
}
