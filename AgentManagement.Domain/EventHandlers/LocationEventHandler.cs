using AgentManagement.Domain.Events.Locations;
using AgentManagement.Domain.ReadModel;
using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using AutoMapper;
using CQRSlite.Events;
using System.Threading.Tasks;

namespace AgentManagement.Domain.EventHandlers
{
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>,
                                        IEventHandler<AgentAssignedToLocationEvent>,
                                        IEventHandler<AgentRemovedFromLocationEvent>
    {
        private readonly IMapper _mapper;

        private readonly ILocationRepository _locationRepo;
        private readonly IAgentRepository _agentRepo;

        public LocationEventHandler(IMapper mapper, ILocationRepository locationRepo, IAgentRepository agentRepo)
        {
            _mapper = mapper;
            _locationRepo = locationRepo;
            _agentRepo = agentRepo;
        }

        public async Task Handle(LocationCreatedEvent message)
        {
            //Create a new LocationDTO object from the LocationCreatedEvent
            LocationRM location = _mapper.Map<LocationRM>(message);

            _locationRepo.Save(location);
        }

        public async Task Handle(AgentAssignedToLocationEvent message)
        {
            var location = _locationRepo.GetByID(message.NewLocationID);
            location.Agents.Add(message.AgentID);
            _locationRepo.Save(location);

            //Find the agent which was assigned to this Location
            var agent = _agentRepo.GetByID(message.AgentID);
            agent.LocationID = message.NewLocationID;
            _agentRepo.Save(agent);
        }

        public async Task Handle(AgentRemovedFromLocationEvent message)
        {
            var location = _locationRepo.GetByID(message.OldLocationID);
            location.Agents.Remove(message.AgentID);
            _locationRepo.Save(location);
        }
    }
}
