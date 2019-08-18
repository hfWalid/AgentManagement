using System;

namespace AgentManagement.Domain.Commands
{
    public class RemoveAgentFromLocationCommand : BaseCommand
    {
        public readonly int AgentID;
        public readonly int LocationID;

        public RemoveAgentFromLocationCommand(Guid id, int locationID, int agentID)
        {
            Id = id;
            AgentID = agentID;
            LocationID = locationID;
        }
    }
}
