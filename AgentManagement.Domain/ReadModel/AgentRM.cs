using System;

namespace AgentManagement.Domain.ReadModel
{
    public class AgentRM
    {
        public int AgentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public int LocationID { get; set; }
        public Guid AggregateID { get; set; }
    }
}
