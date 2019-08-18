using AgentManagement.Domain.Events.Locations;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgentManagement.Domain.WriteModel
{
    public class Location : AggregateRoot
    {
        private int _locationID;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _postalCode;
        private List<int> _agents;

        private Location() { }

        public Location(Guid id, int locationID, string streetAddress, string city, string state, string postalCode)
        {
            Id = id;
            _locationID = locationID;
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _agents = new List<int>();

            ApplyChange(new LocationCreatedEvent(id, locationID, streetAddress, city, state, postalCode));
        }

        public void AddAgent(int agentID)
        {
            _agents.Add(agentID);
            ApplyChange(new AgentAssignedToLocationEvent(Id, _locationID, agentID));
        }

        public static explicit operator Location(Task<Location> v)
        {
            throw new NotImplementedException();
        }

        public void RemoveAgent(int agentID)
        {
            _agents.Remove(agentID);
            ApplyChange(new AgentRemovedFromLocationEvent(Id, _locationID, agentID));
        }
    }
}
