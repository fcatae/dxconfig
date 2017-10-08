using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class AppResourceLocationManager : ILocationManager<AppResource>
    {        
        public string Create(IUser user, AppResource resource)
        {
            // check CREATE permission
            
            return resource.Name + "/" + resource.Environment;
        }

        public string Resolve(IUser user, AppResource resource)
        {
            // check READ permission

            return resource.Name + "/" + resource.Environment;
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
