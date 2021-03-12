using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndpointManager;
using EndpointManager.Models;
using EndpointManager.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace EnpointManagerTests
{
    [TestClass]
    public class ListEndpoint
    {
        [TestMethod]
        public void ListAll()
        {
            var endpointController = new EndpointController();

            //List to simulate endpoints already registred
            var endpoints = new List<Endpoint>()
            {
                new Endpoint()
                {
                    EndpointSerialNumber = "1",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "2",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "3",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                }
            };

            Program._dbContext.endpoints = endpoints;

            var countDb = endpoints.Count;

            Assert.AreEqual(countDb, endpointController.GetEndpoints(null).Count);
        }

        [TestMethod]
        public void LisEspecific()
        {
            var endpointController = new EndpointController();

            //List to simulate endpoints already registred
            var endpoints = new List<Endpoint>()
            {
                new Endpoint()
                {
                    EndpointSerialNumber = "1",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "2",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "3",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                }
            };

            Program._dbContext.endpoints = endpoints;

            Assert.AreEqual("2", endpointController.GetEndpoints(x => x.EndpointSerialNumber == "2").FirstOrDefault().EndpointSerialNumber);
        }

        [TestMethod]
        public void NullException()
        {
            var endpointController = new EndpointController();

            //List to simulate endpoints already registred
            var endpoints = new List<Endpoint>()
            {
                new Endpoint()
                {
                    EndpointSerialNumber = "1",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "2",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                },
                new Endpoint()
                {
                    EndpointSerialNumber = "3",
                    EndpointStateId = 0,
                    MeterFirmwareVersion = "1",
                    MeterModelId = 16,
                    MeterNumber = 1
                }
            };

            Program._dbContext.endpoints = endpoints;

            try
            {
                var teste = endpointController.GetEndpoints(x => x.EndpointSerialNumber == "4");
            }
            catch (System.Exception)
            {

                return;
            }

            Assert.Fail();
        }
    }
}
