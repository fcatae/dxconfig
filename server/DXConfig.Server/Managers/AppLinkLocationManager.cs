using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Managers
{
    public class AppLinkLocationManager : ILocationManager<AppLink>
    {
        IStoreServices _store;

        public AppLinkLocationManager(IStoreServices store)
        {
            _store = store;
        }

        public string Create(IUser user, AppLink resource, string location)
        {
            string containerName = resource.Link;

            // check CREATE permission

            // _store.WriteData(containerName, new StringData(location));

            return containerName;
        }

        public string Resolve(IUser user, AppLink resource)
        {
            // check READ permission

            return resource.Link;
        }
    }
}
