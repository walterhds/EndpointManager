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
    public class MeterController : EndpointError
    {
        private readonly MeterRepository _meterRepository;

        public MeterController()
        {
            _meterRepository = new MeterRepository();
        }

        public List<Meter> GetAllMeters() => _meterRepository.GetMeters(null).ToList();

        public bool IsValidMeter(int meterModelId) => _meterRepository.HasMeter(x => x.MeterModelID == meterModelId);
    }
}
