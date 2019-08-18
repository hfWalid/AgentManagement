using System;

namespace AgentManagement.Domain.Commands
{
    public class CreateAgentCommand : BaseCommand
    {
        public readonly int AgentID;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateOfBirth;
        public readonly string JobTitle;

        public CreateAgentCommand(Guid id, int agentID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            AgentID = agentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }
    }
}
