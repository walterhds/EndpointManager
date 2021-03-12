using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views
{
    public class ConfirmExit
    {
        public void Confirm()
        {
            Console.Clear();
            Console.WriteLine("Do you really want to exit? (y/n):");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                Environment.Exit(0);
        }
    }
}
