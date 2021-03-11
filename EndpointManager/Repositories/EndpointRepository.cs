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
        private readonly DbContext _dbContext;

        public EndpointRepository()
        {
            _dbContext = new DbContext();
        }
        public bool Create(Endpoint endpoint)
        {
            try
            {
                _dbContext.endpoints.Add(endpoint);

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
            return _dbContext.endpoints.Where(filter).DefaultIfEmpty() ?? new List<Endpoint>();
        }
    }
}
