using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.AuxiliarModels
{
    public class EndpointError
    {
        public const string SerialNumberAlreadyRegistred = "This serial number is alredy registred.";
        public const string SerialNumberNotFound = "Serial number not found.";
        public const string MeterModelNotFound = "Meter model not found.";
        public const string StateNotFound = "State not found.";
        public const string EmptyEndpoint = "The list of endpoint is empty.";
    }
}
