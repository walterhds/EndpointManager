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

        public bool Delete(string serialNumber)
        {
            try
            {
                var endpoint = GetEndpoints(x => x.EndpointSerialNumber == serialNumber).FirstOrDefault();
                Program._dbContext.endpoints.Remove(endpoint);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Edit(string serialNumber, int endpointState)
        {
            try
            {
                var endpoint = Program._dbContext.endpoints.Where(x => x.EndpointSerialNumber == serialNumber).FirstOrDefault();

                endpoint.EndpointStateId = endpointState;

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Endpoint> GetEndpoints(Func<Endpoint, bool> filter)
        {
            try
            {
                if (filter == null)
                {
                    return Program._dbContext.endpoints;
                }
                else
                {
                    return Program._dbContext.endpoints.Where(filter);
                }
            }
            catch (NullReferenceException)
            {
                throw;
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
