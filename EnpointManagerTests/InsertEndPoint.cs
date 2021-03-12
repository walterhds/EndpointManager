using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndpointManager;
using EndpointManager.Models;
using EndpointManager.Controllers;
using System.Collections.Generic;

namespace EnpointManagerTests
{
    [TestClass]
    public class InsertEndPoint
    {
        [TestMethod]
        public void TestSerialNumberAlreadyRegistred()
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
                }
            };

            Program._dbContext.endpoints = endpoints;

            //New endpoint with a serial number already registred.
            var newEndpoint = new Endpoint()
            {
                EndpointSerialNumber = "1",
                EndpointStateId = 1,
                MeterFirmwareVersion = "2",
                MeterModelId = 17,
                MeterNumber = 1
            };

            try
            {
                endpointController.Create(newEndpoint);
            }
            catch (System.Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void InsertEndpointWithInvalidMeterModelID()
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
                }
            };

            Program._dbContext.endpoints = endpoints;

            //New endpoint with an invalid Meter Model Id.
            var newEndpoint = new Endpoint()
            {
                EndpointSerialNumber = "2",
                EndpointStateId = 1,
                MeterFirmwareVersion = "2",
                MeterModelId = 1,
                MeterNumber = 1
            };

            try
            {
                endpointController.Create(newEndpoint);
            }
            catch (System.Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void InsertEndpointWithInvalidStateId()
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
                }
            };

            Program._dbContext.endpoints = endpoints;

            //New endpoint with an invalid Meter Model Id.
            var newEndpoint = new Endpoint()
            {
                EndpointSerialNumber = "2",
                EndpointStateId = 5,
                MeterFirmwareVersion = "2",
                MeterModelId = 17,
                MeterNumber = 1
            };

            try
            {
                endpointController.Create(newEndpoint);
            }
            catch (System.Exception)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
