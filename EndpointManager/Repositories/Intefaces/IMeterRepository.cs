using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories.Intefaces
{
    internal interface IMeterRepository
    {
        IEnumerable<Meter> GetMeters(Func<Meter, bool> filter);
        bool HasMeter(Func<Meter, bool> filter);
    }
}
