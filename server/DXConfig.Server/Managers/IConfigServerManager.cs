using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public interface IConfigServerManager<T>
        where T: IResource
    {
        void Create(IUser user, T resource, IData config);
        IData Retrieve(IUser user, T resource);
    }
}
