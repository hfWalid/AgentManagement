using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using System.Web.Http;

namespace AgentManagement.Queries.API.Controllers
{
    [RoutePrefix("Agents")]
    public class AgentController : ApiController
    {
        private readonly IAgentRepository _agentRepo;

        public AgentController(IAgentRepository agentRepo)
        {
            _agentRepo = agentRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var agent = _agentRepo.GetByID(id);

            //It is possible for GetByID() to return null.
            //If it does, we return HTTP 400 Bad Request
            if (agent == null)
            {
                return BadRequest("No Agent with ID " + id.ToString() + " was found.");
            }

            //Otherwise, we return the agent
            return Ok(agent);
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            var agents = _agentRepo.GetAll();
            return Ok(agents);
        }
    }
}
