using System;

namespace AgentManagement.Domain.Events.Locations
{
    public class AgentAssignedToLocationEvent : BaseEvent
    {
        public readonly int NewLocationID;
        public readonly int AgentID;

        public AgentAssignedToLocationEvent(Guid id, int newLocationID, int agentID)
        {
            Id = id;
            NewLocationID = newLocationID;
            AgentID = agentID;
        }
    }
}
