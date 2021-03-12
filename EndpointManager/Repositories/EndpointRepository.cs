using EndpointManager.Data;
using EndpointManager.Models;
using EndpointManager.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories
{
    public class EndpointRepository : IEndpointRepository
    {        
        public bool Create(Endpoint endpoint)
        {
            try
            {
                Program._dbContext.endpoints.Add(endpoint);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int endpoint)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Endpoint endpoint)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endpoint> GetEndpoints(Func<Endpoint, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.endpoints.DefaultIfEmpty() ?? new List<Endpoint>();
            }
            else
            {
                return Program._dbContext.endpoints.Where(filter).DefaultIfEmpty() ?? new List<Endpoint>();
            }
        }

        public bool HasEndPoint(Func<Endpoint, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.endpoints.Any();
            }
            else
            {
                return Program._dbContext.endpoints.Any(filter);
            }
        }
    }
}
