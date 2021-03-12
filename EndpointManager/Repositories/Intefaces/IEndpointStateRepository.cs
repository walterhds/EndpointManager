using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories.Intefaces
{
    internal interface IEndpointStateRepository
    {
        IEnumerable<EndpointState> GetEndpointStates(Func<EndpointState, bool> filter);
        bool HasState(Func<EndpointState, bool> filter);
    }
}
