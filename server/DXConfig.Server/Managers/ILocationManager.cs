using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public interface ILocationManager<T>
        where T: IResource
    {
        string Create(IUser user, T resource, string location);
        string Resolve(IUser user, T resource);
    }
}
