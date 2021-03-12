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
        public void ListEndpoint()
        {
            try
            {
                var endpoints = _endpointController.GetEndpoints(null);

                Console.Clear();

                if (endpoints.Count == 0)
                    Program.message = EmptyEndpoint;

                foreach (var endpoint in endpoints)
                {
                    foreach (var propertie in endpoint.GetType().GetProperties())
                    {
                        Console.WriteLine(propertie.Name + ": " + propertie.GetValue(endpoint));
                    }

                    Console.WriteLine("\n=============================\n");
                    Console.WriteLine("Press any key to back to menu.");
                    Console.ReadKey();
                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine(EmptyEndpoint);
            }            
        }

        private void ShowHeader()
        {
            Console.WriteLine("====================");
            Console.WriteLine("Endpoint List Screen");
            Console.WriteLine("====================\n\n");
        }
    }
}
