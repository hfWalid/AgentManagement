using System.Threading.Tasks;
using AgentManagement.Domain.Commands;
using AgentManagement.Domain.WriteModel;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Messages;

namespace AgentManagement.Domain.CommandHandlers
{
    public class AgentCommandHandler : ICommandHandler<CreateAgentCommand>
    {
        //ISession cts as a gateway into the data loaded into our Event Store. It is similar to Entity Framework's DataContext class.
        private readonly ISession _session;

        public AgentCommandHandler(ISession session)
        {
            _session = session;
        }

        async Task IHandler<CreateAgentCommand>.Handle(CreateAgentCommand command)
        {
            Agent agent = new Agent(command.Id, command.AgentID, command.FirstName, command.LastName, command.DateOfBirth, command.JobTitle);
            await _session.Add(agent);
            await _session.Commit();
        }
    }
}
