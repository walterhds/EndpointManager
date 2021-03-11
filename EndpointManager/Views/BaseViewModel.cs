using EndpointManager.AuxiliarModels;
using EndpointManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointManager.Views
{
    public abstract class BaseViewModel : EndpointError
    {
        public readonly EndpointController _endpointController;

        public BaseViewModel()
        {
            _endpointController = new EndpointController();
        }
    }
}
