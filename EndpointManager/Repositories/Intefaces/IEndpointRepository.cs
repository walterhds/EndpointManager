using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories.Intefaces
{
    internal interface IEndpointRepository
    {
        bool Create(Endpoint endpoint);
        bool Edit(string serialNumber, int endpointState);
        bool Delete(string serialNumber);
        IEnumerable<Endpoint> GetEndpoints(Func<Endpoint, bool> filter);
        bool HasEndPoint(Func<Endpoint, bool> filter);
    }
}
