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
        string Create(T resource, IPassKey key);
        string Resolve(T resource, IPassKey key);
    }
}
