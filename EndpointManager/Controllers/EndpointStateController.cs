using EndpointManager.Models;
using EndpointManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Controllers
{
    public class EndpointStateController
    {
        private readonly EndpointStateRepository _endpointStateRepository;

        public EndpointStateController()
        {
            _endpointStateRepository = new EndpointStateRepository();
        }

        public List<EndpointState> GetAllEndpointStates() => _endpointStateRepository.GetEndpointStates(null).ToList();

        public bool IsValidState(int endpointStateId) => _endpointStateRepository.HasState(x => x.EndpointStateId == endpointStateId);
    }
}
