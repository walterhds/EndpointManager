using EndpointManager.AuxiliarModels;
using EndpointManager.Models;
using EndpointManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Controllers
{
    public class EndpointController : EndpointError
    {
        private readonly EndpointRepository _endpointRepository;

        public EndpointController()
        {
            _endpointRepository = new EndpointRepository();
        }

        public bool Create(Endpoint endpoint)
        {
            foreach(var propertie in endpoint.GetType().GetProperties())
            {
                if (propertie.GetValue(endpoint) == null)
                    throw new ArgumentNullException(propertie.Name);
            }

            if (!IsValidSerialNumber(endpoint.EndpointSerialNumber))
                throw new ArgumentException(SerialNumberAlreadyRegistred);

            try
            {
                _endpointRepository.Create(endpoint);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsValidSerialNumber(string serialNumber)
        {
            return _endpointRepository.GetEndpoints(e => e.EndpointSerialNumber == serialNumber).Any();
        }
    }
}
