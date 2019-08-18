using AgentManagement.Domain.Events.Agents;
using CQRSlite.Domain;
using System;

namespace AgentManagement.Domain.WriteModel
{
    public class Agent : AggregateRoot
    {
        private int _agentID;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _jobTitle;

        public Agent() { }

        public Agent(Guid id, int agentID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            _agentID = agentID;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _jobTitle = jobTitle;

            //TODO: Apply Events
            ApplyChange(new AgentCreatedEvent(id, agentID, firstName, lastName, dateOfBirth, jobTitle));
        }
    }
}
