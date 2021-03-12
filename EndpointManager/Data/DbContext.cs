using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Data
{
    public class DbContext
    {
        public readonly List<Meter> meters;
        public readonly List<EndpointState> endpointStates;
        public List<Endpoint> endpoints { get; set; }

        public DbContext()
        {
            meters = new List<Meter> {
                new Meter()
                {
                    MeterModelID = 16,
                    MeterModel = "NSX1P2W"
                },
                new Meter()
                {
                    MeterModelID = 17,
                    MeterModel = "NSX1P3W"
                },
                new Meter()
                {
                    MeterModelID = 18,
                    MeterModel = "NSX2P3W"
                },
                new Meter()
                {
                    MeterModelID = 19,
                    MeterModel = "NSX3P4W"
                }
            };

            endpointStates = new List<EndpointState>
            {
                new EndpointState()
                {
                    EndpointStateId = 0,
                    SwitchState = "Disconnected"
                },
                new EndpointState()
                {
                    EndpointStateId = 1,
                    SwitchState = "Connected"
                },
                new EndpointState()
                {
                    EndpointStateId = 2,
                    SwitchState = "Armed"
                }
            };

            endpoints = new List<Endpoint>();
        }
    }
}
