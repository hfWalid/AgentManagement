using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using System.Web.Http;

namespace AgentManagement.Queries.API.Controllers
{
    [RoutePrefix("location")]
    public class LocationController : ApiController
    {
        private ILocationRepository _locationRepo;

        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var location = _locationRepo.GetByID(id);
            if (location == null)
            {
                return BadRequest("No location with ID " + id.ToString() + " was found.");
            }
            return Ok(location);
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            var locations = _locationRepo.GetAll();
            return Ok(locations);
        }

        [HttpGet]
        [Route("{id}/agents")]
        public IHttpActionResult GetAgents(int id)
        {
            var agents = _locationRepo.GetAgents(id);
            return Ok(agents);
        }
    }
}
