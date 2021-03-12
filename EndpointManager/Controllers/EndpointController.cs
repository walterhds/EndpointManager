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
        private readonly MeterController _meterController;
        private readonly EndpointStateController _endpointStateController;

        public EndpointController()
        {
            _endpointRepository = new EndpointRepository();
            _meterController = new MeterController();
            _endpointStateController = new EndpointStateController();
        }

        public bool Create(Endpoint endpoint)
        {
            foreach(var propertie in endpoint.GetType().GetProperties())
            {
                if (propertie.GetValue(endpoint) == null)
                    throw new ArgumentNullException(propertie.Name);
            }

            if (IsValidSerialNumber(endpoint.EndpointSerialNumber))
                throw new ArgumentException(SerialNumberAlreadyRegistred);

            if (!_meterController.IsValidMeter(endpoint.MeterModelId))
                throw new KeyNotFoundException(MeterModelNotFound);

            if (!_endpointStateController.IsValidState(endpoint.EndpointStateId))
                throw new KeyNotFoundException(StateNotFound);

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

        public bool Update(string serialNumber, int endpointState) => _endpointRepository.Edit(serialNumber, endpointState);

        public bool Delete(string serialNumber) => _endpointRepository.Delete(serialNumber);

        public bool IsValidSerialNumber(string serialNumber) => _endpointRepository.HasEndPoint(e => e.EndpointSerialNumber == serialNumber);        

        public List<Endpoint> GetEndpoints(Func<Endpoint, bool> filter)
        {
            try
            {
                if (filter == null)
                {
                    return _endpointRepository.GetEndpoints(null).ToList();
                }
                else
                {
                    return _endpointRepository.GetEndpoints(filter).ToList();
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
