using EndpointManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class List : BaseViewModel
    {
        public void ListEndpoint(string serialNumber)
        {
            try
            {
                var endpoints = new List<Models.Endpoint>();
                if (String.IsNullOrEmpty(serialNumber))
                    endpoints = _endpointController.GetEndpoints(null);
                else
                    endpoints = _endpointController.GetEndpoints(x => x.EndpointSerialNumber == serialNumber);

                ShowHeader();

                if (endpoints.Count > 0)
                {
                    foreach (var endpoint in endpoints)
                    {
                        foreach (var propertie in endpoint.GetType().GetProperties())
                        {
                            Console.WriteLine(propertie.Name + ": " + propertie.GetValue(endpoint));
                        }

                        Console.WriteLine("\n=============================\n");
                    }

                    Console.WriteLine("Press any key to back to menu.");
                    Console.ReadKey();
                }
                else
                {
                    Program.message = EmptyEndpoint;
                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine(EmptyEndpoint);
            }            
        }

        private void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("Endpoint List Screen");
            Console.WriteLine("====================\n\n");
        }
    }
}
