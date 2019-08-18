using AgentManagement.Domain.Commands;
using AgentManagement.Domain.WriteModel;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Messages;
using System;
using System.Threading.Tasks;

namespace AgentManagement.Domain.CommandHandlers
{
    public class LocationCommandHandler : ICommandHandler<CreateLocationCommand>,
        ICommandHandler<AssignAgentToLocationCommand>,
        ICommandHandler<RemoveAgentFromLocationCommand>
    {
        private readonly ISession _session;

        public LocationCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateLocationCommand command)
        {
            var location = new Location(command.Id, command.LocationID, command.StreetAddress, command.City, command.State, command.PostalCode);
            await _session.Add(location);
            await _session.Commit();
        }

        public async Task Handle(RemoveAgentFromLocationCommand command)
        {
            Location location = await _session.Get<Location>(command.Id);
            location.RemoveAgent(command.AgentID);
            await _session.Commit();
        }

        public async Task Handle(AssignAgentToLocationCommand command)
        {
            Location location = await _session.Get<Location>(command.Id);
            location.AddAgent(command.AgentID);
            await _session.Commit();
        }
    }
}
