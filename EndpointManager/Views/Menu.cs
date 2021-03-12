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
            }
        }
    }
}
