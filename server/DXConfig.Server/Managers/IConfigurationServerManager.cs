using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public interface IConfigurationServerManager<T>
        where T: IResource
    {
        void Create(T resource, IPassKey key, IData config);
        IData Retrieve(T resource, IPassKey key);
    }
}
