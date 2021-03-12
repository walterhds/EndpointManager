using EndpointManager.Controllers;
using EndpointManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class Delete : BaseViewModel
    {
        private readonly MeterController _meterController;
        private readonly EndpointStateController _endpointStateController;
        private readonly Menu _menu;
        private string error = "";

        public Delete()
        {
            _meterController = new MeterController();
            _endpointStateController = new EndpointStateController();
            _menu = new Menu();
        }

        public void DeleteEndpoint(string serialNumber)
        {
            var endpoint = new Models.Endpoint();

            endpoint = _endpointController.GetEndpoints(x => x.EndpointSerialNumber == serialNumber).FirstOrDefault();

            Console.Clear();

            ShowHeader();
            ShowError();

            Console.WriteLine("\nAre you sure you want to delete this endpoint?(y/n): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                _endpointController.
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
