using EndpointManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class Create : BaseViewModel
    {
        private readonly MeterController _meterController;
        private readonly EndpointStateController _endpointStateController;
        private readonly Menu _menu; 
        private string error = "";
        public Create()
        {
            _meterController = new MeterController();
            _endpointStateController = new EndpointStateController();
            _menu = new Menu();
        }
        public void CreateEndpoint()
        {
            var endpoint = new Models.Endpoint();
            var isValidMeterModel = false;
            var isValidMeterNumber = false;
            var isValidEndpointState = false;
            var menu = new Menu();
            Console.Clear();

            ShowHeader();

            Console.WriteLine("Write a serial number:");
            endpoint.EndpointSerialNumber = Console.ReadLine();

            var meters = _meterController.GetAllMeters();

            while (!isValidMeterModel)
            {
                ShowError();

                Console.WriteLine("\nChoose one meter model:");

                foreach(var meter in meters)
                {
                    Console.WriteLine(meter.MeterModelID + " - " + meter.MeterModel);
                }

                Console.WriteLine("Write the code of meter model you want:");
                try
                {
                    endpoint.MeterModelId = Convert.ToInt32(Console.ReadLine());
                    isValidMeterModel = true;
                }
                catch (Exception)
                {
                    error = "Just numbers are accepted.";
                }
            }

            while (!isValidMeterNumber)
            {
                ShowError();
                Console.WriteLine("\nWrite the number of Meter:");

                try
                {
                    endpoint.MeterNumber = Convert.ToInt32(Console.ReadLine());
                    isValidMeterNumber = true;
                }
                catch (Exception)
                {

                    error = "Just numbers are accepted.";
                }
            }

            Console.WriteLine("\nWrite the Meter Firmware Version:");
            endpoint.MeterFirmwareVersion = Console.ReadLine();

            var states = _endpointStateController.GetAllEndpointStates();

            while (!isValidEndpointState)
            {
                ShowError();

                Console.WriteLine("\n");

                foreach (var state in states)
                {
                    Console.WriteLine(state.EndpointStateId + " - " + state.SwitchState);
                }

                Console.WriteLine("Write the code of state you want:");
                try
                {
                    endpoint.EndpointStateId = Convert.ToInt32(Console.ReadLine());
                    isValidEndpointState = true;
                }
                catch (Exception)
                {
                    error = "Just numbers are accepted.";
                }
            }

            try
            {
                _endpointController.Create(endpoint);
                menu.ShowMenu();
            }
            catch (ArgumentNullException e)
            {
                Program.message = e.Message;
            }
            catch (ArgumentException e)
            {
                Program.message = e.Message;
            }
            catch (Exception e)
            {
                Program.message = e.Message;
            }

            _menu.ShowMenu();
        }

        private void ShowHeader()
        {
            Console.WriteLine("======================");
            Console.WriteLine("Endpoint Create Screen");
            Console.WriteLine("======================\n");
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
