using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views
{
    public class Menu
    {
        private static Endpoint.Create createView = new Endpoint.Create();
        private static Endpoint.FilterSerialNumber filterSerialNumber = new Endpoint.FilterSerialNumber();
        private static Endpoint.Edit editView = new Endpoint.Edit();
        public void ShowMenu()
        {
            Console.Clear();
            if (Program.message != "")
            {
                Console.WriteLine(Program.message + "\n\n");
            }

            Console.WriteLine("Please, choose one option:");
            Console.WriteLine(" 1- Insert a new endpoint;");
            Console.WriteLine(" 2- Edit an existing endpoint;");
            Console.WriteLine(" 3- Delete an existing endpoint;");
            Console.WriteLine(" 4- List all endpoints;");
            Console.WriteLine(" 5- Find a Endpoint by \"Endpoint Serial Number\";");
            Console.WriteLine(" 6- Exit;");
            var choise = Console.ReadKey();

            switch (choise.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    try
                    {
                        createView.CreateEndpoint();
                    }
                    catch (Exception e)
                    {
                        Program.message = e.Message;
                        ShowMenu();
                    }

                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    try
                    {
                        string serialNumber = filterSerialNumber.Filter();
                        editView.EditEndpoint(serialNumber);

                    }
                    catch (Exception e)
                    {
                        Program.message = e.Message;
                        ShowMenu();
                    }

                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    try
                    {
                        string serialNumber = filterSerialNumber.Filter();
                        editView.EditEndpoint(serialNumber);

                    }
                    catch (Exception e)
                    {
                        Program.message = e.Message;
                        ShowMenu();
                    }

                    break;
            }
        }
    }
}
