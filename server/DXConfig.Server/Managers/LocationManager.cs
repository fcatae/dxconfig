using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using System.Net;

namespace DXConfig.Server.Managers
{
    public class AppResourceLocationManager : ILocationManager<AppResource>
    {
        //public string Create(IUser user, AppResource resource, string location)
        //{
        //    string container = WebUtility.UrlEncode(resource.Name) + "/" + WebUtility.UrlEncode(resource.Environment);

        //    // check CREATE permission
        //    // return null if the user does not have access (eg, env=prod)

        //    return container;
        //}

        public string Resolve(IUser user, AppResource resource)
        {
            // check READ permission
            // return null if the user does not have access (eg, env=prod)

            return WebUtility.UrlEncode(resource.Name) + "/" + WebUtility.UrlEncode(resource.Environment);
        }
    }
}
