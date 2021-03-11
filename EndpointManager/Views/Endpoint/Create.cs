using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views.Endpoint
{
    public class Create : BaseViewModel
    {
        public Create()
        {
        }
        public void CreateEndpoint()
        {
            var endpoint = new Models.Endpoint();
            var isValidSerialNumber = false;
            var error = "";

            while (!isValidSerialNumber)
            {
                Console.Clear();

                if (!String.IsNullOrEmpty(error))
                    Console.WriteLine(error + "\n");

                Console.WriteLine("Enter with a serial number:");
                endpoint.EndpointSerialNumber = Console.ReadLine();

                isValidSerialNumber = _endpointController.IsValidSerialNumber(endpoint.EndpointSerialNumber);

                if (!isValidSerialNumber)
                    error = SerialNumberAlreadyRegistred + "(" + endpoint.EndpointSerialNumber + ")";
            }

            Console.WriteLine("Enter with the name of Meter Model:");
            var meterModel = Console.ReadLine();

            try
            {
                _endpointController.Create(endpoint);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
