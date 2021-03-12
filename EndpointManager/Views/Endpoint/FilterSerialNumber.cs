using EndpointManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class FilterSerialNumber : BaseViewModel
    {
        private readonly MeterController _meterController;
        private readonly EndpointStateController _endpointStateController;
        private readonly Menu _menu;
        private readonly Edit _edit;
        private string error = "";

        public FilterSerialNumber()
        {
            _meterController = new MeterController();
            _endpointStateController = new EndpointStateController();
            _menu = new Menu();
            _edit = new Edit();
        }

        public string Filter()
        {
            var endpoint = new Models.Endpoint();
            var isValidSerialNumber = false;
            Console.Clear();

            while (!isValidSerialNumber)
            {
                isValidSerialNumber = true;
                ShowError();

                Console.WriteLine("\nWrite the serial number you want to manipulate.");
                endpoint.EndpointSerialNumber = Console.ReadLine();

                if (!_endpointController.IsValidSerialNumber(endpoint.EndpointSerialNumber))
                {
                    error = SerialNumberNotFound;
                    isValidSerialNumber = false;
                }
            }

            return endpoint.EndpointSerialNumber;
        }
        private void ShowHeader()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Endpoint Serial Number Filter Screen");
            Console.WriteLine("====================================\n");
        }

        private void ShowError()
        {
            if (!String.IsNullOrEmpty(error))
            {
                Console.Clear();
                ShowHeader();
                Console.WriteLine(error);
                error = "";

                Console.WriteLine("Do you want to back to Menu? (y/n)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    _menu.ShowMenu();
                }
            }
        }
    }
}
