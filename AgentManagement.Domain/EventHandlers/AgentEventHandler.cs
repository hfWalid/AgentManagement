using AgentManagement.Domain.Events.Agents;
using AgentManagement.Domain.ReadModel;
using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using AutoMapper;
using CQRSlite.Events;
using System.Threading.Tasks;

namespace AgentManagement.Domain.EventHandlers
{
    public class AgentEventHandler : IEventHandler<AgentCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IAgentRepository _agentRepo;

        public AgentEventHandler(IMapper mapper, IAgentRepository agentRepo)
        {
            _mapper = mapper;
            _agentRepo = agentRepo;
        }

        public async Task Handle(AgentCreatedEvent message)
        {
            AgentRM agent = _mapper.Map<AgentRM>(message);

            _agentRepo.Save(agent);
        }
    }
}
