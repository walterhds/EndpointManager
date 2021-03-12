using EndpointManager.Models;
using EndpointManager.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories
{
    public class EndpointStateRepository : IEndpointStateRepository
    {
        public IEnumerable<EndpointState> GetEndpointStates(Func<EndpointState, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.endpointStates;
            }
            else
            {
                return Program._dbContext.endpointStates.Where(filter).DefaultIfEmpty();
            }
        }

        public bool HasState(Func<EndpointState, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.endpointStates.Any();
            }
            else
            {
                return Program._dbContext.endpointStates.Any(filter);
            }
        }
    }
}
