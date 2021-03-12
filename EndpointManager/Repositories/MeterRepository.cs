using EndpointManager.Models;
using EndpointManager.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Repositories
{
    public class MeterRepository : IMeterRepository
    {
        public IEnumerable<Meter> GetMeters(Func<Meter, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.meters;
            }
            else
            {
                return Program._dbContext.meters.Where(filter).DefaultIfEmpty();
            }
        }

        public bool HasMeter(Func<Meter, bool> filter)
        {
            if (filter == null)
            {
                return Program._dbContext.meters.Any();
            }
            else
            {
                return Program._dbContext.meters.Any(filter);
            }
        }
    }
}
