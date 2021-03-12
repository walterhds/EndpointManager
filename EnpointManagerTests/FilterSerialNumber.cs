using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndpointManager;
using EndpointManager.Models;
using EndpointManager.Controllers;
using System.Collections.Generic;

namespace EnpointManagerTests
{
    [TestClass]
    public class FilterSerialNumber
    {
        [TestMethod]
        public void ValidSerialNumber()
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

            Assert.IsTrue(endpointController.IsValidSerialNumber("1"));
        }

        [TestMethod]
        public void InvalidSerialNumber()
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

            Assert.IsFalse(endpointController.IsValidSerialNumber("2"));
        }
    }
}
