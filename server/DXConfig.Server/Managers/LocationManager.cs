using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class LocationManager : ILocationManager<IResource>
    {
        public string Create(IResource resource, IPassKey key)
        {
            throw new NotImplementedException();
        }

        public string Resolve(IResource resource, IPassKey key)
        {
            throw new NotImplementedException();
        }
    }
}
