using EndpointManager.Controllers;
using EndpointManager.Models;
using EndpointManager.Views;
using System;

namespace EndpointManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.ShowMenu();
        }
    }
}
