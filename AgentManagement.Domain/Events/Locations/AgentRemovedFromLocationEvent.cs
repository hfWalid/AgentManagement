using System;

namespace AgentManagement.Domain.Events.Locations
{
    public class AgentRemovedFromLocationEvent : BaseEvent
    {
        public readonly int OldLocationID;
        public readonly int AgentID;

        public AgentRemovedFromLocationEvent(Guid id, int oldLocationID, int agentID)
        {
            Id = id;
            OldLocationID = oldLocationID;
            AgentID = agentID;
        }
    }
}
