using EndpointManager.Controllers;
using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class Edit : BaseViewModel
    {
        private readonly MeterController _meterController;
        private readonly EndpointStateController _endpointStateController;
        private string error = "";

        public Edit()
        {
            _meterController = new MeterController();
            _endpointStateController = new EndpointStateController();
        }

        public void EditEndpoint(string serialNumber)
        {
            var endpoint = new Models.Endpoint();
            var state = new EndpointState();
            var states = new List<EndpointState>();

            endpoint = _endpointController.GetEndpoints(x => x.EndpointSerialNumber == serialNumber).FirstOrDefault();
            state = _endpointStateController.GetEndpointState(endpoint.EndpointStateId);
            states = _endpointStateController.GetAllEndpointStates();

            Console.Clear();

            ShowHeader();
            ShowError();

            Console.WriteLine("The actual State is: " + state.SwitchState);
            Console.WriteLine("\nChoose one to change: ");

            foreach (var item in states)
            {
                Console.WriteLine(item.EndpointStateId + " - " + item.SwitchState);
            }

            Console.WriteLine("Write the code of state you want:");
            try
            {
                int stateId = Convert.ToInt32(Console.ReadLine());
                _endpointController.Update(serialNumber, stateId);

                Program.message = "The update of endpoint was succeeded.";
            }
            catch (Exception)
            {
                error = "Just numbers are accepted.";
                EditEndpoint(serialNumber);
            }
        }
        private void ShowHeader()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Endpoint Edit Screen");
            Console.WriteLine("====================\n\n");
        }

        private void ShowError()
        {
            if (!String.IsNullOrEmpty(error))
            {
                Console.Clear();
                ShowHeader();
                Console.WriteLine(error);
                error = "";
            }
        }
    }
}
