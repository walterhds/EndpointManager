using EndpointManager.Controllers;
using EndpointManager.Data;
using EndpointManager.Models;
using EndpointManager.Views;
using System;

namespace EndpointManager
{
    public class Program
    {
        public static DbContext _dbContext = new DbContext();
        public static string message = "";
        static void Main(string[] args)
        {
            var menu = new Menu();

            menu.ShowMenu();
        }
    }
}
