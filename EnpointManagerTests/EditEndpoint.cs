using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndpointManager;
using EndpointManager.Models;
using EndpointManager.Controllers;
using System.Collections.Generic;

namespace EnpointManagerTests
{
    [TestClass]
    public class EditEndpoint
    {
        [TestMethod]
        public void UpdateEndpointWithInvalidStateId()
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

            //endpoint with an invalid Meter Model Id.
            var endpoint = new Endpoint()
            {
                EndpointSerialNumber = "2",
                EndpointStateId = 5,
                MeterFirmwareVersion = "2",
                MeterModelId = 17,
                MeterNumber = 1
            };

            try
            {
                endpointController.Create(endpoint);
            }
            catch (System.Exception)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
