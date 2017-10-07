using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class LocationManager : ILocationManager<IResource>
    {        
        public string Create(IUser user, IResource resource)
        {
            throw new NotImplementedException();
        }

        public string Resolve(IUser user, IResource resource)
        {
            throw new NotImplementedException();
        }
    }

    public class AppLinkLocationManager : ILocationManager<AppLink>
    {
        public string Create(IUser user, AppLink resource)
        {
            // check CREATE permission

            return resource.Link;
        }

        public string Resolve(IUser user, AppLink resource)
        {
            // check READ permission

            return resource.Link;
        }
    }
}
