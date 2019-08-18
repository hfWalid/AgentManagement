using AgentManagement.Domain.ReadModel.Repositories.Abstract;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace AgentManagement.Domain.ReadModel.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "location") { }

        public LocationRM GetByID(int locationID)
        {
            return Get<LocationRM>(locationID);
        }

        public List<LocationRM> GetMultiple(List<int> locationIDs)
        {
            return GetMultiple(locationIDs);
        }

        public bool HasAgent(int locationID, int agentID)
        {
            //Deserialize the LocationDTO with the key location:{locationID}
            var location = Get<LocationRM>(locationID);

            //If that location has the specified Agent, return true
            return location.Agents.Contains(agentID);
        }

        public IEnumerable<LocationRM> GetAll()
        {
            return Get<List<LocationRM>>("all");
        }
        public IEnumerable<AgentRM> GetAgents(int locationID)
        {
            return Get<List<AgentRM>>(locationID.ToString() + ":agents");
        }

        public void Save(LocationRM location)
        {
            Save(location.LocationID, location);
            MergeIntoAllCollection(location);
        }

        private void MergeIntoAllCollection(LocationRM location)
        {
            List<LocationRM> allLocations = new List<LocationRM>();
            if (Exists("all"))
            {
                allLocations = Get<List<LocationRM>>("all");
            }

            //If the district already exists in the ALL collection, remove that entry
            if (allLocations.Any(x => x.LocationID == location.LocationID))
            {
                allLocations.Remove(allLocations.First(x => x.LocationID == location.LocationID));
            }

            //Add the modified district to the ALL collection
            allLocations.Add(location);

            Save("all", allLocations);
        }
    }
}
